using Stone.Clientes.Domain.Enums;
using System;
using static Stone.Utils.CpfExtensions;

namespace Stone.Clientes.Domain.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }

        public EstadoEnum Estado { get; private set; }

        public Cpf CPF { get; private set; }


        #region Construtores

        public Cliente(string nome, EstadoEnum estado, string cPF)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Estado = estado;
            CPF = cPF;
        }

        public Cliente(string nome, EstadoEnum estado, long cPF) : this(nome, estado, cPF.ToString())
        {
        }

        public Cliente(Guid id, string nome, EstadoEnum estado, string cPF)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            CPF = cPF;
        }

        public Cliente(Guid id, string nome, EstadoEnum estado, long cPF) : this(id, nome, estado, cPF.ToString())
        {
        }

        #endregion Construtores
    }
}
