using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Logica.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFarmacia.Logica
{
    public class ProductoDAL : IProducto
    {
        string conexiondb = "DATA SOURCE = .; INITIAL CATALOG = facturacionFarmacia;Integrated Security=True;";

        public GenericResponse<List<Producto>> ObtenerProductos()
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<List<Producto>>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[producto]";
                var producto_Data = connection.Query<Producto>(query).ToList();
                connection.Close();

                dtoGenericResponse.Data = producto_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<List<Producto>>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<Producto> ObtenerUnProducto(int pID) 
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<Producto>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[producto] WHERE ID = @ID";
                var producto_Data = connection.Query<Producto>(query, new {ID = pID}).FirstOrDefault();
                connection.Close();

                dtoGenericResponse.Data = producto_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<Producto>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }
        }

        public GenericResponse<int> CrearProducto(Producto pProducto)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"INSERT INTO dbo.[Producto] (IdTipo,Nombre,Precio,Cantidad,Estado,Comentario) VALUES (@IdTipo,@Nombre,@Precio,@Cantidad,@Estado,@Comentario)";
                var producto_Data = connection.Execute(query, new { IdTipo = pProducto.IdTipo, 
                                                                    Nombre = pProducto.Nombre, 
                                                                    Precio = pProducto.Precio, 
                                                                    Cantidad = pProducto.Cantidad, 
                                                                    Estado = pProducto.Estado, 
                                                                    Comentario = pProducto.Comentario }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = producto_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<int>();

                dtoGenericResponse.Data = 0;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<int> EditarProducto(Producto pProducto)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"UPDATE dbo.[Producto] SET IdTipo = @IdTipo, Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad, Estado = @Estado, Comentario = @Comentario WHERE ID = @ID;";
                var producto_Data = connection.Execute(query, new { IdTipo = pProducto.IdTipo, 
                                                                    Nombre = pProducto.Nombre,
                                                                    Precio = pProducto.Precio,
                                                                    Cantidad = pProducto.Cantidad,
                                                                    Estado = pProducto.Estado,
                                                                    Comentario = pProducto.Comentario,
                                                                    ID = pProducto.ID}); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = producto_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<int>();

                dtoGenericResponse.Data = 0;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }

        }

        public GenericResponse<int> EliminarProducto(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"DELETE FROM dbo.[Producto] WHERE ID = @ID;";
                var producto_Data = connection.Execute(query, new { ID = pID }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = producto_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<int>();

                dtoGenericResponse.Data = 0;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }

        }

    }
}
