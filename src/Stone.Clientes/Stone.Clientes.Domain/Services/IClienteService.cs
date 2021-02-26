using Stone.Clientes.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Domain.Services
{
    public interface IClienteService
    {
        public Task<Cliente> CriarAsync(Cliente cliente, CancellationToken cancellationToken);
        public Task<Cliente> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken);
        public Task<Cliente> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken);
    }
}
