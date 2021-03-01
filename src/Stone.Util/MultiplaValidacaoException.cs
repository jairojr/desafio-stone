using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiplaValidacaoException : ValidacaoException
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly List<ValidacaoException> Validacoes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validacoes"></param>
        public MultiplaValidacaoException(List<ValidacaoException> validacoes)
        {
            this.Validacoes = validacoes;
        }
    }
}
