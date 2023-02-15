using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica.Interfaces
{
    public interface ICliente
    {
        public GenericResponse<List<Cliente>> ObtenerClientes();
        public GenericResponse<Cliente> ObtenerUnCliente(int ID);
        public GenericResponse<int> CrearCliente(Cliente pCliente);
        public GenericResponse<int> EditarCliente(Cliente pCliente);
        public GenericResponse<int> EliminarCliente(int ID);

    }
}
