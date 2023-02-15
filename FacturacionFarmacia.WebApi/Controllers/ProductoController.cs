using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionFarmacia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _IProducto;

        public ProductoController(IProducto iProducto)
        {
            _IProducto = iProducto;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public GenericResponse<List<Producto>> Get()
        {
            var result = _IProducto.ObtenerProductos();
            return result;
        }

        // GET api/<ProductoController>/5
        [HttpGet("Details")]
        public GenericResponse<Producto> Get(int ID)
        {
            var result = _IProducto.ObtenerUnProducto(ID);
            return result;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public GenericResponse<int> Post(Producto pProducto)
        {
            var result = _IProducto.CrearProducto(pProducto);
            return result;
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public GenericResponse<int> Put(Producto pProducto)
        {
            var result = _IProducto.EditarProducto(pProducto);
            return result;
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete]
        public GenericResponse<int> Delete(int ID)
        {
            var result = _IProducto.EliminarProducto(ID);
            return result;
        }
    }
}
