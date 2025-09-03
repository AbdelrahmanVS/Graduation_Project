using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class UserSportPurchase
{
    public int PurchaseId { get; set; }

    public int? UserId { get; set; }

    public int? SportId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? BootPrice { get; set; }

    public virtual Sport? Sport { get; set; }

    public virtual User? User { get; set; }
}
