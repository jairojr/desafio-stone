using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.ViewModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Application
{
    public class CobrancaApplication : ICobrancaApplication
    {
        public Task<IEnumerable<CobrancaViewModel>> BuscaPaginadaAsync(int pagina, int tamanho, CancellationToken cancellationToken)
        {
            ///TODO - Implementar
            throw new System.NotImplementedException();
        }

        public Task<CobrancaViewModel> CriarAsync(CobrancaViewModel cliente, CancellationToken cancellationToken)
        {
            ///TODO - Implementar
            throw new System.NotImplementedException();
        }
    }
}
