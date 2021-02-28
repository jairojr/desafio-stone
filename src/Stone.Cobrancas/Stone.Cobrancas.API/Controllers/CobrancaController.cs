using Microsoft.AspNetCore.Mvc;
using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Utils;
using System.Linq;
using System.Net;
using System.Threading;

namespace Stone.Cobrancas.API.Controllers
{
    /// <summary>
    /// Api que registra cobranças de um determinado cobranca
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {
        private readonly ICobrancaApplication cobrancaApplication;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="cobrancaApplication"></param>
        public CobrancaController(ICobrancaApplication cobrancaApplication)
        {
            this.cobrancaApplication = cobrancaApplication;
        }

        /// <summary>
        /// Cria um novo cobranca
        /// </summary>
        /// <param name="novaCobranca">Nova cobranca a ser inserido</param>
        /// <param name="cancellationToken">Cacellation token</param>
        /// <response code="201">Cobranca inserido com sucesso</response>
        /// <response code="400">
        /// COBRANCA_CPF_OBRIGATORIO - O CPF da cobrança é obrigatório.<br/>
        /// COBRANCA_DATA_OBRIGATORIO - A data da cobrança é obrigatória.<br/>
        /// COBRANCA_VALOR_OBRIGATORIO - O valor da cobrança é obrigatório.<br/>
        /// COBRANCA_VALOR_INVALIDO - O valor da cobrança deve ser maior que 0.<br/>
        /// COBRANCA_DATA_INVALIDA - A data da cobrança deve ter o ano maior que 1900.<br/>
        /// COBRANCA_CPF_INVALIDO - O cpf informado na cobrança é inválido.<br/>
        /// </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(CobrancaViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
        public async System.Threading.Tasks.Task<IActionResult> PostAsync(CobrancaViewModel novaCobranca, CancellationToken cancellationToken)
        {
            var cobranca = await this.cobrancaApplication.CriarAsync(novaCobranca, cancellationToken);

            return CreatedAtAction(nameof(Get), new BuscarCobrancaViewModel()
            {
                CPF = cobranca.CPF,
                Ano = cobranca.Data.Year,
                Mes = cobranca.Data.Month,
                Pagina = 1,
                Quantidade = 10,
            }, cobranca);
        }

        /// <summary>
        /// Retorna uma listagem de cobrancas utilizando filtros de cpf ou ano e mês.
        /// </summary>
        /// <param name="busca">Filtros de busca</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Lista de cobrancas paginados</response>
        /// <response code="400">
        /// BUSCA_INVALIDA_PAGINA - O valor informado em página é invalido para a busca. <br/>
        /// BUSCA_INVALIDA_QUANTIDADE - O valor informado em quantidade é invalido para a busca.<br/>
        /// BUSCA_CPF_INVALIDO - O cpf informado na busca é inválido. <br/>
        /// BUSCA_INVALIDA_ANO - O ano informado na busca deve ser maior que 1900. <br/>
        /// BUSCA_INVALIDA_MES - O mês informado na busca deve estar entre 1 e 12. <br/>
        /// BUSCA_INVALIDA - Para realizar a busca é necessario informar um cpf ou ano/mês de referência. <br/>
        /// </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResultadoPaginado<CobrancaViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
        public async System.Threading.Tasks.Task<IActionResult> Get([FromQuery] BuscarCobrancaViewModel busca, CancellationToken cancellationToken)
        {
            var resultados = await this.cobrancaApplication.BuscarAsync(busca, cancellationToken);

            var paginaAtual = busca.Pagina;
            busca.Pagina++;

            return Ok(new ResultadoPaginado<CobrancaViewModel>()
            {
                Data = resultados.ToArray(),
                Size = busca.Quantidade,
                Page = paginaAtual,
                Next = Url.Action(nameof(Get), busca)
            });
        }
    }
}