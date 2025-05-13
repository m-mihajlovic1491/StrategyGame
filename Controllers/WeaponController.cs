using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Data;
using StrategyGame.Extensions;
using StrategyGame.Models;
using StrategyGame.Requests;
using StrategyGame.Validators;

namespace StrategyGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeaponController : ControllerBase
    {
        public StrategyGameContext _context { get; set; }

        public ILogger<WeaponController> _logger { get; set; }

        public WeaponController(StrategyGameContext context, ILogger<WeaponController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Route("Weapon")]

        public IActionResult CreateWeapon([FromBody] WeaponRequest request,
            [FromServices] IValidator<WeaponRequest> validator)
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var weapon = new Weapon()
            {
                Damage = request.Damage,
                Name = request.Name
            };

            _context.Weapons.Add(weapon);
            _context.SaveChanges();

            return Ok($"weapon {weapon.Name} saved to database");
        }

        [HttpGet]
        [Route("Weapon/{id}")]

        public IActionResult GetSingleWeapon([FromRoute] int id) 
        {
           var weapon = _context.Weapons.FirstOrDefault(x => x.Id == id);
            if (weapon is null)
            {
                return NotFound($"weapon with id {id} not found");
            }

            return Ok(weapon.ToViewModel());
        }

        [HttpPut]
        [Route("Weapon/{id}")]

        public IActionResult UpdateSingleWeapon([FromRoute] int id, 
            [FromBody] WeaponRequest request)
        {
            var weapon = _context.Weapons.FirstOrDefault(x => x.Id == id);

            if (weapon is null)
            {
                return NotFound($"Weapon with id {id} not found");
            }

            weapon.Name = request.Name;
            weapon.Damage = request.Damage;

            _context.SaveChanges();
            return Ok(weapon.ToViewModel());


        }

        [HttpDelete]
        [Route("Weapon/{id}")]

        public IActionResult DeleteWeapon([FromRoute] int id)
        {
           var weapon = _context.Weapons.FirstOrDefault(x => x.Id == id);

            if (weapon is null)
            {
                return NotFound($"weapon with id {id} not found ");
            }

            _context.Weapons.Remove(weapon);
            _context.SaveChanges();

            return NotFound($"weapon {weapon.Name} with id {weapon.Id} deleted succefully ");
        }

    }
}
