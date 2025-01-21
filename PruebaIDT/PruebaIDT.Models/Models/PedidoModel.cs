using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIDT.Models.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }

        public DateTime FechaPedido { get; set; }

        public decimal Total { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteModel? Cliente { get; set; }

        public virtual List<PedidoProductoModel>? PedidoProductos { get; set; }
    }
}
