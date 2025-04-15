using StrategyGame.Models;

namespace StrategyGame.ViewModels
{
    public class HeroViewModel
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string? Name { get; set; }

        public int? LegionId { get; set; }

        public int? EquippedArmor { get; set; }

        public WeaponViewModel? EquippedWeapon { get; set; }

        public decimal Health { get; set; }

        public bool IsDead { get; set; }

        public int? Backpack { get; set; }    

        
    }
}
