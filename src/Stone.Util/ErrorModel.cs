using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="mensagem"></param>
        public ErrorModel(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Codigo { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Mensagem { get; set; }

    }
}
