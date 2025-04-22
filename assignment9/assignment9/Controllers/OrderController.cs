using Microsoft.AspNetCore.Mvc;

namespace Assignment9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService = new OrderService();
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orderService.Orders;
        }
        [HttpGet("{id}")]
        public Order Get(string id)
        {
            return orderService.GetOrder(id);
        }
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            orderService.AddOrder(order);
        }
        [HttpPut]
        public void Put([FromBody] Order order)
        {
            orderService.UpdateOrder(order);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            orderService.RemoveOrder(id);
        }

    }
}
