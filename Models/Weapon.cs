using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Weapon
{
    public int Id { get; set; }

    public decimal Damage { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}
