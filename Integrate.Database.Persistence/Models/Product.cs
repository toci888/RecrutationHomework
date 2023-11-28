using System;
using System.Collections.Generic;

namespace Integrate.Database.Persistence.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public string? Name { get; set; }

    public string? Ean { get; set; }

    public string? ProducerName { get; set; }

    public string? Category { get; set; }

    public int? IsWire { get; set; }

    public int? Available { get; set; }

    public int? IsVendor { get; set; }

    public string? DefaultImage { get; set; }

    public virtual Inventory? InventoryProduct { get; set; }

    public virtual Inventory? InventorySkuNavigation { get; set; }

    public virtual Price? PriceIdNavigation { get; set; }

    public virtual Price? PriceSkuNavigation { get; set; }
}
