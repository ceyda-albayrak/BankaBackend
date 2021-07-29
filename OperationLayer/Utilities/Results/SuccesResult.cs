using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OperationLayer.Utilities.Results
{
    public class SuccesResult : Result
    {
        public SuccesResult(string message):base(true,message)
        {
            
        }

    }
}
