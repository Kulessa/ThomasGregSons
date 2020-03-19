using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Repositories
{
    public class LogradouroRepository : RepositoryBase<Logradouro>, ILogradouroRepository
    {
        public LogradouroRepository(DefaultSqlServerContext context) : base(context) { }
        public override void Update(Logradouro entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
        public Logradouro Select(int clienteId, int id)
        {
            return dbSet.FirstOrDefault(e => e.ClienteId == clienteId && e.Id == id);
        }
    }
}
