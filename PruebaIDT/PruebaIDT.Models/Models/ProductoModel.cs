using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIDT.Models.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual List<PedidoProductoModel>? PedidoProductos { get; set; }
    }
}
