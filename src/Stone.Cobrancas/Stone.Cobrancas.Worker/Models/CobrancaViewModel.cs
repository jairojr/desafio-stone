using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Cobrancas.Worker.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CobrancaViewModel
    {
        /// <summary>
        /// Data da cobrança
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// CPF da cobrança
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Valor da cobrança
        /// </summary>
        public decimal Valor { get; set; }
    }
}