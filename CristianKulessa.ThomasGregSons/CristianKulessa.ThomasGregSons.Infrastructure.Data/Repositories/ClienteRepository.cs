using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Infrastructure.Data.Context;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DefaultSqlServerContext context) : base(context) { }
        public override void Update(Cliente entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
