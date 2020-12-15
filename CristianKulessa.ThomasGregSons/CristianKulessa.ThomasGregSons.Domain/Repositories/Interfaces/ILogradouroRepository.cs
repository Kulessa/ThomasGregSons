using CristianKulessa.ThomasGregSons.Domain.Entities;

namespace CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces
{
    public interface ILogradouroRepository : IRepositoryBase<Logradouro>
    {
        Logradouro Select(int clienteId, int id);
    }
}
