using System;
using System.Collections.Generic;

namespace ITIGraduation.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public string ShoeType { get; set; } = null!;

    public int ShoeId { get; set; }

    public string? ShoeName { get; set; }

    public int QuantityAvailable { get; set; }

    public DateTime? LastUpdated { get; set; }
}
