using DeliveryWebApp.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;
using DeliveryWebApp.Models;
using DeliveryWebApp.DTO_s;

namespace DeliveryWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        [Route("get_list")]
        public async Task<ActionResult<List<Order>>> GetListOrders()
        {
            List<Order> ordersList = await _ordersService.GetListOrders();

            return Ok(ordersList);

        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> NewOrder([FromBody] NewOrderDTO request)
        {
            var order = await _ordersService.AddNewOrder(request);

            return Ok(order);
        }

        [HttpPost]
        [Route("upload_file")]
        public async Task<ActionResult<List<Order>>> UploadOrdersFromFile(IFormFile file)
        {
            var result = await _ordersService.UploadFromFile(file);

            return Ok(result);
        }

        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<List<Order>>> FilterList(string cityDistrict, DateTime firstDeliveryDateTime)
        {
            var result = await _ordersService.GetFilteredOrderList(
                cityDistrict, 
                DateTime.SpecifyKind(firstDeliveryDateTime, DateTimeKind.Utc));

            return Ok(result);
        }
    }
}
