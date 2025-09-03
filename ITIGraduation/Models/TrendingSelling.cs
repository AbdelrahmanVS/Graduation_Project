using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class TrendingSelling
{
    public int ProudId { get; set; }

    public string? ProudName { get; set; }

    public int? Size { get; set; }

    public decimal? Price { get; set; }

    public string? ImagUrl { get; set; }

    public string? Imag2 { get; set; }

    public string? Imag3 { get; set; }

    public string? Imag4 { get; set; }
}
