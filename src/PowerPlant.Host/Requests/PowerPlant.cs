namespace PowerPlant.Host.Requests
{
    public class PowerPlant
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public float Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }
    }
}
