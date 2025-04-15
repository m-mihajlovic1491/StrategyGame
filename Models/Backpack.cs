using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Backpack
{
    public int Id { get; set; }

    public int Size { get; set; }

    public int HeroId { get; set; }

    public virtual Hero Hero { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
