namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryAddress deliveryAddress = new DeliveryAddress("Assiut", "Al-Salam", 12);
            DeliveryAddress deliveryAddressCopy = deliveryAddress;
            deliveryAddressCopy.BuildingNumber = 5;
            deliveryAddressCopy.Street = "Dar Heraa'";


            Console.WriteLine(deliveryAddress.GetFullAddress());

            Console.WriteLine(deliveryAddressCopy.GetFullAddress());
        }
    }
}
