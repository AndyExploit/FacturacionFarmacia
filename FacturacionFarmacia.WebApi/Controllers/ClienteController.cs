using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionFarmacia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _ICliente;

        public ClienteController(ICliente iCliente)
        {
            _ICliente = iCliente;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public GenericResponse<List<Cliente>> Get()
        {
            var result = _ICliente.ObtenerClientes();
            return result;
        }

        // GET api/<ClienteController>/5
        [HttpGet("Details")]
        public GenericResponse<Cliente> Get(int ID)
        {
            var result = _ICliente.ObtenerUnCliente(ID);
            return result;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public GenericResponse<int> Post(Cliente pCliente)
        {
            var result = _ICliente.CrearCliente(pCliente);
            return result;
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public GenericResponse<int> Put(Cliente pCliente)
        {
            var result = _ICliente.EditarCliente(pCliente);
            return result;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete]
        public GenericResponse<int> Delete(int ID)
        {
            var result = _ICliente.EliminarCliente(ID);
            return result;
        }
    }
}
