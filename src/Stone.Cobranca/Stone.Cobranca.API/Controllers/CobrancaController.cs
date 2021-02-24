using Microsoft.AspNetCore.Mvc;


namespace Stone.Cobranca.API.Controllers
{
    /// <summary>
    /// Api que registra cobranças de um determinado cliente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}