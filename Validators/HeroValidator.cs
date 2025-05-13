using FluentValidation;
using StrategyGame.Models;
using StrategyGame.Requests;

namespace StrategyGame.Validators
{
    public class HeroValidator : AbstractValidator<HeroRequest>
    {
        public HeroValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20).WithMessage("Lenght should not be greather than 20")
                .NotEmpty();
        }
    }
}
