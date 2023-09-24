namespace PowerPlant.Domain
{
    public class PowerPlantProduction
    {
        public PowerPlantProduction(string name, float production)
        {
            Name = name;
            Production = production;
        }

        public string Name { get;  }
        public float Production { get;  }
    }
}
