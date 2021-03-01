using FluentValidation.Results;
using System.Collections.Generic;

namespace Stone.Utils
{
    /// <summary>
    /// Service operations
    /// </summary>
    public static class ServiceOperation
    {
        /// <summary>
        /// Throw erros de validação
        /// </summary>
        /// <param name="result"></param>
        public static void ThrowErrosValidacao(this ValidationResult result)
        {
            var validations = new List<ValidacaoException>();
            foreach (var falha in result.Errors)
            {
                validations.Add(new ValidacaoException(falha.ErrorCode, falha.ErrorMessage));
            }
            throw new MultiplaValidacaoException(validations);
        }
    }
}
