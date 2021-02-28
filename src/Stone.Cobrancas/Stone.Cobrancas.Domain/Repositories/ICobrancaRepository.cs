using Stone.Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Domain.Repositories
{
    public interface ICobrancaRepository
    {
        public Task<Cobranca> CriarAsync(Cobranca cobranca, CancellationToken cancellationToken);
        public Task<IEnumerable<Cobranca>> BuscarPorCpfAsync(long cpf, int Pagina, int Quantidade, CancellationToken cancellationToken);
        public Task<IEnumerable<Cobranca>> BuscarPorMesAsync(int ano, int mes, int Pagina, int Quantidade, CancellationToken cancellationToken);
    }
}