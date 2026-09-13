namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DeliveryAddress deliveryAddress = new DeliveryAddress("Assiut", "Al-Salam", 12);
            //DeliveryAddress deliveryAddressCopy = deliveryAddress;
            //deliveryAddressCopy.BuildingNumber = 5;
            //deliveryAddressCopy.Street = "Dar Heraa'";


            //Console.WriteLine(deliveryAddress.GetFullAddress());

            //Console.WriteLine(deliveryAddressCopy.GetFullAddress());

            DeliveryCenter center = new DeliveryCenter();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i + 1} Data");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine()!;

                Console.Write("Description: ");
                string description = Console.ReadLine()!;

                Console.Write("Weight: ");
                double.TryParse(
                    Console.ReadLine(),
                    out double weight);

                Console.Write("Delivery Fee: ");
                decimal.TryParse(Console.ReadLine(), out decimal deliveryFee);

                Console.Write("City: ");
                string city = Console.ReadLine()!;

                Console.Write("Street: ");
                string street = Console.ReadLine()!;

                Console.Write("Building Number: ");
                int.TryParse(Console.ReadLine(), out int buildingNumber);

                DeliveryAddress destination = new DeliveryAddress(city, street, buildingNumber);

                Shipment shipment = new Shipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    destination);

                if (center.AddShipment(shipment))
                {
                    Console.WriteLine("Shipment added successfully.");
                }
                else
                {
                    Console.WriteLine("Delivery center is full.");
                }
            }

            Console.WriteLine("All Shipments");

            for (int i = 0; i < 3; i++)
            {
                center[i].PrintShipment();
                Console.WriteLine();
            }

            Console.Write("Enter a tracking code to search: ");
            string searchCode = Console.ReadLine()!;

            Shipment foundShipment = center[searchCode];

            if (string.IsNullOrWhiteSpace(foundShipment.TrackingCode))
            {
                Console.WriteLine("Shipment not found.");
            }
            else
            {
                Console.WriteLine(
                    $"Shipment found: {foundShipment.TrackingCode} - {foundShipment.Description}");
            }

            Console.WriteLine("Struct Copy Test");

            DeliveryAddress originalAddress =
                center[0].Destination;

            DeliveryAddress copiedAddress =
                originalAddress;

            copiedAddress.Street = "Makram Ebeid";
            copiedAddress.BuildingNumber = 20;

            Console.WriteLine(
                $"Original Address: {originalAddress.GetFullAddress()}");

            Console.WriteLine(
                $"Copied Address: {copiedAddress.GetFullAddress()}");
        }
    }
}
