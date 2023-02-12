using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica.Interfaces
{
    public interface IProducto
    {
        public GenericResponse<List<Producto>> ObtenerProductos();
        public GenericResponse<int> CrearProducto(Producto pProducto);
        public GenericResponse<int> EditarProducto(Producto pProducto);
        public GenericResponse<int> EliminarProducto(int ID);
    }
}
