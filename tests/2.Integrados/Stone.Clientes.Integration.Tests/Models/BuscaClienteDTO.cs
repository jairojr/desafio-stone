using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Clientes.Integration.Tests.Models
{
    public class BuscaClienteDTO
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public ClienteDTO[] Data { get; set; }
        public string Next { get; set; }
    }
}
