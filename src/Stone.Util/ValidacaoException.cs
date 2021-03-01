using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidacaoException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="mensagem"></param>
        public ValidacaoException(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        /// <summary>
        /// 
        /// </summary>
        protected ValidacaoException()
        {

        }

        public string Codigo { get; set; }
        public string Mensagem { get; set; }


    }
}
