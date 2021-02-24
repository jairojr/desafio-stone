using Microsoft.AspNetCore.Mvc;

namespace Stone.Clientes.API.Controllers
{
    /// <summary>
    /// Api para cadastro e consulta de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        /// <summary>
        /// Listagem de clientes clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
