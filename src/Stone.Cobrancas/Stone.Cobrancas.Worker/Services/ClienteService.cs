using Microsoft.Extensions.Configuration;
using Stone.Cobrancas.Worker.Models;
using Stone.Utils;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;


namespace Stone.Cobrancas.Worker.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration["StoneApiClientes:BaseUrl"]);
            _httpClient = httpClient;

        }

        public async Task<ResultadoPaginado<ClienteViewModel>> GetClientes(int pagina, int quantidade, CancellationToken CancellationToken)
        {
            var uri = $"/api/Clientes?page={pagina}&size={quantidade}";

            return await _httpClient.GetFromJsonAsync<ResultadoPaginado<ClienteViewModel>>(uri, CancellationToken);
        }
    }
}
