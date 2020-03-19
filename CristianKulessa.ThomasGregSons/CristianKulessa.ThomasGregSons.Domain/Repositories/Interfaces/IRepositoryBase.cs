using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Select();
        TEntity Select(int id);
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
