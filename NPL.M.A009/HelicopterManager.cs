namespace NPL.M.A009
{
    public class HelicopterManager
    {
        // Airbus A380, Boeing 787, Airbus A350, Boeing 777
        public List<Helicopter> Helicopters = new List<Helicopter>();

        public Helicopter Create()
        {
            // Input Helicopter data from keyboard
            Console.WriteLine("\n===== Create a Helicopter Airplane =====");

            Console.WriteLine("Helicopter ID: ");
            string id = Console.ReadLine();

            Console.WriteLine("Helicopter Model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Helicopter Cruise Speed: ");
            double cruiseSpeed = InputHelper.InputDouble();

            Console.WriteLine("Helicopter Empty Weight: ");
            double emptyWeight = InputHelper.InputDouble();

            Console.WriteLine("Helicopter Cruise Speed: ");
            double maxTakeoffWeight = InputHelper.InputDouble();

            Console.WriteLine("Helicopter Range: ");
            double range = InputHelper.InputDouble();

            // Create a new Helicopter object
            Helicopter newHelicopter = new Helicopter()
            {
                ID = id,
                Model = model,
                CruiseSpeed = cruiseSpeed,
                EmptyWeight = emptyWeight,
                MaxTakeoffWeight = maxTakeoffWeight,
                Range = range
            };

            return newHelicopter;
        }

        internal void ShowMenu(List<Airport> Airports)
        {
            string menuTitle = "Helicopter Management";
            var menuItems = new List<string>(){
                "Add new Helicopter",
                "Remove a Helicopter",
                "Add Helicopter to an Airport",
                "Remove Helicopter from an Airport",
                "Display list of all Helicopters",
            };

            int choice = InputHelper.CreateMenu(menuTitle, menuItems);

            switch (choice)
            {
                case 1:
                    // Add new Helicopter
                    Helicopters.Add(Create());
                    break;
                case 2:
                    // Remove an Helicopter
                    Remove();
                    break;
                case 3:
                    // Add Helicopter to the Airport
                    AddHelicopterToAirport(Airports);
                    break;
                case 4:
                    // Remove Helicopter from the Airport
                    RemoveHelicopterFromAirport(Airports);
                    break;
                case 5:
                    // Display list of all Helicopters
                    ShowListHelicopter();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void Remove()
        {
            // Display list of Helicopters to choose from
            string Title = "List of Helicopters: ";
            var Items = new List<string>();
            Helicopters.ForEach(a => Items.Add(a.ID + " - " + a.Model));

            int choiceHelicopter = InputHelper.ShowItem(Title, Items);

            // Get the selected Helicopter
            Helicopter selectedHelicopter = Helicopters[choiceHelicopter - 1];

            // Remove the selected Helicopter from the list
            Helicopters.RemoveAt(choiceHelicopter - 1);

            Console.WriteLine($"The Helicopter '{selectedHelicopter.ID}' has been removed.");
        }

        private void AddHelicopterToAirport(List<Airport> Airports)
        {
            bool success;
            do
            {
                success = true;

                // Display list of Helicopters to choose from
                string Title = "List of Helicopters: ";
                var Items = new List<string>();
                Helicopters.ForEach(a => Items.Add(a.ID + " - " + a.Model));

                int choiceHelicopter = InputHelper.ShowItem(Title, Items);

                // Get the selected Helicopter
                Helicopter selectedHelicopter = Helicopters[choiceHelicopter - 1];

                // Check if the selected Helicopter is already in another Airport
                foreach (var Airport in Airports)
                {
                    if (Airport.ListHelicopterID.Contains(selectedHelicopter.ID))
                    {
                        success = false;
                        Console.WriteLine("The selected Helicopter is already in another Airport. Remove it from that Airport first.");
                        return;
                    }
                }

                // Check if there are Airports that can accommodate the selected Helicopter
                var validToAddAirports = Airports.Where(x =>
                    x.ListHelicopterID.Count < x.MaxHelicopterParking).ToList();

                // Check if there are any valid Airports
                if (validToAddAirports.Count == 0)
                {
                    success = false;
                    Console.WriteLine("There are no Airports that can accommodate the selected Helicopter.");
                    return;
                }

                // Display list of valid Airports to choose from
                string Title1 = "List of Airports: ";
                var Items1 = new List<string>();
                Airports.ForEach(a => Items1.Add(a.ID + " - " + a.Name));

                int choiceAirport = InputHelper.ShowItem(Title1, Items1);

                // Get the selected Airport
                Airport selectedAirport = validToAddAirports[choiceAirport - 1];

                // Add the selected Helicopter to the selected Airport
                selectedAirport.ListHelicopterID.Add(selectedHelicopter.ID);
                Console.WriteLine($"The Helicopter '{selectedHelicopter.Model}' has been added to Airport '{selectedAirport.Name}'.");
            } while (success == true);
        }

        private void RemoveHelicopterFromAirport(List<Airport> Airports)
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

                // Check if the Airport has any Helicopters
                if (selectedAirport.ListHelicopterID.Count == 0)
                {
                    success = false;
                    Console.WriteLine("The selected Airport does not have any Helicopters.");
                    return;
                }

                // Display list of valid Helicopters to choose from
                string Title1 = $"List of Helicopters in {selectedAirport.Name}: ";
                var Items1 = new List<string>();
                selectedAirport.ListHelicopterID.ForEach(a => Items1.Add(a));

                int choiceHelicopter = InputHelper.ShowItem(Title1, Items1);

                // Get the selected Helicopter ID
                string selectedHelicopterID = selectedAirport.ListHelicopterID[choiceHelicopter - 1];

                // Remove the selected Helicopter from the selected Airport
                selectedAirport.ListHelicopterID.Remove(selectedHelicopterID);
                Console.WriteLine("The selected Helicopter has been removed from the Airport.");
            } while (success == true);
        }

        private void ShowListHelicopter()
        {
            // Display list of Helicopters
            System.Console.WriteLine("\n===== List of all Helicopters =====");
            if (Helicopters.Count == 0)
            {
                System.Console.WriteLine("No Helicopters found.");
            }
            else
            {
                System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}",
                    "ID", "Model", "Cruise Speed", "Empty Weight", "Max Takeoff Weight", "Range"));
                foreach (var Helicopter in Helicopters)
                {
                    System.Console.WriteLine(string.Format("{0, 10}{1, 10}{2, 10}{3, 10}{4, 10}{5, 10}",
                    Helicopter.ID, Helicopter.Model, Helicopter.CruiseSpeed, Helicopter.EmptyWeight, Helicopter.MaxTakeoffWeight,
                    Helicopter.Range));
                }
            }
        }
    }
}

