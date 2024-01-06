namespace NPL.M.A009
{
    public class AirportManager
    {
        public List<Airport> airports { get; set; } = new List<Airport>();

        public void Create()
        {
            Console.WriteLine("\n===== Enter data =====");
            Console.WriteLine("Airport ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Airport Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Runway Size: ");
            double runwaySize = InputHelper.InputDouble();

            Console.WriteLine("Max Fixedwing Parking Place: ");
            int maxFixedwingParking = InputHelper.InputInteger();

            Console.WriteLine("Max Rotated Wing Parking Place: ");
            int maxHelicopterParking = InputHelper.InputInteger();

            Airport newAirport = new Airport(id, name, runwaySize, maxFixedwingParking, maxHelicopterParking);
            airports.Add(newAirport);
        }

        private void ShowListAirports()
        {
            System.Console.WriteLine("\n===== List of all airports =====");
            if (airports.Count == 0)
            {
                System.Console.WriteLine("No airports found.");
            }
            else
            {
                System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}{6, 10}",
                    "ID", "Name", "Runway Size", "Max Fixedwing Parking Place", "Max Rotated Wing Parking Place", "FixedWings", "Helicopters"));
                foreach (var airport in airports)
                {
                    System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}{6, 10}",
                    airport.ID, airport.Name, airport.RunwaySize, airport.MaxFixedwingParking, airport.MaxHelicopterParking,
                    airport.ListFixedwingID.Count, airport.ListHelicopterID.Count));
                }
            }
        }

        internal void ShowMenu()
        {
            string menuTitle = "Airport Management";
            var menuItems = new List<string>(){
                "Add New Airport",
                "Remove an airport",
                "Display list of all airports",
            };

            int choice = InputHelper.CreateMenu(menuTitle, menuItems);

            switch (choice)
            {
                case 1:
                    // Add New Airport
                    Create();
                    break;
                case 2:
                    // Remove an airport
                    Remove();
                    break;
                case 3:
                    // Display list of all airports
                    ShowListAirports();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void Remove()
        {
            string menuTitle = "List of Airports:";
            var menuItems = new List<string>();
            airports.ForEach(a => menuItems.Add(a.ID + " - " + a.Name));
            // 1 - Tan Son Nhat
            // 2 - Noi Bai
            // 3 - Cat Bi
            int choice = InputHelper.CreateMenu(menuTitle, menuItems);

            airports.RemoveAt(choice - 1);
        }
    }
}
