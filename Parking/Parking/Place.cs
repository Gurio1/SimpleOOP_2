using System.Collections.Generic;

namespace Parking
{
    static partial class Program
    {
        class Place
        {
            Vehicle[] vehicles;
            int pointer;
            public int GetPointer()
            {
                return pointer;
            }

            public Place(Category category, int capacity)
            {
                vehicles = new Vehicle[capacity]; 
                Category = category;
                Capacity = capacity;
            }

            public Category Category { get; private set; }
            public int Capacity { get; private set; }

            public void AddVehicle(Vehicle vehicle)
            {
                vehicles[pointer++] = vehicle;
            }

            public IEnumerable<Vehicle> GetVehicles()
            {
                for (int i = 0; i < pointer; i++)
                {
                    yield return vehicles[i];
                }
                
            }

            public bool HasPlace()
            {
                return pointer < Capacity;
            }
        }
    }
}
