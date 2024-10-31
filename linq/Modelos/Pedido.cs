using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Producto { get; set; }
    }
}
