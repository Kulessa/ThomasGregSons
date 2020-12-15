using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Domain.Services.Interfaces;

namespace CristianKulessa.ThomasGregSons.Domain.Services
{
    public class LogradouroService : ServiceBase<Logradouro>, ILogradouroService
    {
        private readonly ILogradouroRepository repository;

        public LogradouroService(ILogradouroRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public Logradouro Select(int clienteId, int id)
        {
            return repository.Select(clienteId, id);
        }

    }
}
