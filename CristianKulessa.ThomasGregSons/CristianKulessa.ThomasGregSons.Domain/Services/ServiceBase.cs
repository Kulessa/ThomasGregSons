using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Domain.Services.Interfaces;
using System;
using System.Linq;

namespace CristianKulessa.ThomasGregSons.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exists(int id)
        {
            return repository.Exists(id);
        }

        public void Insert(TEntity entity)
        {
            repository.Insert(entity);
        }

        public IQueryable<TEntity> Select()
        {
            return repository.Select();
        }

        public TEntity Select(int id)
        {
            return repository.Select(id);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }
}
