namespace NPL.M.A009
{
    public class FixedwingManager
    {
        // Airbus A380, Boeing 787, Airbus A350, Boeing 777
        public List<Fixedwing> Fixedwings = new List<Fixedwing>();

        public Fixedwing Create()
        {
            // Input Fixedwing data from keyboard
            Console.WriteLine("\n===== Create a Fixedwing Airplane =====");

            Console.WriteLine("Fixedwing ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Fixedwing Model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Fixedwing Cruise Speed: ");
            double cruiseSpeed = InputHelper.InputDouble();

            Console.WriteLine("Fixedwing Empty Weight: ");
            double emptyWeight = InputHelper.InputDouble();

            Console.WriteLine("Fixedwing Cruise Speed: ");
            double maxTakeoffWeight = InputHelper.InputDouble();

            Console.WriteLine("Fixedwing Plane Type: ");
            string planeType = Console.ReadLine();

            Console.WriteLine("Fixedwing Min Needed Runway Size: ");
            double minRunwaySize = InputHelper.InputDouble();

            // Create a new Fixedwing object
            Fixedwing newFixedwing = new Fixedwing()
            {
                ID = id,
                Model = model,
                CruiseSpeed = cruiseSpeed,
                EmptyWeight = emptyWeight,
                MaxTakeoffWeight = maxTakeoffWeight,
                PlaneType = planeType,
                MinRunwaySize = minRunwaySize
            };

            return newFixedwing;
        }

        internal void ShowMenu(List<Airport> Airports)
        {
            string menuTitle = "Fixedwing Management";
            var menuItems = new List<string>(){
                "Add new Fixedwing",
                "Remove a Fixedwing",
                "Add Fixedwing to an Airport",
                "Remove Fixedwing from an Airport",
                "Display list of all Fixedwings",
            };

            int choice = InputHelper.CreateMenu(menuTitle, menuItems);

            switch (choice)
            {
                case 1:
                    // Add new Fixedwing
                    Fixedwings.Add(Create());
                    break;
                case 2:
                    // Remove an Fixedwing
                    Remove();
                    break;
                case 3:
                    // Add Fixedwing to the Airport
                    AddFixedwingToAirport(Airports);
                    break;
                case 4:
                    // Remove Fixedwing from the Airport
                    RemoveFixedwingFromAirport(Airports);
                    break;
                case 5:
                    // Display list of all Fixedwings
                    ShowListFixedwing();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void Remove()
        {
            // Display list of Fixedwings to choose from
            string Title = "List of Fixedwings: ";
            var Items = new List<string>();
            Fixedwings.ForEach(a => Items.Add(a.ID + " - " + a.Model));

            int choiceFixedwing = InputHelper.ShowItem(Title, Items);

            // Get the selected Fixedwing
            Fixedwing selectedFixedwing = Fixedwings[choiceFixedwing - 1];

            // Remove the selected Fixedwing from the list
            Fixedwings.RemoveAt(choiceFixedwing - 1);

            Console.WriteLine($"The Fixedwing '{selectedFixedwing.ID}' has been removed.");
        }

        private void AddFixedwingToAirport(List<Airport> Airports)
        {
            bool success;
            do
            {
                success = true;

                // Display list of Fixedwings to choose from
                string Title = "List of Fixedwings: ";
                var Items = new List<string>();
                Fixedwings.ForEach(a => Items.Add(a.ID + " - " + a.Model));

                int choiceFixedwing = InputHelper.ShowItem(Title, Items);

                // Get the selected Fixedwing
                Fixedwing selectedFixedwing = Fixedwings[choiceFixedwing - 1];

                // Check if the selected Fixedwing is already in another Airport
                foreach (var Airport in Airports)
                {
                    if (Airport.ListFixedwingID.Contains(selectedFixedwing.ID))
                    {
                        success = false;
                        Console.WriteLine("The selected Fixedwing is already in another Airport. Remove it from that Airport first.");
                        return;
                    }
                }

                // Check if there are Airports that can accommodate the selected Fixedwing
                var validToAddAirports = Airports.Where(x =>
                    x.ListFixedwingID.Count < x.MaxFixedwingParking && x.RunwaySize > selectedFixedwing.MinRunwaySize).ToList();

                // Check if there are any valid Airports
                if (validToAddAirports.Count == 0)
                {
                    success = false;
                    Console.WriteLine("There are no Airports that can accommodate the selected Fixedwing.");
                    return;
                }

                // Display list of valid Airports to choose from
                string Title1 = "List of Airports: ";
                var Items1 = new List<string>();
                Airports.ForEach(a => Items1.Add(a.ID + " - " + a.Name));

                int choiceAirport = InputHelper.ShowItem(Title1, Items1);

                // Get the selected Airport
                Airport selectedAirport = validToAddAirports[choiceAirport - 1];

                // Add the selected Fixedwing to the selected Airport
                selectedAirport.ListFixedwingID.Add(selectedFixedwing.ID);
                Console.WriteLine($"The Fixedwing '{selectedFixedwing.Model}' has been added to Airport '{selectedAirport.Name}'.");
            } while (success == true);
        }

        private void RemoveFixedwingFromAirport(List<Airport> Airports)
        {
            bool success;
            do
            {
                success = true;

                /// Display list of Airports to choose from
                string Title = "List of Airports: ";
                var Items = new List<string>();
                Airports.ForEach(a => Items.Add(a.ID + " - " + a.Name));

                int choiceAirport = InputHelper.ShowItem(Title, Items);

                // Get the selected Airport
                Airport selectedAirport = Airports[choiceAirport - 1];

                // Check if the Airport has any Fixedwings
                if (selectedAirport.ListFixedwingID.Count == 0)
                {
                    success = false;
                    Console.WriteLine("The selected Airport does not have any Fixedwings.");
                    return;
                }

                // Display list of valid Fixedwings to choose from
                string Title1 = $"List of Fixedwings in {selectedAirport.Name}: ";
                var Items1 = new List<string>();
                selectedAirport.ListFixedwingID.ForEach(a => Items1.Add(a));

                int choiceFixedwing = InputHelper.ShowItem(Title1, Items1);

                // Get the selected Fixedwing ID
                string selectedFixedwingID = selectedAirport.ListFixedwingID[choiceFixedwing - 1];

                // Remove the selected Fixedwing from the selected Airport
                selectedAirport.ListFixedwingID.Remove(selectedFixedwingID);
                Console.WriteLine("The selected Fixedwing has been removed from the Airport.");
            } while (success == true);
        }

        private void ShowListFixedwing()
        {
            // Display list of Fixedwings
            System.Console.WriteLine("\n===== List of all Fixedwings =====");
            if (Fixedwings.Count == 0)
            {
                System.Console.WriteLine("No Fixedwings found.");
            }
            else
            {
                System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}{6, 10}",
                    "ID", "Model", "Cruise Speed", "Empty Weight", "Max Takeoff Weight", "Plane Type", "Min Needed Runway Size"));
                foreach (var Fixedwing in Fixedwings)
                {
                    System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}{6, 10}",
                    Fixedwing.ID, Fixedwing.Model, Fixedwing.CruiseSpeed, Fixedwing.EmptyWeight, Fixedwing.MaxTakeoffWeight,
                    Fixedwing.PlaneType, Fixedwing.MinRunwaySize));
                }
            }
        }
    }
}

