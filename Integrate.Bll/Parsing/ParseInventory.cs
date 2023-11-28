using Integrate.Models;

namespace Integrate.Bll.Parsing
{
    public class ParseInventory : ParseCsvBase<InventoryModel>
    {
        public ParseInventory() 
        {
            ParsingMap = new Dictionary<string, Func<string[], InventoryModel, InventoryModel>>()
            {
                { "product_id", (line, model) => { model.product_id = line[0]; return model; } },
                { "sku", (line, model) => { model.sku = line[1]; return model; } },
                { "unit", (line, model) => { model.unit = line[2]; return model; } },
                { "qty", (line, model) => { model.qty = line[3]; return model; } },
                { "manufacturer_name", (line, model) => { model.manufacturer_name = line[4]; return model; } },
                { "manufacturer_ref_num", (line, model) => { model.manufacturer_ref_num = line[5]; return model; } },
                { "shipping", (line, model) => { model.shipping = line[6]; return model; } },
                { "shipping_cost", (line, model) => { model.shipping_cost = line[7]; return model; } }
            };
        }
    }
}
