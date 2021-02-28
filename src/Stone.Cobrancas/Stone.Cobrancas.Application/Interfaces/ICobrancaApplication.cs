using Stone.Cobrancas.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Application.Interfaces
{
    public interface ICobrancaApplication
    {
        public Task<CobrancaViewModel> CriarAsync(CobrancaViewModel cliente, CancellationToken cancellationToken);
        public Task<IEnumerable<CobrancaViewModel>> BuscaPaginadaAsync(int pagina, int tamanho, CancellationToken cancellationToken);
    }
}
