using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class UserBootPurchase
{
    public int PurchaseId { get; set; }

    public int? UserId { get; set; }

    public int? BootId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? BootPrice { get; set; }

    public virtual Boot? Boot { get; set; }

    public virtual User? User { get; set; }
}
