namespace PowerPlant.Domain
{
    public class WindTurbinePowerPlant : PowerPlant
    {
        public float WindStrength { get; set; }

        protected override float MaximumLoad => ProductionBoundaries.Maximum * WindStrength / 100;

        internal WindTurbinePowerPlant(string name, Efficiency efficiency, PowerRange productionBoundaries, float windStrength)
            : base(name, efficiency, productionBoundaries)
        {
            WindStrength = windStrength;
        }

        public override float ComputePricePerMWh()
        {
            return 0f;
        }
    }
}
