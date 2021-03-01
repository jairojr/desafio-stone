using Stone.Clientes.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Application.Interfaces
{
    /// <summary>
    /// Cliente application
    /// </summary>
    public interface IClienteApplication
    {
        /// <summary>
        /// Criar 
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ClienteViewModel> CriarAsync(ClienteViewModel clienteViewModel, CancellationToken cancellationToken);
        
        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ClienteViewModel> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken);

        /// <summary>
        /// Obter por CPF
        /// </summary>
        /// <param name="cpfPesquisa"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ClienteViewModel> ObterPorCpfAsync(long cpfPesquisa, CancellationToken cancellationToken);
        
        /// <summary>
        /// Busca por cliente paginado
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="tamanho"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<ClienteViewModel>> BuscaPaginadaAsync(int pagina, int tamanho, CancellationToken cancellationToken);
    }
}