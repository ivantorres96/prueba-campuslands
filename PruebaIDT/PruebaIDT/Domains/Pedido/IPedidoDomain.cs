using PruebaIDT.Models.DTOs.Pedidos;
using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Pedido
{
    public interface IPedidoDomain
    {
        Task<UniversalResponseDto<bool>> CrearPedido(PedidoDto pedidoDto);

        Task<UniversalResponseDto<PedidoModel>> ObtenerPedidoById(int id);
    }
}
