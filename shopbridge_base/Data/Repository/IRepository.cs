using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int id);
        T Insert(T entity);
        T Update(int id, T entity);
        T Delete(int id);

    }
}
