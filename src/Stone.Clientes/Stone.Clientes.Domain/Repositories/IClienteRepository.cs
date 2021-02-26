using Stone.Clientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Clientes.Domain.Repositories
{
    public interface IClienteRepository
    {
        public Task<Cliente> CriarAsync(Cliente cliente, CancellationToken cancellationToken);
        public Task<Cliente> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken);
        public Task<Cliente> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken);
        public Task<bool> VerificaSeClienteExisteAsync(long cpf, CancellationToken cancellationToken);
    }
}