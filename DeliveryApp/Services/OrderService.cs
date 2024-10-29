using DeliveryApp.Models.Abstractions;
using DeliveryApp.Models;

namespace DeliveryApp.Services
{
    public class OrderService : IOrderService
    {
        public string AddNewOrder(Order order)
        {


            using (StreamWriter sw = new("DataOrder.txt"))
            {
                sw.WriteLineAsync($"");
            }

            return "";
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> OrderFilter(List<Order> orders, string district, DateTime firstDeliveryDateTime)
        {
            return orders;
        }
    }
}
