using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Data.Models
{
    public class ClienteEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public long CPF { get; set; }

        public ClienteEntity()
        {

        }

        public ClienteEntity(Guid id, string nome, string estado, long cPF)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            CPF = cPF;
        }

        public ClienteEntity(string nome, string estado, long cPF)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Estado = estado;
            CPF = cPF;
        }
    }
}
