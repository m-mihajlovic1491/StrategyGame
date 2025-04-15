using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Monster
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public decimal Damage { get; set; }
}
