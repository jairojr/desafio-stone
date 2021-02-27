using Microsoft.AspNetCore.Mvc;
using Stone.Clientes.Application.Interfaces;
using Stone.Clientes.Application.ViewModel;
using System.Threading;

namespace Stone.Clientes.API.Controllers
{
    /// <summary>
    /// Api para cadastro e consulta de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplication clienteApplication;

        public ClientesController(IClienteApplication clienteApplication)
        {
            this.clienteApplication = clienteApplication;
        }

        /// <summary>
        /// Listagem de clientes clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="novoCliente">Novo cliente a ser inserido</param>
        /// <param name="cancellationToken">Cacellation token</param>
        /// <returns></returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> PostAsync(ClienteViewModel novoCliente, CancellationToken cancellationToken)
        {
            var cliente = await this.clienteApplication.CriarAsync(novoCliente, cancellationToken);

            return CreatedAtAction(nameof(Get), cliente.CPF, cliente);
        }

        /// <summary>
        /// Retorna um cliente por CPF
        /// </summary>
        /// <param name="cpf">Cpf a ser buscado</param>
        /// <param name="cancellationToken">Cacellation token</param>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        public async System.Threading.Tasks.Task<IActionResult> Get(long cpf, CancellationToken cancellationToken)
        {
            var cliente = await this.clienteApplication.ObterPorCpfAsync(cpf, cancellationToken);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
