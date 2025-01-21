using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaIDT.Models.Models;

namespace PruebaIDT.Models.DTOs.Pedidos
{
    public class PedidoDto
    {
        public PedidoModel? Pedido { get; set; }

        public List<ProductoModel>? Productos { get; set; }
    }
}
