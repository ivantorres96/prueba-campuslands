using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIDT.Models.Models
{
    public class PedidoProductoModel
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public virtual PedidoModel?  Pedido { get; set; }

        public int ProductoId { get; set; }

        public virtual ProductoModel?  Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
