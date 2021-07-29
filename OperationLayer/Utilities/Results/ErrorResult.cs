﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLayer.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool success,string message): base(false,message)
        {
            
        }
    }
}
