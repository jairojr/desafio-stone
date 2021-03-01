using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Integration.Tests.Models
{
    public class BuscaCobrancasDTO
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public CobrancaDTO[] Data { get; set; }
        public string Next { get; set; }
    }
}
