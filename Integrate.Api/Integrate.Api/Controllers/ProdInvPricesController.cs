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
            return true;
        }
    }
}
