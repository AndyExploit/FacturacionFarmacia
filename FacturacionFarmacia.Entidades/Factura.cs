using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Entidades
{
    public class Factura
    {
        public int ID { get; set; }
        public int IdCliente { get; set; }
        public byte EstadoInventario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
