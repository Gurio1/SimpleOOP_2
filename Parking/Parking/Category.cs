using System.Collections.Generic;

namespace Parking
{
    static partial class Program
    {
        class Category
        {
            public string Name { get; private set; }
            public static readonly Category Cola;
            public static readonly Category Bus;
            public static readonly Category Camion;

            static List<Category> categories { get; }
            public static IEnumerable<Category> Categories => categories;

            static Category()
            {
                categories = new List<Category>();

                Cola = new Category("Кола");
                Bus = new Category("Бус");
                Camion = new Category("Камион");
            }

            public Category(string name)
            {
                categories.Add(this);
                Name = name;
            }
        }
    }
}
