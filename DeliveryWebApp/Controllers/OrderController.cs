using Microsoft.AspNetCore.Mvc;

namespace DeliveryWebApp.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class OrderController : ControllerBase
    {
        public Task<IActionResult> GetListOrders()
        {

        }
    }
}
