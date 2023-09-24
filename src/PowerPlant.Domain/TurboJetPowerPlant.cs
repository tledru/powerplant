using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public class TurboJetPowerPlant : PowerPlant
    {
        public float KerosinePrice { get; }

        protected override float MaximumLoad => ProductionBoundaries.Maximum;

        internal TurboJetPowerPlant(string name, Efficiency efficiency, PowerRange productionBoundaries, float kerosinePrice)
            : base(name, efficiency, productionBoundaries)
        {
            KerosinePrice = kerosinePrice;
        }

        public override float ComputePricePerMWh()
        {
            return KerosinePrice / Efficiency.Value;
        }
    }
}
