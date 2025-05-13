using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Data;
using StrategyGame.Models;
using StrategyGame.Requests;
using StrategyGame.Validators;

namespace StrategyGame.Controllers
{
    [ApiController]
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

    }
}
