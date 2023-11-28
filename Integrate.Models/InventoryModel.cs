using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.Models
{
    public class InventoryModel
    {
        public string product_id { get; set; }
        public string sku { get; set; }
        public string unit { get; set; }
        public string qty { get; set; }
        public string manufacturer_name { get; set; }
        public string manufacturer_ref_num { get; set; }
        public string shipping { get; set; }
        public string shipping_cost { get; set; }
    }
}
