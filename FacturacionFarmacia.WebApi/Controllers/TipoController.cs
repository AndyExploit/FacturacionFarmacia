using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionFarmacia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipo _ITipo;
        public TipoController(ITipo iTipo)
        {
            _ITipo = iTipo;
        }

        // GET: api/<TipoController>
        [HttpGet]
        public GenericResponse<List<Tipo>> Get()
        {
            var result = _ITipo.ObtenerTipos();
            return result;
        }

        // GET api/<TipoController>/5
        [HttpGet("Details")]
        public GenericResponse<Tipo> Get(int ID)
        {
            var result = _ITipo.ObtenerUnTipo(ID);
            return result;
        }

        // POST api/<TipoController>
        [HttpPost]
        public GenericResponse<int> Post(Tipo pTipo)
        {
            var result = _ITipo.CrearTipo(pTipo);
            return result;
        }

        // PUT api/<TipoController>/5
        [HttpPut]
        public GenericResponse<int> Put(Tipo pTipo)
        {
            var result = _ITipo.EditarTipo(pTipo);
            return result;
        }

        // DELETE api/<TipoController>/5
        [HttpDelete]
        public GenericResponse<int> Delete(int ID)
        {
            var result = _ITipo.EliminarTipo(ID);
            return result;
        }
    }
}
