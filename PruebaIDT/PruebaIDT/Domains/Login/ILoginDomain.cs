using PruebaIDT.Models.DTOs.Token;
using PruebaIDT.Models.DTOs.Universal;

namespace PruebaIDT.Domains.Login
{
    public interface ILoginDomain
    {
        UniversalResponseDto<TokenDto> Ingresar(string user, string password);
    }
}
