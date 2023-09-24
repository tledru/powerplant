using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Domain
{
    public class LoadTooHighException : BusinessException
    {
        public LoadTooHighException():base("This set of power plants cannot handle the requested load")
        {
        }
    }
}
