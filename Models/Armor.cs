using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Armor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? DefensePercentage { get; set; }

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}
