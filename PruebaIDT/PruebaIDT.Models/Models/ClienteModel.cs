using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIDT.Models.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Email { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual List<PedidoModel>? Pedidos { get; set; }
    }
}
