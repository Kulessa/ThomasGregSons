using CristianKulessa.ThomasGregSons.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces
{
    public interface ILogradouroRepository : IRepositoryBase<Logradouro>
    {
        Logradouro Select(int clienteId, int id);
    }
}
