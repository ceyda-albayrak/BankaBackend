using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationLayer.Utilities.Results;

namespace OperationLayer.Abstract
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        DataResult<T> Get(string id);
        Result Add(T entity);
        Result Update(T entity);
        Result Delete(T entity);
    }
}
