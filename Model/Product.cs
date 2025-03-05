using System;
using System.Collections.Generic;

namespace BlazorAppProj.Model;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? Quntity { get; set; }

    public decimal? Price { get; set; }
}
