using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class Sport
{
    public int SportId { get; set; }

    public string? SportName { get; set; }

    public int? Size { get; set; }

    public decimal? Price { get; set; }

    public string? ImagUrl { get; set; }

}
