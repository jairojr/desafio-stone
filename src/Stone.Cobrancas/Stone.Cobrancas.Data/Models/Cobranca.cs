using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Data.Models
{
    public class Cobranca
    {
        public Guid Id { get; set; }
        public DateTimeOffset Data { get; private set; }
        public long CPF { get; private set; }
        public decimal Valor { get; private set; }

    }
}