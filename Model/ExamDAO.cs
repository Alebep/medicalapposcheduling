using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class ExamDAO : connectionSQL
    {
        public bool Insert(string exam)
        {
            using (var connectio = GetConnection() )
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "INSERT INTO [dbo].[exam] ([exam])VALUES (@exam)";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@exam",exam);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Alter(int id,string exam)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "UPDATE [dbo].[exam] SET [exam] = @exam WHERE id_exam=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@exam", exam);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Delete(int id)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "DELETE FROM [dbo].[exam] WHERE id_exam=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public DataTable TableExam()
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "SELECT [id_exam],[exam] as осмотры FROM [Clinica].[dbo].[exam]";
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

    }//fim class
}