using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIDT.Domains.Clients;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientDomain clientDomain) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClienteModel cliente)
        {

            var response = await clientDomain.CreateClient(cliente);
            return StatusCode(response.Code.GetHashCode());
        }
    }
}
