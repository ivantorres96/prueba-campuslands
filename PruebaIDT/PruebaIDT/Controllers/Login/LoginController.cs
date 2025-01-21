using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIDT.Domains.Login;
using PruebaIDT.Models.DTOs.Login;

namespace PruebaIDT.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginDomain loginDomain) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var response = loginDomain.Ingresar(loginDto.UserName, loginDto.Password);
            return StatusCode(response.Code.GetHashCode(), response.Data);
        }
    }
}
