using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Parking
{
    static partial class Program
    {
        delegate void KeyWords(string[] arg);
        static List<Parking> Parkings = new List<Parking>();
        static Dictionary<string, KeyWords> Events = new Dictionary<string, KeyWords>();

        static int ToInt32(this string value)
        {
            return (value as IConvertible).ToInt32(System.Globalization.NumberFormatInfo.InvariantInfo);
        }
        static void AddVehicleEvent(Category category, Vehicle vehicle)
        {
            Parkings.SelectMany(parking => parking.Places).Where(place => place.Category == category).First(place => place.HasPlace()).AddVehicle(vehicle);
            Parkings.OrderBy(a => a.Places.Select(c => c.Category));
        }
        static void PrintParking(string name)
        {
            var Parking = Parkings.First(p => p.Name.Equals(name)).Places.SelectMany(place=>place.GetVehicles());
            Console.WriteLine($"Паркирани автомобили в паркинг {name}:");
            foreach(var veh in Parking)
            {
                
                Console.WriteLine($"Марка {veh.Brand} Модел {veh.Model}");
            }
        }
        static void AllStats()
        {
            foreach(var parking in Parkings)
            {
                int GetCapacity(string category)
                {
                    return parking.Places.First(p => p.Category.Name.Equals(category)).Capacity;
                }
                int GetOccupiedPlaces(string category)
                {
                    return parking.Places.First(p => p.Category.Name.Equals(category)).GetPointer();
                }
                StringBuilder sb = new StringBuilder();
                sb.Append($"Паркинг {parking.Name} разполага с следните места\t\n");
                sb.Append($"Леки автомобили {GetCapacity("Кола")},заети {GetOccupiedPlaces("Кола")}\n");
                sb.Append($"Лекотоварни автомобили {GetCapacity("Бус")},заети {GetOccupiedPlaces("Бус")}\n");
                sb.Append($"Тежкотоварни автомобили {GetCapacity("Камион")},заети {GetOccupiedPlaces("Камион")}\n");
                Console.WriteLine(sb);
            }
        }

        static Program()
        {
            Events.Add("паркинг", arg =>
            {
                Parking parking = new Parking(arg[1], new Place(Category.Cola, arg[2].ToInt32()), new Place(Category.Bus, arg[3].ToInt32()), new Place(Category.Camion, arg[4].ToInt32()));
                Parkings.Add(parking);
            });
            Events.Add("add_vehicle", arg =>
            {
                AddVehicleEvent(Category.Categories.First(c => c.Name.Equals(arg[0])), new Vehicle(arg[1], arg[2]));
            });
            Events.Add("печат", arg => PrintParking(arg[1]));
            Events.Add("край", arg => AllStats());
            
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string[] arg = Console.ReadLine().Split(' ');
                if ( Events.ContainsKey(arg[0].ToLower()))
                    Events[arg[0].ToLower()](arg);
                else
                    Events["add_vehicle"](arg); 
            }
          




        }
    }
}
