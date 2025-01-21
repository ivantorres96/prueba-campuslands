using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Clients
{
    public interface IClientDomain
    {
        Task<UniversalResponseDto<bool>> CreateClient(ClienteModel cliente);
    }
}
