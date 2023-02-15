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

namespace FacturacionFarmacia.Logica
{
    public class CLienteDAL : ICliente
    {
        string conexiondb = "DATA SOURCE = .; INITIAL CATALOG = facturacionFarmacia;Integrated Security=True;";

        public GenericResponse<List<Cliente>> ObtenerClientes()
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<List<Cliente>>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Cliente]";
                var cliente_Data = connection.Query<Cliente>(query).ToList();
                connection.Close();

                dtoGenericResponse.Data = cliente_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<List<Cliente>>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<Cliente> ObtenerUnCliente(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<Cliente>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Cliente] WHERE ID = @ID";
                var cliente_Data = connection.Query<Cliente>(query, new { ID = pID }).FirstOrDefault();
                connection.Close();

                dtoGenericResponse.Data = cliente_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<Cliente>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }
        }

        public GenericResponse<int> CrearCliente(Cliente pCliente)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"INSERT INTO dbo.[Cliente] (Nombre,Dui) VALUES (@Nombre,@Dui)";
                var cliente_Data = connection.Execute(query, new
                {
                    Nombre = pCliente.Nombre,
                    Dui = pCliente.Dui
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = cliente_Data;
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

        public GenericResponse<int> EditarCliente(Cliente pCLiente)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"UPDATE dbo.[Cliente] SET Nombre = @Nombre, Dui = @DUI WHERE ID = @ID;";
                var cliente_Data = connection.Execute(query, new
                {
                    Nombre = pCLiente.Nombre,
                    Dui = pCLiente.Dui,
                    ID = pCLiente.ID
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = cliente_Data;
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

        public GenericResponse<int> EliminarCliente(int pID)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"DELETE FROM dbo.[Cliente] WHERE ID = @ID;";
                var cliente_Data = connection.Execute(query, new { ID = pID }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = cliente_Data;
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
