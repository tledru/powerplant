using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    internal class LoadTooLowException : Exception
    {
        public LoadTooLowException() 
            : base("The load is too low for the power plant") 
        { }
    }
}
