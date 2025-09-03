using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class Oxford
{
    public int OxfordId { get; set; }

    public string? BootName { get; set; }

    public int? Size { get; set; }

    public decimal? Price { get; set; }

    public string? ImagUrl { get; set; }

    public virtual ICollection<UserOxfordPurchase> UserOxfordPurchases { get; set; } = new List<UserOxfordPurchase>();
}
