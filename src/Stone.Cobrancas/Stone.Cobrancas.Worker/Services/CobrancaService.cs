using Stone.Cobrancas.Worker.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace Stone.Cobrancas.Worker.Services
{
    public class CobrancaService
    {
        private readonly HttpClient _httpClient;
        public CobrancaService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration["StoneApiCobrancas:BaseUrl"]);

            _httpClient = httpClient;
        }

        public async Task<bool> InserirCobranca(CobrancaViewModel cobranca, CancellationToken cancellationToken)
        {
            var uri = $"/api/cobranca";

            var response = await _httpClient.PostAsJsonAsync(uri, cobranca, cancellationToken);

            return response.IsSuccessStatusCode;
        }
    }
}
