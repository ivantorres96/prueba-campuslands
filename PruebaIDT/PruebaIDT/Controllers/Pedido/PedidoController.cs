using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaIDT.Domains.Pedido;
using PruebaIDT.Models.DTOs.Pedidos;

namespace PruebaIDT.Controllers.Pedido
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController(IPedidoDomain pedidoDomain) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoDto pedidoDto)
        {
            var response = await pedidoDomain.CrearPedido(pedidoDto);
            return StatusCode(response.Code.GetHashCode());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPedidoById(int id)
        {
            var response = await pedidoDomain.ObtenerPedidoById(id);
            return StatusCode(response.Code.GetHashCode(), response.Data);
        }
    }
}
