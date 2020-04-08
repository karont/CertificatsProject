using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesProject
{
    
    static class ParameterSingleton
    {
        private static Parameters parameters;

        public static Parameters Parameters { get
            { if (parameters == null)
                {
                    parameters = new Parameters();
                }
                return parameters;
            }
        }


    }
}
