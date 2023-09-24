namespace PowerPlant.Domain
{
    public class GasFiredPowerPlant : PowerPlant
    {
        public float GasPrice { get; set; }

        protected override float MaximumLoad => ProductionBoundaries.Maximum;

        internal GasFiredPowerPlant(string name, Efficiency efficiency, PowerRange productionBoundaries, float gasPrice)
            : base(name, efficiency, productionBoundaries)
        {
            GasPrice = gasPrice;
        }

        public override float ComputePricePerMWh()
        {
            return GasPrice / Efficiency.Value;
        }
    }
}
