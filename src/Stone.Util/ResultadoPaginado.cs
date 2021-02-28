using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Utils
{
    /// <summary>
    /// Resultado paginado
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultadoPaginado<T>
    {
        private string next;

        /// <summary>
        /// Página
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Quantidade de registros a retornar
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Dados retornados
        /// </summary>
        public T[] Data { get; set; }

        /// <summary>
        /// Url da proxima pagina. Caso não exista proxima página, retorna null.
        /// </summary>
        public string Next
        {
            get
            {
                if (this.Data.Length == this.Size)
                    return next;

                return null;
            }
            set => next = value;
        }


    }
}
