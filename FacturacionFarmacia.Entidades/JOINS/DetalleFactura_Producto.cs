using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Entidades.JOINS
{
    public class DetalleFactura_Producto
    {
        public int ID { get; set; }
        public int IDFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        //-----------------------------------JOIN-------------------------
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Comentario { get; set; }
    }
}
