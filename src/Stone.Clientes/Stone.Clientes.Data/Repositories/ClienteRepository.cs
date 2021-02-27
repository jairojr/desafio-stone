using Microsoft.EntityFrameworkCore;
using Stone.Clientes.Data.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Stone.Clientes.Domain.Models;
using Stone.Clientes.Domain.Repositories;
using Stone.Clientes.Domain.Enums;
using System.Threading;

namespace Stone.Clientes.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSet<ClienteEntity> clientesContext;
        private readonly ClientesContext context;

        public ClienteRepository(ClientesContext context)
        {
            this.clientesContext = context.Clientes;
            this.context = context;
        }

        public async Task<Cliente> CriarAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            await clientesContext.AddAsync(new ClienteEntity(cliente.Nome, cliente.Estado.ToString(), cliente.CPF.ObterApenasNumeros()),
                                            cancellationToken);
            await context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> ObterPorCpfAsync(long cpf, CancellationToken cancellationToken)
        {
            var clienteDb = await this.clientesContext.FirstOrDefaultAsync(c => c.CPF == cpf, cancellationToken);

            return RetornaClienteDomain(clienteDb);
        }

        public async Task<Cliente> ObterPorIdAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var clienteDb = await this.clientesContext.FirstOrDefaultAsync(c => c.Id == idCliente, cancellationToken);
            return RetornaClienteDomain(clienteDb);
        }

        private static Cliente RetornaClienteDomain(ClienteEntity clienteDb)
        {
            if (clienteDb == null)
                return null;

            return new Cliente(clienteDb.Id,
                                            clienteDb.Nome,
                                            (EstadoEnum)Enum.Parse(typeof(EstadoEnum), clienteDb.Estado),
                                            clienteDb.CPF);
        }

        public Task<bool> VerificaSeClienteExisteAsync(long cpf, CancellationToken cancellationToken)
        {
            return this.clientesContext.AnyAsync(c => c.CPF == cpf, cancellationToken);
        }
    }
}
