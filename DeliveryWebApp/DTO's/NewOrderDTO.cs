using System.ComponentModel.DataAnnotations;

namespace DeliveryWebApp.DTO_s
{
    public class NewOrderDTO
    {
        [Required]
        [Range(0.1, double.MaxValue)]
        public double Weight { get; set; }
        [Required]
        public string CityDistrict { get; set; } = null!;
        [Required]
        public string FirstDeliveryDateTime { get; set; } = null!;
    }
}
