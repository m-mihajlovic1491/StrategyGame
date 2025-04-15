using StrategyGame.Models;
using StrategyGame.ViewModels;
using System.Runtime.CompilerServices;

namespace StrategyGame.Extensions
{
    public static class ViewModelExtensions
    {
        public static HeroViewModel ToViewModel (this Hero hero) {
            return new HeroViewModel
            {
                Guid = hero.Guid,
                Id = hero.Id,
                Name = hero.Name,
                EquippedArmor = hero.EquippedArmor,
                EquippedWeapon = new WeaponViewModel
                {
                    Id = hero.EquippedWeaponNavigation.Id,
                    Damage = hero.EquippedWeaponNavigation.Damage,
                    Name = hero.EquippedWeaponNavigation.Name

                },

                Health = hero.Health,
                IsDead = hero.IsDead,
                LegionId = hero.LegionId
            };

            
        }

        public static WeaponViewModel ToViewModel(this Weapon weapon)
        {
            return new WeaponViewModel
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Damage = weapon.Damage
            };


        }
    }
}
