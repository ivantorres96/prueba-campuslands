using PruebaIDT.Domains.Clients;
using PruebaIDT.Domains.Login;
using PruebaIDT.Domains.Pedido;
using PruebaIDT.Domains.Product;

namespace PruebaIDT.Domains
{
    public static class DomainRegistration
    {
        public static void AddDomainsLayer(this IServiceCollection services)
        {
            services.AddTransient<IClientDomain, ClientDomain>();
            services.AddTransient<IProductDomain, ProductDomain>();
            services.AddTransient<IPedidoDomain, PedidoDomain>();
            services.AddTransient<ILoginDomain, LoginDomain>();
        }
    }
}
