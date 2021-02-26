using Stone.Clientes.Application.Enums;

namespace Stone.Clientes.Application.ViewModel
{
    /// <summary>
    /// Cliente
    /// </summary>
    public class ClienteViewModel
    {

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Estado 
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// CPF, com ou sem mascara .
        /// </summary>
        public string CPF { get; set; }
    }
}
