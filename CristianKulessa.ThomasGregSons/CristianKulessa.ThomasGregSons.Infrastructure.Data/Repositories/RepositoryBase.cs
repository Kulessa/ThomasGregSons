using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DefaultSqlServerContext context;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryBase(DefaultSqlServerContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public virtual void Delete(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual bool Exists(int id)
        {
            return dbSet.Find(id) != null;
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual IQueryable<TEntity> Select()
        {
            return dbSet;
        }

        public virtual TEntity Select(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
        public virtual void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = dbSet.Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
