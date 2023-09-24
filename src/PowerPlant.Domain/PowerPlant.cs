namespace PowerPlant.Domain
{
    public abstract class PowerPlant
    {
        public string Name { get;  }
        public Efficiency Efficiency { get;  }
        public PowerRange ProductionBoundaries { get; }
        protected abstract float MaximumLoad { get; }

        protected PowerPlant(string name, Efficiency efficiency, PowerRange productionBoundaries)
        {
            Name = name;
            Efficiency = efficiency;
            ProductionBoundaries = productionBoundaries;
        }

        public PowerPlantProduction ComputeProduction(float load, int minimumRemainingLoadIfNotZero)
        {
            if (load == 0)
            {
                return new PowerPlantProduction(Name, 0);
            }
            if (load < ProductionBoundaries.Minimum)
            {
                throw new LoadTooLowException();
            }
            if (load > MaximumLoad)
            {
                if (load < MaximumLoad + minimumRemainingLoadIfNotZero)
                {
                    return new PowerPlantProduction(Name, load - minimumRemainingLoadIfNotZero);
                }
                return new PowerPlantProduction(Name, MaximumLoad);
            }
            return new PowerPlantProduction(Name, load);
        }

        public abstract float ComputePricePerMWh();

        public static PowerPlant Create(string name, Efficiency efficiency, PowerRange productionBoundaries, string type, FuelContext context) 
        {
            return type switch
            {
                "gasfired" => new GasFiredPowerPlant(name, efficiency, productionBoundaries, context.GasPrice),
                "turbojet" => new TurboJetPowerPlant(name, efficiency, productionBoundaries, context.KerosinePrice),
                "windturbine" => new WindTurbinePowerPlant(name, efficiency, productionBoundaries, context.WindStrength),
                _ => throw new ArgumentOutOfRangeException($"Invalid power plant type: {type}")
            };
        }
    }
}