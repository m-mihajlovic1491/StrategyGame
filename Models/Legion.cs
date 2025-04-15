using System;
using System.Collections.Generic;

namespace StrategyGame.Models;

public partial class Legion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}
