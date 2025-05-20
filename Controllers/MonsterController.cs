using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                Damage = request.Damage,
                Name = request.Name,
                Defense = request.Defense
            };

            _context.Add(monster);
            _context.SaveChanges();
            return Created();
        }

        [HttpPatch]
        [Route("bulkheal")]
        public async Task<IActionResult> HealAllMonsters()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
               await _context.Monsters.ExecuteUpdateAsync(m => m.SetProperty(x => x.Health, x => 100));
                await transaction.CommitAsync();
            }
            catch (Exception)
            {

                await transaction.RollbackAsync();
                throw;
            }

            return Ok("All monster healed to 100 hp");
        }
    }
}
