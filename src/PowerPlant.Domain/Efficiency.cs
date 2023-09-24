using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public class Efficiency
    {
        public float Value { get; }

        public Efficiency(float value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 0f, 1f);
            Value = value;
        }
    }
}
