using System;
using System.Collections.Generic;

namespace DemoMVC.Models;

public partial class Beer
{
    public int Beerid { get; set; }

    public string? Name { get; set; }

    public int? Brandid { get; set; }

    public virtual Brand? Brand { get; set; }
}
