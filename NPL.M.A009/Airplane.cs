namespace NPL.M.A009
{
    public abstract class Airplane
    {
        public string? ID { get; set; }

        public string? Model { get; set; }

        public double CruiseSpeed { get; set; }

        public double EmptyWeight { get; set; }

        public double MaxTakeoffWeight { get; set; }

        public abstract void Fly();
    }
}
