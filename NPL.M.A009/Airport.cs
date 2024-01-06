namespace NPL.M.A009
{
    public class Airport
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public double RunwaySize { get; set; }
        public int MaxFixedwingParking { get; set; }
        public List<string> ListFixedwingID { get; set; }
        public int MaxHelicopterParking { get; set; }
        public List<string> ListHelicopterID { get; set; }

        public Airport(string id, string name, double runwaySize, int maxFixedwingParking, List<string> listFixedwingID, int maxHelicopterParking, List<string> listHelicopterID)
        {
            ID = id;
            Name = name;
            RunwaySize = runwaySize;
            MaxFixedwingParking = maxFixedwingParking;
            ListFixedwingID = listFixedwingID;
            MaxHelicopterParking = maxHelicopterParking;
            ListHelicopterID = listHelicopterID;
        }

        public Airport(string? id, string? name, double runwaySize, int maxFixedwingParking, int maxHelicopterParking)
        {
            ID = id;
            Name = name;
            RunwaySize = runwaySize;
            MaxFixedwingParking = maxFixedwingParking;
            MaxHelicopterParking = maxHelicopterParking;
        }
    }
}
