using Integrate.Bll.MainLogic;
using Integrate.Common.Interfaces;
using Integrate.Database.Persistence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdInvPricesController : ControllerBase
    {
        [HttpPost("product-inventory-prices")]
        public bool ProductInventoryPrices()
        {
            FeedData feedData = new FeedData();

            return feedData.RunParses();
        }

        [HttpGet("product-inventory-prices")]
        public Productbysku GetProductInventoryPrices(string sku)
        { 
            IDbHandle<Productbysku> dbHandle = new IntegrateDbHandle<Productbysku>();

            Productbysku productbysku = dbHandle.Select(m => m.Sku == sku).FirstOrDefault();

            return productbysku;
        }
    }
}
