using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Data.Models
{
    public class ClienteEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Estado { get; private set; }
        public long CPF { get; private set; }

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
    }
}
