using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    public class ErrorModel
    {
        public ErrorModel(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public string Codigo { get; set; }
        public string Mensagem { get; set; }

    }
}
