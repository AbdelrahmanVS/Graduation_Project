using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class Prouduct
{
    public int ProuductId { get; set; }

    public string? ProuductName { get; set; }

    public int? Size { get; set; }

    public decimal? Price { get; set; }

    public string? ImagUrl { get; set; }
}
