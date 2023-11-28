using System;
using System.Collections.Generic;

namespace Integrate.Database.Persistence.Models;

public partial class Productbysku
{
    public string? Sku { get; set; }

    public string? Name { get; set; }

    public string? Ean { get; set; }

    public string? ProducerName { get; set; }

    public string? Category { get; set; }

    public string? DefaultImage { get; set; }

    public double? Qty { get; set; }

    public string? Unit { get; set; }

    public double? Nettproductprice { get; set; }

    public double? ShippingCost { get; set; }
}
