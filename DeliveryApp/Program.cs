using System.Globalization;

namespace DeliveryApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите район, вес и время:");

            Console.Write("Район >>> ");
            string cityDistrict = Console.ReadLine();

            Console.Write("Вес >>> ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Время >>> ");
            string dataOrder = Console.ReadLine();

            if (!DateTime.TryParseExact(dataOrder, 
                "yyyy-MM-dd HH:mm:ss", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.AssumeUniversal, 
                out DateTime firstDeliveryDateTime))
            {
                Console.WriteLine($"Некорректная дата: {dataOrder}");
                return;
            }

            if (!string.IsNullOrEmpty(cityDistrict) && weight > 0)
            {
                
            }
        }
    }
}
