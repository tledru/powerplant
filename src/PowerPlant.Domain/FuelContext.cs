using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public class FuelContext
    {
        public FuelContext(float gasPrice, float kerosinePrice, float co2Price, float windStrength)
        {
            GasPrice = gasPrice;
            KerosinePrice = kerosinePrice;
            Co2Price = co2Price;
            WindStrength = windStrength;
        }

        public float GasPrice { get; }
        public float KerosinePrice { get; }
        public float Co2Price { get;  }
        public float WindStrength { get; }
    }
}
