using System;
using System.Collections.Generic;

namespace Integrate.Database.Persistence.Models;

public partial class Price
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public double? Nettproductprice { get; set; }

    public double? Nettproductpricediscount { get; set; }

    public double? Vatrate { get; set; }

    public double? Nettproductpricediscountplu { get; set; }

    public virtual Product IdNavigation { get; set; } = null!;

    public virtual Product SkuNavigation { get; set; } = null!;
}
