using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Shopbridge_Context dbcontext;
        private readonly DbSet<T> table = null;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
            table = _dbcontext.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.SingleOrDefault(s => s.Id == id);
        }

        public T Insert(T entity)
        {

            table.Add(entity);
            dbcontext.SaveChanges();
            int insertedId = table.Max(x => x.Id);
            var inserted = table.SingleOrDefault(x => x.Id == insertedId);

            return inserted;
        }

        public T Update(int id, T entity)
        {
            table.Attach(entity);
            dbcontext.Entry(entity).State = EntityState.Modified;
            dbcontext.SaveChanges();

            return GetById(id);
        }

        public T Delete(int id)
        {
            T existingEntity = GetById(id);
            if (existingEntity == null)
                return null;
            table.Remove(existingEntity);
            dbcontext.SaveChanges();
            return existingEntity;
        }
    }
}
