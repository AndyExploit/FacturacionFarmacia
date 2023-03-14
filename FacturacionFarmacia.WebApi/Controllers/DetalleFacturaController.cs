using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FacturacionFarmacia.Entidades.JOINS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionFarmacia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private IDetalleFactura _IDetalleFactura;

        public DetalleFacturaController(IDetalleFactura iDetalleFactura)
        {
            _IDetalleFactura = iDetalleFactura;
        }

        // GET: api/<DetalleFacturaController>
        [HttpGet("DetallesByFactura")]
        public GenericResponse<List<DetalleFactura_Producto>> Get(int IDFactura)
        {
            var result = _IDetalleFactura.ObtenerDetallesFacturaByFactura(IDFactura);
            return result;
        }

        // POST api/<DetalleFacturaController>
        [HttpPost]
        public GenericResponse<int> Post(DetalleFactura pDetalleFactura)
        {
            var result = _IDetalleFactura.CrearDetalleFactura(pDetalleFactura);
            return result;
        }

        // PUT api/<DetalleFacturaController>/5
        [HttpPut]
        public GenericResponse<int> Put(DetalleFactura pDetalleFactura)
        {
            var result = _IDetalleFactura.EditarDetalleFactura(pDetalleFactura);
            return result;
        }

        // DELETE api/<DetalleFacturaController>/5
        [HttpDelete]
        public GenericResponse<int> Delete(int ID)
        {
            var result = _IDetalleFactura.EliminarDetalleFactura(ID);
            return result;
        }
    }
}
