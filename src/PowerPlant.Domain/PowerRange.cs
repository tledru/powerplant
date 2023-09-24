using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public class PowerRange
    {
        public int Minimum { get; }
        public int Maximum { get; }
        public PowerRange(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
