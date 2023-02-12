using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Entidades
{
    public class Producto
    {
        public int ID { get; set; }
        public int IdTipo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public byte Estado { get; set; }
        public string Comentario { get; set; }
    }
}
