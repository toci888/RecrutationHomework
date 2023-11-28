using System;
using System.Collections.Generic;

namespace Integrate.Database.Persistence.Models;

public partial class Inventory
{
    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public string? Unit { get; set; }

    public double? Qty { get; set; }

    public string? Manufacturer { get; set; }

    public string? Shipping { get; set; }

    public double? ShippingCost { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Product SkuNavigation { get; set; } = null!;
}
