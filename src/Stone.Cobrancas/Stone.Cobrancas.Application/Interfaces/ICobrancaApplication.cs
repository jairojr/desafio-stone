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
        /// <param name="cobranca"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<CobrancaViewModel> CriarAsync(CobrancaViewModel cobranca, CancellationToken cancellationToken);
        
        /// <summary>
        /// Buscar paginado
        /// </summary>
        /// <param name="busca"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<CobrancaViewModel>> BuscarAsync(BuscarCobrancaViewModel busca, CancellationToken cancellationToken);
    }
}
