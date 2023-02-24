using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica.Interfaces
{
    public interface IFactura
    {
        public GenericResponse<List<Factura>> ObtenerFacturas();
        public GenericResponse<Factura> ObtenerUnaFactura(int ID);
        public GenericResponse<int> CrearFactura(Factura pFactura);
        public GenericResponse<int> EliminarFactura(int ID);
    }
}
