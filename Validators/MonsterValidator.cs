using FluentValidation;
using FluentValidation.AspNetCore;
using StrategyGame.Models;
using StrategyGame.Requests;

namespace StrategyGame.Validators
{
    public class MonsterValidator : AbstractValidator<MonsterRequest>
    {
        public MonsterValidator()
        {
            RuleFor(x => x.Damage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
