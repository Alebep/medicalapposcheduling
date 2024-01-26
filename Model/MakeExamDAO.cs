using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class MakeExamDAO: connectionSQL
    {
        public bool Insert(int idConcul, int idExam, string desc, string value)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "InsertMakeExam";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_cons", idConcul);
                    command.Parameters.AddWithValue("@id_exm", idExam);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@value", value);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool Alter(int idConcul, int idExam, string desc, string value)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "AlterMakeExam";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_cons", idConcul);
                    command.Parameters.AddWithValue("@id_exm", idExam);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@value", value);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Delete(int idConcul, int idExam)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "DELETE FROM [dbo].[make_exam] WHERE id_consultation=@id_consul and id_exam=@id_exm";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id_consul", idConcul);
                    command.Parameters.AddWithValue("@id_exm", idExam);
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
                    command.CommandText = "SELECT * FROM [dbo].[PatientExam]";
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }
    }// fim classe
}
