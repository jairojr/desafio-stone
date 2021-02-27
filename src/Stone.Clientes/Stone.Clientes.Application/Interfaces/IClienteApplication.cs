using Stone.Clientes.Application.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Application.Interfaces
{
    public interface IClienteApplication
    {
        public Task<ClienteViewModel> CriarAsync(ClienteViewModel cliente, CancellationToken cancellationToken);
        public Task<ClienteViewModel> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken);
        public Task<ClienteViewModel> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken);
    }
}
