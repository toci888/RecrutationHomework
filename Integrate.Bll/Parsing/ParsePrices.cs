using Integrate.Models;

namespace Integrate.Bll.Parsing
{
    public class ParsePrices : ParseCsvBase<PricesModel>
    {
        public ParsePrices()
        {
            ParsingMap = new Dictionary<string, Func<string[], PricesModel, PricesModel>>()
            {
                { "ID", (line, model) => { model.ID = line[0]; return model; } },
                { "SKU", (line, model) => { model.SKU = line[1]; return model; } },
                { "NettProductPrice", (line, model) => { model.NettProductPrice = line[2]; return model; } },
                { "NettProductPriceDiscount", (line, model) => { model.NettProductPriceDiscount = line[3]; return model; } },
                { "VatRate", (line, model) => { model.VatRate = line[4]; return model; } },
                { "NettProductPriceDiscountPlu", (line, model) => { model.NettProductPriceDiscountPlu = line[5]; return model; } },
            };
        }
    }
}
