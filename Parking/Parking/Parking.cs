using System.Collections.Generic;

namespace Parking
{
    static partial class Program
    {
        class Parking
        {
            Place[] places;
            public Parking(string name, params Place[] places)
            {
                this.places = places;
                Name = name;
            }
            public string Name { get; private set; }
            public IEnumerable<Place> Places => places;
        }
    }
}
