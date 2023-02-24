using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica.Interfaces
{
    public interface ITipo
    {
        public GenericResponse<List<Tipo>> ObtenerTipos();
        public GenericResponse<Tipo> ObtenerUnTipo(int ID);
        public GenericResponse<int> CrearTipo(Tipo pTipo);
        public GenericResponse<int> EditarTipo(Tipo pTipo);
        public GenericResponse<int> EliminarTipo(int ID);
    }
}
