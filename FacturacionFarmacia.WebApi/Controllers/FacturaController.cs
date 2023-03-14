using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades;
using Microsoft.AspNetCore.Mvc;
using FacturacionFarmacia.Logica.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionFarmacia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFactura _IFactura;

        public FacturaController(IFactura iFactura)
        {
            _IFactura = iFactura;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public GenericResponse<List<Factura>> Get()
        {
            var result = _IFactura.ObtenerFacturas();
            return result;
        }

        // GET api/<FacturaController>/5
        [HttpGet("Details")]
        public GenericResponse<Factura> Get(int ID)
        {
            var result = _IFactura.ObtenerUnaFactura(ID);
            return result;
        }

        // POST api/<FacturaController>
        [HttpPost]
        public GenericResponse<int> Post(Factura pFactura)
        {
            var result = _IFactura.CrearFactura(pFactura);
            return result;
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete]
        public GenericResponse<int> Delete(int ID)
        {
            var result = _IFactura.EliminarFactura(ID);
            return result;
        }
    }
}
