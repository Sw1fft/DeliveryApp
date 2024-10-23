namespace DeliveryApp.Models.Abstractions
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        string AddNewOrder(Order order);
    }
}
