using ApacheKafka.OrderApi.OrderServices;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ApacheKafka.OrderApi.Controllers
{
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("start-consuming-service")]
        public async Task<IActionResult> StartService()
        {
            await orderService.StartConsumingService();
            return NoContent();
        }

        [HttpGet("get-product")]
        public IActionResult GetProduct()
        {
            var products = orderService.GetProducts();
            return Ok(products);
        }

        [HttpPost("add-order")]
        public IActionResult AddOrder(Order order)
        {
            orderService.AddOrder(order);
            return Ok("Order placed");
        }

        [HttpGet("order-summary")]
        public IActionResult GetOrdersSummary() =>Ok(orderService.GetOrdersSummary());
    }
}
