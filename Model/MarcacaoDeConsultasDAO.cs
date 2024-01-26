using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MarcacaoDeConsultasDAO : connectionSQL
    {
        public string erro = string.Empty;
        public bool Insert(DataConsultation DataConsultation)
        {
            using (var sqlconnection = GetConnection())
            {
                sqlconnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlconnection;
                    sqlCommand.CommandText = "InserirConsulta";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@fk_doctor", DataConsultation.Fkdoctor);
                    sqlCommand.Parameters.AddWithValue("@fk_patient", DataConsultation.Fk_patient);
                    sqlCommand.Parameters.AddWithValue("@fk_user", DataConsultation.Fk_user);
                    sqlCommand.Parameters.AddWithValue("@date", DataConsultation.Date);

                    if(string.IsNullOrEmpty(DataConsultation.Weight.ToString()))
                        sqlCommand.Parameters.AddWithValue("@weight", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@weight", DataConsultation.Weight);

                    if(string.IsNullOrEmpty(DataConsultation.Heart_rate.ToString()))
                        sqlCommand.Parameters.AddWithValue("@heart_rate", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@heart_rate", DataConsultation.Heart_rate);

                    if (string.IsNullOrEmpty(DataConsultation.Height.ToString()))
                        sqlCommand.Parameters.AddWithValue("@height", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@height", DataConsultation.Height);

                    if (string.IsNullOrEmpty(DataConsultation.Prognostic.ToString()))
                        sqlCommand.Parameters.AddWithValue("@prognostic", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@prognostic", DataConsultation.Prognostic);

                    sqlCommand.Parameters.AddWithValue("@time", DataConsultation.Time);
                    sqlCommand.Parameters.AddWithValue("@status", DataConsultation.Status);
                    try
                    {
                        erro = string.Empty;
                        int i = sqlCommand.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public bool Alter(DataConsultation DataConsultation)
        {
            using (var sqlconnection = GetConnection())
            {
                sqlconnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlconnection;
                    sqlCommand.CommandText = "AlterConsulta";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", DataConsultation.Id);
                    sqlCommand.Parameters.AddWithValue("@fk_doctor", DataConsultation.Fkdoctor);
                    sqlCommand.Parameters.AddWithValue("@fk_patient", DataConsultation.Fk_patient);
                    sqlCommand.Parameters.AddWithValue("@fk_user", DataConsultation.Fk_user);
                    sqlCommand.Parameters.AddWithValue("@date", DataConsultation.Date);

                    if (string.IsNullOrEmpty(DataConsultation.Weight.ToString()))
                        sqlCommand.Parameters.AddWithValue("@weight", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@weight", DataConsultation.Weight);

                    if (string.IsNullOrEmpty(DataConsultation.Heart_rate.ToString()))
                        sqlCommand.Parameters.AddWithValue("@heart_rate", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@heart_rate", DataConsultation.Heart_rate);

                    if (string.IsNullOrEmpty(DataConsultation.Height.ToString()))
                        sqlCommand.Parameters.AddWithValue("@height", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@height", DataConsultation.Height);

                    if (string.IsNullOrEmpty(DataConsultation.Prognostic.ToString()))
                        sqlCommand.Parameters.AddWithValue("@prognostic", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@prognostic", DataConsultation.Prognostic);

                    sqlCommand.Parameters.AddWithValue("@time", DataConsultation.Time);
                    sqlCommand.Parameters.AddWithValue("@status", DataConsultation.Status);
                    try
                    {
                        erro = string.Empty;
                        int i = sqlCommand.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "DELETE FROM [dbo].[consultation] WHERE id_consultation=@id";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        erro = string.Empty;
                        int i = sqlCommand.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public DataTable Table()
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "consultaMostar";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

        public DataTable Search(string name)
        {
            using (var conex2 = GetConnection())
            {
                conex2.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conex2;
                    command.CommandText = "SearchViewInConsultation";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@n", name);
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

        public DataTable TableHomeConsultation(DateTime date)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "ConsultaHome";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@data", date);
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

        public bool StatusUpdata(string status,int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "UPDATE [dbo].[ConsultationHome]SET [status] = @status WHERE id_consultation=@id";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@status", status);
                    try
                    {
                        erro = string.Empty;
                        int i = sqlCommand.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public DataTable HistoryPatiente(int id)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "HistoricoBsPatient";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

    }//fim
}
