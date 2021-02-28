﻿using Microsoft.AspNetCore.Mvc;
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
        /// cobranca_NOME_OBRIGATORIO - O Nome do cobranca é obrigatório.<br/>
        /// cobranca_CPF_OBRIGATORIO - O CPF do cobranca é obrigatório.<br/>
        /// cobranca_ESTADO_OBRIGATORIO - O Estado do cobranca é obrigatório.<br/>
        /// cobranca_ESTADO_INVALIDO - O Estado do cobranca é inválido.<br/>
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
                Quantidade = 1,
                Pagina = 0,
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
        /// BUSCA_INVALIDA - Para realizar a busca é necessario informar um cpf ou ano/mês de referência. <br/>
        /// </response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResultadoPaginado<CobrancaViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorModel))]
        public async System.Threading.Tasks.Task<IActionResult> Get([FromQuery] BuscarCobrancaViewModel busca, CancellationToken cancellationToken)
        {
            var resultados = await this.cobrancaApplication.BuscarAsync(busca, cancellationToken);

            busca.Pagina++;

            return Ok(new ResultadoPaginado<CobrancaViewModel>()
            {
                Data = resultados.ToArray(),
                Size = busca.Quantidade,
                Page = busca.Pagina,
                Next = this.Url.Action(nameof(Get), busca)
            });
        }
    }
}