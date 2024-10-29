using DeliveryWebApp.DTO_s;

namespace DeliveryWebApp.Models.Abstractions
{
    public interface IOrdersService
    {
        Task<List<Order>> GetListOrders();

        Task<Order?> AddNewOrder(NewOrderDTO request);

        Task<List<Order>> UploadFromFile(IFormFile file);

        Task<List<Order>> GetFilteredOrderList(string cityDistrict, DateTime firstDeliveryDateTime);
    }
}
