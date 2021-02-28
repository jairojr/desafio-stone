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
            return CriarCobranca(cPF, DateTime.Now);
        }

        public static Cobranca CriarCobranca(Cpf cPF, DateTime data)
        {
            var strCpf = cPF.ObterComMascara();

            strCpf = strCpf.Remove(2, strCpf.Length - 4);

            string valor = strCpf;

            return new Cobranca(data, cPF, Convert.ToDecimal(valor));
        }
    }
}