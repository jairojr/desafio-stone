using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Utils
{
    public class MultiplaValidacaoException : ValidacaoException
    {
        public readonly List<ValidacaoException> Validacoes;

        public MultiplaValidacaoException(List<ValidacaoException> validacoes)
        {
            this.Validacoes = validacoes;
        }
    }
}
