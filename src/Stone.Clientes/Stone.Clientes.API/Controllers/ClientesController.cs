using Microsoft.AspNetCore.Mvc;
using Stone.Clientes.Application.Interfaces;
using Stone.Clientes.Application.ViewModel;
using Stone.Utils;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="clienteApplication"></param>
        public ClientesController(IClienteApplication clienteApplication)
        {
            this.clienteApplication = clienteApplication;
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="novoCliente">Novo cliente a ser inserido</param>
        /// <param name="cancellationToken">Cacellation token</param>
        /// <response code="201">Cliente inserido com sucesso</response>
        /// <response code="400">
        /// CLIENTE_NOME_OBRIGATORIO - O Nome do cliente é obrigatório.<br/>
        /// CLIENTE_CPF_OBRIGATORIO - O CPF do cliente é obrigatório.<br/>
        /// CLIENTE_ESTADO_OBRIGATORIO - O Estado do cliente é obrigatório.<br/>
        /// CLIENTE_ESTADO_INVALIDO - O Estado do cliente é inválido.<br/>
        /// CLIENTE_CPF_INVALIDO - O cpf informado para o cliente é inválido
        /// </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ClienteViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
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
        /// <response code="200">Cliente </response>
        /// <response code="400">
        /// CLIENTE_CPF_INVALIDO - O cpf informado para o cliente é inválido
        /// </response>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ClienteViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
        public async System.Threading.Tasks.Task<IActionResult> Get(long cpf, CancellationToken cancellationToken)
        {
            var cliente = await this.clienteApplication.ObterPorCpfAsync(cpf, cancellationToken);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        /// <summary>
        /// Retorna uma listagem paginada de clientes
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="size">Quantidade de resultados a retornar</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Lista de clientes paginados</response>
        /// <response code="400">
        /// BUSCA_INVALIDA - Os valores informados para busca são inválidos.
        /// </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResultadoPaginado<ClienteViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
        public async System.Threading.Tasks.Task<IActionResult> Get(int page, int size, CancellationToken cancellationToken)
        {
            var resultados = await this.clienteApplication.BuscaPaginadaAsync(page, size, cancellationToken);

            return Ok(new ResultadoPaginado<ClienteViewModel>()
            {
                Data = resultados.ToArray(),
                Size = size,
                Page = page,
                Next = Url.RouteUrl(nameof(Get), new { pagina = page++, quantidade = size })
            });
        }
    }
}
