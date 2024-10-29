using DeliveryWebApp.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using DeliveryWebApp.Models;
using DeliveryWebApp.DTO_s;
using System.Globalization;
using DeliveryWebApp.Data;
using System.Text;

namespace DeliveryWebApp.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrderDbContext _context;

        public OrdersService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> AddNewOrder(NewOrderDTO request)
        {
            if (!DateTime.TryParseExact(
                request.FirstDeliveryDateTime.ToString(), 
                "yyyy-MM-dd HH:mm:ss", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out DateTime firstDeliveryDateTime))
            {
                return null;
            }

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Weight = request.Weight,
                CityDistrict = request.CityDistrict,
                OrderDate = DateTime.SpecifyKind(firstDeliveryDateTime, DateTimeKind.Utc),
            };

            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<List<Order>> GetListOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<List<Order>> UploadFromFile(IFormFile file)
        {
            using (StreamReader sr = new(file.OpenReadStream(), Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var parts = sr.ReadLine()?.Split(';');

                    if (Guid.TryParse(parts[0], out Guid id) 
                        && double.TryParse(parts[1], out double weight) 
                        && !string.IsNullOrEmpty(parts[2])
                        && DateTime.TryParseExact(parts[3], "yyyy-MM-dd HH:mm:ss", 
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDateTime))
                    {
                        await _context.AddAsync(new Order
                        {
                            Id = id,
                            Weight = weight,
                            CityDistrict = parts[2],
                            OrderDate = DateTime.SpecifyKind(orderDateTime, DateTimeKind.Utc)
                        });
                    }
                    else
                    {
                        throw new ArgumentException("Проверьте данные в файле или выберите другой");
                    }
                }
            };

            await _context.SaveChangesAsync();
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetFilteredOrderList(string cityDistrict, DateTime firstDeliveryDateTime)
        {
            return await _context.Orders
                .Where(o => o.CityDistrict == cityDistrict && 
                o.OrderDate >= firstDeliveryDateTime && 
                o.OrderDate <= firstDeliveryDateTime.AddMinutes(30))
                .ToListAsync();
        }
    }
}
