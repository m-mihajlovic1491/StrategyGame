using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Hero
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public int? LegionId { get; set; }

    public int? EquippedArmor { get; set; }

    public int? EquippedWeapon { get; set; }

    public decimal Health { get; set; }

    public bool IsDead { get; set; }

    public virtual Backpack? Backpack { get; set; }

    public virtual Armor? EquippedArmorNavigation { get; set; }

    public virtual Weapon? EquippedWeaponNavigation { get; set; }

    public virtual Legion? Legion { get; set; }
}
