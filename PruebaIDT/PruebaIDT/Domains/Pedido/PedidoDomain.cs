using Microsoft.EntityFrameworkCore;
using PruebaIDT.DbContextAccess;
using PruebaIDT.Models.DTOs.Pedidos;
using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Pedido
{
    public class PedidoDomain(DbContexts dbContexts) : IPedidoDomain
    {
        public async Task<UniversalResponseDto<bool>> CrearPedido(PedidoDto pedidoDto)
        { 
            var response = new UniversalResponseDto<bool>();
            try
            {
                var pedidoModel = new PedidoModel();
                pedidoModel = pedidoDto.Pedido;
                await dbContexts.AddAsync(pedidoModel);

                decimal totalPedido = 0;

                foreach (var product in pedidoDto.Productos)
                {
                    var productDb = await dbContexts.Productos.FirstOrDefaultAsync(p => p.Id.Equals(product.Id));

                    if (productDb == null)
                    {
                        response.Data = false;
                        response.Code = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }

                    if (productDb.Stock < product.Stock)
                    {
                        response.Data = false;
                        response.Code = System.Net.HttpStatusCode.NotFound;
                        return response;
                    }


                    totalPedido = Convert.ToDecimal(product.Stock) * productDb.Precio;
                    productDb.Stock -= product.Stock;

                    dbContexts.Update(productDb);
                    var pedidoProducto = new PedidoProductoModel()
                    {
                        Cantidad = product.Stock,
                        Pedido = pedidoModel,
                        Producto = productDb,
                    };

                    await dbContexts.AddAsync(pedidoProducto);
                }
                pedidoModel.Total = totalPedido;
                pedidoModel.FechaPedido = DateTime.Now;

                await dbContexts.SaveChangesAsync();
                response.Code = System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<UniversalResponseDto<PedidoModel>> ObtenerPedidoById(int id)
        {
            var response = new UniversalResponseDto<PedidoModel>();
            try
            {
                var pedido = await dbContexts.Pedidos
                    .Include(c => c.Cliente)
                    .Include(pp => pp.PedidoProductos)
                    .ThenInclude(p => p.Producto).FirstOrDefaultAsync(p => p.Id.Equals(id));
                response.Data = pedido;
                response.Code = System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
