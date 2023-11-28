using Integrate.Models;

namespace Integrate.Bll.Parsing
{
    public class ParseProducts : ParseCsvBase<ProductsModel>
    {
        public ParseProducts() 
        {
            ParsingMap = new Dictionary<string, Func<string[], ProductsModel, ProductsModel>>()
            {
                { "ID", (line, model) => { model.ID = line[0]; return model; } },
                { "SKU", (line, model) => { model.SKU = line[1]; return model; } },
                { "name", (line, model) => { model.name = line[2]; return model; } },
                { "reference_number", (line, model) => { model.reference_number = line[3]; return model; } },
                { "EAN", (line, model) => { model.EAN = line[4]; return model; } },
                { "can_be_returned", (line, model) => { model.can_be_returned = line[5]; return model; } },
                { "producer_name", (line, model) => { model.producer_name = line[6]; return model; } },
                { "category", (line, model) => { model.category = line[7]; return model; } },
                { "is_wire", (line, model) => { model.is_wire = line[8]; return model; } },
                { "shipping", (line, model) => { model.shipping = line[9]; return model; } },
                { "package_size", (line, model) => { model.package_size = line[10]; return model; } },
                { "available", (line, model) => { model.available = line[11]; return model; } },
                { "logistic_height", (line, model) => { model.logistic_height = line[12]; return model; } },
                { "logistic_width", (line, model) => { model.logistic_width = line[13]; return model; } },
                { "logistic_length", (line, model) => { model.logistic_length = line[14]; return model; } },
                { "logistic_weight", (line, model) => { model.logistic_weight = line[15]; return model; } },
                { "is_vendor", (line, model) => { model.is_vendor = line[16]; return model; } },
                { "available_in_parcel_locker", (line, model) => { model.available_in_parcel_locker = line[17]; return model; } },
                { "default_image", (line, model) => { model.default_image = line[18]; return model; } }
            };
        }
    }
}
