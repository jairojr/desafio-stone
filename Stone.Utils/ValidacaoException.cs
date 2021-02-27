using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        protected ValidacaoException()
        {

        }

        public string Codigo { get; set; }
        public string Mensagem { get; set; }


    }
}
