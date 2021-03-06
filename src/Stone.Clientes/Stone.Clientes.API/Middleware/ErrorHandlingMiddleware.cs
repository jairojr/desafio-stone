﻿using Microsoft.AspNetCore.Http;
using Stone.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Stone.Clientes.API.Middleware
{
    /// <summary>
    /// Middleware responsavel por gerenciar erros da api
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate Next;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            Next = next;
        }


        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            List<ErrorModel> erros = new List<ErrorModel>();
            HttpStatusCode errorCode = HttpStatusCode.InternalServerError;

            if (ex is ValidacaoException)
            {
                if (ex is MultiplaValidacaoException)
                {
                    errorCode = HttpStatusCode.BadRequest;
                    var multipleErros = (MultiplaValidacaoException)ex;
                    foreach (var err in multipleErros.Validacoes)
                    {
                        erros.Add(new ErrorModel(err.Codigo, err.Mensagem));
                    }
                }
                else
                {
                    errorCode = HttpStatusCode.BadRequest;
                    var validationError = (ValidacaoException)ex;
                    erros.Add(new ErrorModel(validationError.Codigo, validationError.Mensagem));
                }
            }
            else
            {
                erros.Add(new ErrorModel("ERR", "ERRO DESCONHECIDO"));
            }

            var result = System.Text.Json.JsonSerializer.Serialize(erros);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorCode;
            return context.Response.WriteAsync(result);

        }
    }
}
