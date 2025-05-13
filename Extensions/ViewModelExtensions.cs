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
                EquippedArmor = hero.EquippedArmor is null ? null : new ArmorViewModel
                {
                    Id = hero.EquippedArmorNavigation.Id,
                    Name = hero.EquippedArmorNavigation.Name,
                    DefensePercentage = hero.EquippedArmorNavigation.DefensePercentage
                },
                EquippedWeapon = hero.EquippedWeapon is null ? null : new WeaponViewModel
                {
                    Id = hero.EquippedWeaponNavigation.Id,
                    Damage = hero.EquippedWeaponNavigation.Damage,
                    Name = hero.EquippedWeaponNavigation.Name

                },

                Health = hero.Health,
                IsDead = hero.IsDead,
                Legion = hero.LegionId is null ? null : new LegionViewModel
                {
                    Id = hero.Legion.Id,
                    Name = hero.Legion.Name,
                }
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
