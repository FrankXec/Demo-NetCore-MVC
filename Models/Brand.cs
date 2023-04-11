using System;
using System.Collections.Generic;

namespace DemoMVC.Models;

public partial class Brand
{
    public int Brandid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer> Beers { get; } = new List<Beer>();
}
