using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class UserOxfordPurchase
{
    public int PurchaseId { get; set; }

    public int? UserId { get; set; }

    public int? OxfordId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? BootPrice { get; set; }

    public virtual Oxford? Oxford { get; set; }

    public virtual User? User { get; set; }
}
