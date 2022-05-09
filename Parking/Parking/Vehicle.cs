namespace Parking
{
    static partial class Program
    {
        class Vehicle
        {
            public Vehicle(string brand, string model)
            {
                Brand = brand;
                Model = model;
            }

            public string Brand { get; private set; }
            public string Model { get; private set; }
        }
    }
}
