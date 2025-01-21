using Microsoft.OpenApi.Validations;
using PruebaIDT.Models.DTOs.Token;
using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Service.JWT;

namespace PruebaIDT.Domains.Login
{
    public class LoginDomain : ILoginDomain
    {
        public UniversalResponseDto<TokenDto> Ingresar(string user, string password)
        {
            var response = new UniversalResponseDto<TokenDto>();

            var credentials = new Dictionary<string, string>()
            {
                {"ivan", "123" },
                {"dario", "321" }
            } ;

            var roles = new Dictionary<string, string>()
            {
                {"ivan", "admin" },
                {"dario", "cliente" }
            };

            var nuevoToken = new GenerateToken();
            var credential = credentials.FirstOrDefault(u => u.Key.Equals(user));
            if (credential.Value.Equals(password))
            {
                var token = nuevoToken.GenerateJwtToken(roles.FirstOrDefault(r => r.Key.Equals(user)).Value);
                response.Data = token;
                response.Code = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Code = System.Net.HttpStatusCode.BadRequest;
            }

            return response;
        }
    }
}
