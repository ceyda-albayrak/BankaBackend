using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLayer.Utilities.Results
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult(T data,string message): base(data,true,message)
        {
            
        }
    }
}
