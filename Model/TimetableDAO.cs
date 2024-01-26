using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using Common;
using System.Threading.Tasks;

namespace Model
{
    public class TimetableDAO : connectionSQL
    {
        public string erro = string.Empty;
        public bool Insert(int fkDoctor, TimeSpan entryTime,TimeSpan departureTime,int fkDayweek)
        {
            using (var sqlconnection = GetConnection())
            {
                sqlconnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlconnection;
                    sqlCommand.CommandText = "InserirTimeTableDoctor";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FkDoctor",fkDoctor);
                    sqlCommand.Parameters.AddWithValue("@EntryTime",entryTime);
                    sqlCommand.Parameters.AddWithValue("@departure",departureTime);
                    sqlCommand.Parameters.AddWithValue("@fkdayweek",fkDayweek);
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

        public bool Alter(TimeDoctor timeDoctor)
        {
            using (var sqlconnection = GetConnection())
            {
                sqlconnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlconnection;
                    sqlCommand.CommandText = "AlterTimeDoctor";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id",timeDoctor.Idtimetable);
                    sqlCommand.Parameters.AddWithValue("@FkDoctor", timeDoctor.FkDoctor);
                    sqlCommand.Parameters.AddWithValue("@EntryTime", timeDoctor.EntryTime);
                    sqlCommand.Parameters.AddWithValue("@departure", timeDoctor.DepartureTime);
                    sqlCommand.Parameters.AddWithValue("@fkdayweek", timeDoctor.FkDayweek);
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
                    sqlCommand.CommandText = "DELETE FROM [dbo].[timetable_doctor] WHERE id_timetable = @id";
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
                    command.CommandText = "DataTableTimeDoctro";
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
                    command.CommandText = "searchInTimeTable";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

        public bool DoctorHaveTimeInThisDay(int idDoctor,TimeSpan time,int idDAy)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "VerificarSeNesseHorarioEeDataOoDoutorAtende";
                    command.CommandType = CommandType.StoredProcedure;// especifica que tipo de comando esta em uso
                    command.Parameters.AddWithValue("@id_dayWeek", idDAy);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@id_doctor", idDoctor);
                    SqlDataReader reader = command.ExecuteReader();//excuta o comando
                    if (reader.HasRows)// tem linhas
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

    }//fim clss
}
