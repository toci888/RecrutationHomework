using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.Models
{
    public class PricesModel
    {
        public string ID { get; set; }
        public string SKU { get; set; }
        public string NettProductPrice { get; set; }
        public string NettProductPriceDiscount { get; set; }
        public string VatRate { get; set; }
        public string NettProductPriceDiscountPlu { get; set; }
    }
}
