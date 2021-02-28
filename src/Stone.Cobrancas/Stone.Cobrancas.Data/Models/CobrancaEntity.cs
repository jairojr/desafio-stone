using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Data.Models
{
    public class CobrancaEntity
    {      
        public Guid Id { get; private set; }
        public DateTimeOffset Data { get; private set; }
        public long CPF { get; private set; }
        public decimal Valor { get; private set; }

        public CobrancaEntity(Guid id, DateTimeOffset data, long cPF, decimal valor)
        {
            Id = id;
            Data = data;
            CPF = cPF;
            Valor = valor;
        }
    }
}