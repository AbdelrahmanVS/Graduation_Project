using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class Boot
{
    public int BootId { get; set; }

    public string? BootName { get; set; }

    public int? Size { get; set; }

    public string? ImagUrl { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<UserBootPurchase> UserBootPurchases { get; set; } = new List<UserBootPurchase>();
}
