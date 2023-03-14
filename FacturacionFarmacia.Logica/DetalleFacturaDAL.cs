using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FacturacionFarmacia.Logica.Interfaces;
using System.Security.Cryptography;
using FacturacionFarmacia.Entidades.JOINS;

namespace FacturacionFarmacia.Logica
{
    public class DetalleFacturaDAL: IDetalleFactura
    {
        string conexiondb = "DATA SOURCE = .; INITIAL CATALOG = facturacionFarmacia;Integrated Security=True;";

        public GenericResponse<List<DetalleFactura_Producto>> ObtenerDetallesFacturaByFactura(int IDFactura)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<List<DetalleFactura_Producto>>();

                connection.Open();
                var query = $"SELECT a.ID,a.IDFactura,a.IdProducto,a.Cantidad,b.Nombre,b.Precio,b.Comentario FROM dbo.[DetalleFactura] a INNER JOIN dbo.[Producto] b ON a.IdProducto = b.ID  WHERE a.IDFactura = @IDFactura";
                var detalleFactura_Data = connection.Query<DetalleFactura_Producto>(query, new { IDFactura = IDFactura }).ToList();
                connection.Close();

                dtoGenericResponse.Data = detalleFactura_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<List<DetalleFactura_Producto>>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<int> CrearDetalleFactura(DetalleFactura pDetalleFactura)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"INSERT INTO dbo.[DetalleFactura] (IDFactura, IdProducto, Cantidad) VALUES (@IDFactura, @IdProducto, @Cantidad)";
                var detalleFactura_Data = connection.Execute(query, new
                {
                    IDFactura = pDetalleFactura.IDFactura,
                    IdProducto = pDetalleFactura.IdProducto,
                    Cantidad = pDetalleFactura.Cantidad
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = detalleFactura_Data;
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

        public GenericResponse<int> EditarDetalleFactura(DetalleFactura pDetalleFactura)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"UPDATE dbo.[DetalleFactura] SET IDFactura = @IDFactura, IdProducto = @IdProducto, Cantidad = @Cantidad WHERE ID = @ID;";
                var detalleFactura_Data = connection.Execute(query, new
                {
                    IDFactura = pDetalleFactura.IDFactura,
                    IdProducto = pDetalleFactura.IdProducto,
                    Cantidad = pDetalleFactura.Cantidad,
                    ID = pDetalleFactura.ID
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = detalleFactura_Data;
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

        public GenericResponse<int> EliminarDetalleFactura(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"DELETE FROM dbo.[DetalleFactura] WHERE ID = @ID;";
                var detalleFactura_Data = connection.Execute(query, new { ID = pID }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = detalleFactura_Data;
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
