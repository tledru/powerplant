namespace PowerPlant.Host.Requests
{
    public class ComputeProductionPlanRequest
    {
        public int Load { get; set; }
        public FuelContext? Fuels { get; set; }
        public PowerPlant[]? PowerPlants { get; set; }
    }
}
