using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades.JOINS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica.Interfaces
{
    public interface IDetalleFactura
    {
        public GenericResponse<List<DetalleFactura_Producto>> ObtenerDetallesFacturaByFactura(int IDFactura);
        public GenericResponse<int> CrearDetalleFactura(DetalleFactura pDetalleFactura);
        public GenericResponse<int> EditarDetalleFactura(DetalleFactura pDetalleFactura);
        public GenericResponse<int> EliminarDetalleFactura(int ID);
    }
}
