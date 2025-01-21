using Microsoft.EntityFrameworkCore;
using PruebaIDT.DbContextAccess;
using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Clients
{
    public class ClientDomain(DbContexts dbContexts) : IClientDomain
    {
        public async Task<UniversalResponseDto<bool>> CreateClient(ClienteModel cliente)
        {
            var response = new UniversalResponseDto<bool>();
            try
            {
                var emailValidation = await dbContexts.Clientes.AnyAsync(e => e.Email.Equals(cliente.Email));

                if (emailValidation)
                {
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                else
                {
                    await dbContexts.AddAsync(cliente);
                    await dbContexts.SaveChangesAsync();
                    response.Code = System.Net.HttpStatusCode.Created;
                }
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
