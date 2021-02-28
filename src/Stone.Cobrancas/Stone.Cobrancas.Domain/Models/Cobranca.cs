using System;
using System.Collections.Generic;
using System.Text;
using static Stone.Utils.CpfExtensions;

namespace Stone.Cobrancas.Domain.Models
{
    public class Cobranca
    {
        public Guid Id { get; set; }
        public DateTimeOffset Data { get; private set; }
        public Cpf CPF { get; private set; }
        public decimal Valor { get; private set; }

        public Cobranca(Guid id, DateTimeOffset data, Cpf cPF, decimal valor)
        {
            Id = id;
            Data = data;
            CPF = cPF;
            Valor = valor;
        }

        public Cobranca(DateTimeOffset data, Cpf cPF, decimal valor) : this(Guid.NewGuid(), data, cPF, valor)
        {
        }

        public static Cobranca CriarCobranca(Cpf cPF)
        {
            var strCpf = cPF.ObterComMascara();

            string valor = $"{strCpf[0]}{strCpf[1]}{strCpf[13]}{strCpf[14]}";

            return new Cobranca(DateTime.Now, cPF, Convert.ToDecimal(valor));
        }
    }
}