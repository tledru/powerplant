using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    internal class LoadTooHighException : Exception
    {
        public LoadTooHighException():base("This set of power plants cannot handle the requested load")
        {
        }
    }
}
