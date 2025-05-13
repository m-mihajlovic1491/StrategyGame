using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Data;
using StrategyGame.Extensions;
using StrategyGame.Models;
using StrategyGame.Requests;
using StrategyGame.Validators;

namespace StrategyGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroController : ControllerBase
{
    public StrategyGameContext _context { get; set; }

    private readonly ILogger<HeroController> _logger;

    public HeroController(ILogger<HeroController> logger, StrategyGameContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetHeroById([FromRoute] int id)
    {
        var hero = _context.Heroes
            .Include(w => w.EquippedWeaponNavigation)
            .Include(a=>a.EquippedArmorNavigation)
            .Include(l=>l.Legion)
            .FirstOrDefault(x => x.Id == id);


        if (hero is null)
        {
            return NotFound($"Hero with id {id} not found");
        }

        return Ok(hero.ToViewModel());
    }

    [HttpPost]
    public IActionResult CreateHero([FromBody] HeroRequest request, [FromServices] IValidator<HeroRequest> heroValidator )
    {
        var validationResult = heroValidator.Validate(request);
       
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var hero = new Hero
        {
            Guid = Guid.NewGuid(),
            Name = request.Name,

        };

        _context.Heroes.Add(hero);
        _context.SaveChanges();
        return Ok($"Hero {hero.Name} saved to database");
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteHero([FromRoute] int id)
    {
        var hero = _context.Heroes.FirstOrDefault(h => h.Id == id);

        if (hero is null)
        {
            return NotFound();
        }

        _context.Heroes.Remove(hero);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPost]
    [Route("{heroId}/{weaponId}")]

    public IActionResult AddWeaponToHero([FromRoute] int heroId, int weaponId)
    {
        var hero = _context.Heroes.FirstOrDefault(h => h.Id == heroId);
        var weapon = _context.Heroes.FirstOrDefault(w => w.Id == weaponId);

        if (hero is null)
        {
            return NotFound("hero not found");
        }

        if (weapon is null)
        {
            return NotFound("weapon not found");
        }

        if (hero.EquippedWeapon == weaponId)
        {
            return BadRequest("weapon already equipped to hero");
        }

        hero.EquippedWeapon = weapon.Id;
        _context.SaveChanges();
        return Ok("weapon added to hero successfully");


    }

    [HttpGet]
    [Route("Heroes")]

    public IActionResult GetAllheroes([FromQuery]int pageIndex,int pageSize, string? search) {
        var heroesQuery = _context.Heroes
            .Include(w => w.EquippedWeaponNavigation)
            .Include(a => a.EquippedArmorNavigation)
            .Include(l => l.Legion)            
            .AsQueryable();

        var searchTerm = search is null ? "" : search.ToLower().Trim();

        if (!string.IsNullOrWhiteSpace(search))
        {
            heroesQuery =heroesQuery.Where(x => x.Name.ToLower().Contains(searchTerm) ||
                                                x.Legion.Name.ToLower().Contains(searchTerm));
        }

        var heroes = heroesQuery
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToList();
        return Ok (heroes.Select(x => x.ToViewModel()));
    }


}
