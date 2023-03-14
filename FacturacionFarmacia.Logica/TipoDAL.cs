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
    public class TipoDAL : ITipo
    {
        string conexiondb = "DATA SOURCE = .; INITIAL CATALOG = facturacionFarmacia;Integrated Security=True;";

        public GenericResponse<List<Tipo>> ObtenerTipos()
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<List<Tipo>>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Tipo]";
                var tipo_Data = connection.Query<Tipo>(query).ToList();
                connection.Close();

                dtoGenericResponse.Data = tipo_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<List<Tipo>>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }


        }

        public GenericResponse<Tipo> ObtenerUnTipo(int pId)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<Tipo>();

                connection.Open();
                var query = $"SELECT * FROM dbo.[Tipo] WHERE Id = @ID";
                var tipo_Data = connection.Query<Tipo>(query, new { ID = pId }).FirstOrDefault();
                connection.Close();

                dtoGenericResponse.Data = tipo_Data;
                dtoGenericResponse.Success = true;
                dtoGenericResponse.Message = "Transaccion Exitosa";

                return dtoGenericResponse;
            }
            catch (Exception e)
            {
                var dtoGenericResponse = new GenericResponse<Tipo>();

                dtoGenericResponse.Data = null;
                dtoGenericResponse.Success = false;
                dtoGenericResponse.Message = "Ocurrio un Error" + e.Message;

                return dtoGenericResponse;
            }
        }

        public GenericResponse<int> CrearTipo(Tipo pTipo)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"INSERT INTO dbo.[Tipo] (Nombre) VALUES (@Nombre)";
                var tipo_Data = connection.Execute(query, new
                {
                    Nombre = pTipo.Nombre
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = tipo_Data;
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

        public GenericResponse<int> EditarTipo(Tipo pTipo)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"UPDATE dbo.[Tipo] SET Nombre = @Nombre WHERE Id = @Id;";
                var tipo_Data = connection.Execute(query, new
                {
                    Nombre = pTipo.Nombre,
                    Id = pTipo.Id
                }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = tipo_Data;
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

        public GenericResponse<int> EliminarTipo(int pId)
        {
            try
            {
                var connection = new SqlConnection(conexiondb);

                var dtoGenericResponse = new GenericResponse<int>();

                //Insert
                connection.Open();
                var query = $"DELETE FROM dbo.[Tipo] WHERE Id = @Id;";
                var tipo_Data = connection.Execute(query, new { Id = pId }); //llenar campos
                connection.Close();

                dtoGenericResponse.Data = tipo_Data;
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
