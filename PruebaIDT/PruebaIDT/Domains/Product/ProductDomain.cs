using Microsoft.EntityFrameworkCore;
using PruebaIDT.DbContextAccess;
using PruebaIDT.Models.DTOs.Universal;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Domains.Product
{
    public class ProductDomain(DbContexts dbContexts) : IProductDomain
    {
        public async Task<UniversalResponseDto<object>> ObtainProducts()
        {
			var response = new UniversalResponseDto<object>();
			try
			{
				var products = await dbContexts.Productos.ToListAsync();

				if (!products.Any())
				{
					response.Code = System.Net.HttpStatusCode.NotFound;
				}
				else
				{
					response.Code = System.Net.HttpStatusCode.OK;
					response.Data = products.Select(x => new {x.Id, x.Precio, x.Nombre, x.Stock, x.FechaCreacion});
				}
			}
			catch (Exception)
			{
				response.Code = System.Net.HttpStatusCode.InternalServerError;
			}

			return response;
        }

		public async Task<UniversalResponseDto<ProductoModel>> UpdateProduct(ProductoModel productoModel)
		{
			var response = new UniversalResponseDto<ProductoModel>();
            try
            {
                var products = await dbContexts.Productos.FirstOrDefaultAsync(p => p.Id.Equals(productoModel.Id));

                if (products is null)
                {
                    response.Code = System.Net.HttpStatusCode.NotFound;
                }
                else
                {
                    products.Precio = productoModel.Precio;
                    products.Stock = productoModel.Stock;
                    dbContexts.Update(products);
                    await dbContexts.SaveChangesAsync();
                    response.Data = products;
                    response.Code = System.Net.HttpStatusCode.OK;
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
