using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;

namespace EntityLayer.EntityFramework.Abstract
{
    public interface IEntityRepository<T> where T : class, new()

    {
    Task<List<T>> GetAll();
    T Get(Expression<Func<T, bool>> filter);
    Task Add(T entity);
    Task Update(T entity);
    void Delete(T entity);
  
    }
}
