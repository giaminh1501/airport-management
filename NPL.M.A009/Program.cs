namespace NPL.M.A009;

public class Program
{
    static List<Airport> airports = new();
    static List<Fixedwing> fixedWing = new();
    static List<Helicopter> helicopters = new();

    public static void Main(string[] args)
    {
        AirportManager AirportManager = new AirportManager();
        FixedwingManager FixedwingManager = new FixedwingManager();
        HelicopterManager HelicopterManager = new HelicopterManager();

        string menuTitle = "Airport Management System";
        var menuItems = new List<string>()
            {
                "Airport management",
                "Fixed wing airplane management",
                "Helicopter management",
                "Close program"
            };

        int choice = InputHelper.CreateMenu(menuTitle, menuItems);

        switch (choice)
        {
            case 1:
                // Add airport to the list => Done
                // Remove airport from the list
                AirportManager.ShowMenu();
                break;
            case 2:
                // Add fixed wing airplane to the list => Done
                // Remove fixed wing airplane from the list
                // Add fixed wing airplane to the airport
                // Remove fixed wing airplane from the airport
                FixedwingManager.ShowMenu(AirportManager.airports);
                break;
            case 3:
                // Add helicopter to the list => Done
                // Remove helicopter from the list
                // Add helicopter to the airport
                // Remove helicopter from the airport
                HelicopterManager.ShowMenu(AirportManager.airports);
                break;
            case 4:
                Environment.Exit(0);
                break;
        }
    }
}
