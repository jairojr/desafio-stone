using System;
using System.Collections.Generic;
using System.Text;
using static Stone.Utils.CpfExtensions;

namespace Stone.Cobrancas.Domain.ValueObjects
{
    public class BuscarCobrancaValueObject
    {
        public int Pagina { get; set; }
        public int Quantidade { get; set; }
        public Cpf? CPF { get; set; }
        public int? Ano { get; set; }
        public int? Mes { get; set; }
        public BuscarCobrancaValueObject(int Pagina, int Quantidade, Cpf? CPF = null, int? Ano = null, int? Mes = null)
        {
            this.Pagina = Pagina;
            this.Quantidade = Quantidade;
            this.CPF = CPF;
            this.Ano = Ano;
            this.Mes = Mes;
        }
    }
}