﻿using System;
using System.Linq;

namespace CristianKulessa.ThomasGregSons.Domain.Services.Interfaces
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Select();
        TEntity Select(int id);
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
