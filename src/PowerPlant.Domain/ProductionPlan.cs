namespace PowerPlant.Domain
{
    public class ProductionPlan
    {
        private SortedSet<PowerPlant> Items { get; } = new SortedSet<PowerPlant>(new PowerPlantCostComparer());

        public void Add(PowerPlant powerPlant)
        {
            Items.Add(powerPlant);
        }

        public IEnumerable<PowerPlantProduction> Compute(float load)
        {
            var array = Items.ToArray();
            for (int i = 0; i < array.Length - 1; i++)
            {
                var powerPlantProduction = array[i].ComputeProduction(load, array[i + 1].ProductionBoundaries.Minimum);
                yield return powerPlantProduction;
                load -= powerPlantProduction.Production;
            }
            var lastPowerPlantProduction = array.Last().ComputeProduction(load, 0);
            yield return lastPowerPlantProduction;
            if (load > 0)
            {
                throw new LoadTooHighException();
            }
        }
    }
}
