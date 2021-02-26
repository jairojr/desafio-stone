using Stone.Clientes.Application.ViewModel;
using Stone.Clientes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Clientes.Application.Interfaces
{
    public interface IClienteApplication
    {
        public Task<ClienteViewModel> CriarAsync(ClienteViewModel cliente);
        public Task<ClienteViewModel> ObterPorIdAsync(Guid idCliente);
        public Task<ClienteViewModel> ObterPorCpfAsync(long cpf);
    }
}
