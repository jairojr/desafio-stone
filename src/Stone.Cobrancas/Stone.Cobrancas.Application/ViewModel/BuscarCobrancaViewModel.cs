using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Application.ViewModel
{
    /// <summary>
    /// Busca de cobranças
    /// </summary>
    public class BuscarCobrancaViewModel
    {
        /// <summary>
        /// Págna
        /// </summary>
        public int Pagina { get; set; } = 0;

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantidade { get; set; } = 10;

        /// <summary>
        /// CPF
        /// </summary>
        public string CPF { get; set; } = null;

        /// <summary>
        /// Ano
        /// </summary>
        public int? Ano { get; set; } = null;

        /// <summary>
        /// Mês
        /// </summary>
        public int? Mes { get; set; } = null;
    }
}