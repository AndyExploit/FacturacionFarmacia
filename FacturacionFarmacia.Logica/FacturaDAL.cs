using FacturacionFarmacia.Entidades.DTO;
using FacturacionFarmacia.Entidades;
using FacturacionFarmacia.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FacturacionFarmacia.Logica
{
    public class FacturaDAL : IFactura
    {
        string conexiondb = "DATA SOURCE = .; INITIAL CATALOG = facturacionFarmacia;Integrated Security=True;";

        public GenericResponse<List<Factura>> ObtenerFacturas()
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<List<Factura>>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Factura]";
                var factura_Data = connection.Query<Factura>(query).ToList();
                connection.Close();

                dtoGenericResponse.Data = factura_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<List<Factura>>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<Factura> ObtenerUnaFactura(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<Factura>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Factura] WHERE ID = @ID";
                var factura_Data = connection.Query<Factura>(query, new { ID = pID }).FirstOrDefault();
                connection.Close();

                dtoGenericResponse.Data = factura_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<Factura>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }
        }

        public GenericResponse<int> CrearFactura(Factura pFactura)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"INSERT INTO dbo.[Factura] (IdCliente, EstadoInventario, FechaRegistro) VALUES (@IdCliente, @EstadoInventario, @FechaRegistro)";
                var factura_Data = connection.Execute(query, new
                {
                    IdCliente = pFactura.IdCliente,
                    EstadoInventario = 0,
                    FechaRegistro = DateTime.Now
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = factura_Data;
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

        public GenericResponse<int> EliminarFactura(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"DELETE FROM dbo.[Factura] WHERE ID = @ID;";
                var factura_Data = connection.Execute(query, new { ID = pID }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = factura_Data;
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
