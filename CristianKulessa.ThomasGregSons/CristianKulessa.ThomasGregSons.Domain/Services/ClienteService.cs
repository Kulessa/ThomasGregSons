using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Domain.Services.Interfaces;

namespace CristianKulessa.ThomasGregSons.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository repository;

        public ClienteService(IClienteRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
