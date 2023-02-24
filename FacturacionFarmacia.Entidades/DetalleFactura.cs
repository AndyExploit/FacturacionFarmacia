using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Entidades
{
    public class DetalleFactura
    {
        public int ID { get; set; }
        public int IDFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
