using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Data;
using StrategyGame.Models;
using StrategyGame.Requests;
using StrategyGame.Validators;

namespace StrategyGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
        public StrategyGameContext _context { get; set; }

        private readonly ILogger<MonsterController> _logger;

        public MonsterController(StrategyGameContext context, ILogger<MonsterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [Route("Monster")]

        public IActionResult CreateMonster([FromBody] MonsterRequest request,
                                           [FromServices] IValidator<MonsterRequest> validator )
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var monster = new Monster
            {
                Guid = Guid.NewGuid(),
                Damage = request.Damage
            };

            _context.Add(monster);
            _context.SaveChanges();
            return Created();
        }
    }
}
