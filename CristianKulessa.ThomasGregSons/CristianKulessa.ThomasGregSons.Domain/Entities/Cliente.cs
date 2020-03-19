using System;
using System.Collections.Generic;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        //public IList<Logradouro> Logradouros { get; set; }
    }
}
