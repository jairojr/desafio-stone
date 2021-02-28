using AutoMapper;
using FluentValidation.Results;
using Stone.Cobrancas.Application.Interfaces;
using Stone.Cobrancas.Application.Validation;
using Stone.Cobrancas.Application.ViewModel;
using Stone.Cobrancas.Domain.Models;
using Stone.Cobrancas.Domain.Services;
using Stone.Cobrancas.Domain.ValueObjects;
using Stone.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Cobrancas.Application
{
    public class CobrancaApplication : ICobrancaApplication
    {
        private readonly IMapper mapper;
        private readonly CobrancaViewModelValidation validationInsert;
        private readonly BuscarCobrancaViewModelValidation buscaValidation;

        public CobrancaApplication(IMapper mapper,
                                    ICobrancaService service,
                                    CobrancaViewModelValidation insertValidation,
                                    BuscarCobrancaViewModelValidation buscaValidation
                                    )
        {
            this.mapper = mapper;
            Service = service;
            this.validationInsert = insertValidation;
            this.buscaValidation = buscaValidation;
        }

        public ICobrancaService Service { get; }

        public async Task<IEnumerable<CobrancaViewModel>> BuscarAsync(BuscarCobrancaViewModel buscaViewModel, CancellationToken cancellationToken)
        {
            ValidationResult result = this.buscaValidation.Validate(buscaViewModel);

            if (!result.IsValid)
                result.ThrowErrosValidacao();

            var buscaDomain = this.mapper.Map<BuscarCobrancaValueObject>(buscaViewModel);
            var cobrancas = await this.Service.BuscaAsync(buscaDomain, cancellationToken);

            return this.mapper.Map<IEnumerable<CobrancaViewModel>>(cobrancas);
        }

        public async Task<CobrancaViewModel> CriarAsync(CobrancaViewModel cobrancaVewModel, CancellationToken cancellationToken)
        {
            ValidationResult result = this.validationInsert.Validate(cobrancaVewModel);

            if (!result.IsValid)
                result.ThrowErrosValidacao();

            var cobranca = this.mapper.Map<Cobranca>(cobrancaVewModel);
            var cobrancaInserida = await this.Service.CriarAsync(cobranca, cancellationToken);

            return this.mapper.Map<CobrancaViewModel>(cobrancaInserida);
        }
    }
}