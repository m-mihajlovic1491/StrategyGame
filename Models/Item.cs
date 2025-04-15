using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? ItemName { get; set; }

    public int Size { get; set; }

    public virtual ICollection<Backpack> BackPacks { get; set; } = new List<Backpack>();
}
