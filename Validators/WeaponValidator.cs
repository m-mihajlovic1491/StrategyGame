using FluentValidation;
using StrategyGame.Requests;

namespace StrategyGame.Validators
{
    public class WeaponValidator : AbstractValidator<WeaponRequest>
    {
        public WeaponValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20).WithMessage("Weapon Name should not have more than 20 characters");
            RuleFor(x => x.Damage)
                .GreaterThan(0).WithMessage("Weapon damage should be greater than 0");
        }
    }
}
