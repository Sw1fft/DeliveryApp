namespace DeliveryWebApp.Models
{
    public class Order
    {
        private Guid _id;

        private double _weight;

        private string _cityDistrict;

        private DateTime _deliveryDate;

        private Order(Guid id, double weight, string cityDistrict, DateTime deliveryDate)
        {
            _id = id;
            _weight = weight;
            _cityDistrict = cityDistrict;
            _deliveryDate = deliveryDate;
        }

        public Guid Id { get; set; }

        public double Weight { get; set; }

        public string? CityDistrict { get; set; }

        public DateTime DeliveryDate { get; set; }

        public static Order NewOrder(Guid id, double weight, string cityDistrict, DateTime deliveryDate)
        {
            Order newOrder = new(id, weight, cityDistrict, deliveryDate);

            return newOrder;
        }
    }
}
