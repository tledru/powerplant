using System.Diagnostics.CodeAnalysis;

namespace PowerPlant.Domain
{
    internal class PowerPlantCostComparer : IComparer<PowerPlant>
    {
        public int Compare(PowerPlant? x, PowerPlant? y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var xCost = x.ComputePricePerMWh();
            var yCost = y.ComputePricePerMWh();
            if (xCost < yCost) { return -1; }
            if (yCost < xCost) {  return 2; }
            return 1;
        }
    }
}
