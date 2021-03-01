using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Application.Interfaces
{
    /// <summary>
    /// Cobrança application
    /// </summary>
    public interface ICobrancaApplication
    {
        /// <summary>
        /// Criar
        /// </summary>
        /// <param name="cobrancaVewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CobrancaViewModel> CriarAsync(CobrancaViewModel cobrancaVewModel, CancellationToken cancellationToken);

        /// <summary>
        /// Buscar paginado
        /// </summary>
        /// <param name="buscaViewModel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<CobrancaViewModel>> BuscarAsync(BuscarCobrancaViewModel buscaViewModel, CancellationToken cancellationToken);
    }
}
