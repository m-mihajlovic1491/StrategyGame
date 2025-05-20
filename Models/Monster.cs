using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Monster
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public decimal Damage { get; set; }

    public string Name { get; set; }

    public decimal Defense { get; set; }

    public decimal Health { get; set; } = 100;
}
