using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Model
{
   public class DoctorDAO : connectionSQL
    {
        public string erro = string.Empty;
        public bool Insert(string numberCertificate, int specialty,int fkEmployee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "inserirDoctor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fkemployee", fkEmployee);
                    command.Parameters.AddWithValue("@NumeroLicenca", numberCertificate);
                    command.Parameters.AddWithValue("@specialty", specialty);
                    try
                    {
                        erro = string.Empty;
                        int i = command.ExecuteNonQuery();
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
        //
        public bool Alter(int id,string numberCertificate, int specialty, int fkEmployee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "AlterarDoctor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@fkemployee", fkEmployee);
                    command.Parameters.AddWithValue("@NumeroLicenca", numberCertificate);
                    command.Parameters.AddWithValue("@specialty", specialty);
                    try
                    {
                        erro = string.Empty;
                        int i = command.ExecuteNonQuery();
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
        //
        public bool Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [dbo].[doctor] WHERE id_doctor=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        erro = string.Empty;
                        int i = command.ExecuteNonQuery();
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
                    command.CommandText = "SELECT id_doctor,fk_id_employee, e.Last_Name as фамиля,num_prof_medical_certificate,fk_specialty as id_specialty, sp.specialty FROM [Clinica].[dbo].[doctor] as dc left outer join employee as e on dc.fk_id_employee=e.Id_employee left outer join speciality as sp on dc.fk_specialty=sp.id_speciality";
                    command.CommandType = CommandType.Text;
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

        public int PegarIdComParametros(int fkEmployee)
        {
            int idDoctor = 0;
            using (var conex2 = GetConnection())
            {
                conex2.Open();
                using (var commandnivel = new SqlCommand())
                {
                    commandnivel.Connection = conex2;
                    commandnivel.CommandText = "SELECT id_doctor from doctor where fk_id_employee=@id";
                    commandnivel.CommandType = CommandType.Text;
                    commandnivel.Parameters.AddWithValue("@id", fkEmployee);
                    SqlDataReader ler = commandnivel.ExecuteReader();
                    while (ler.Read())
                    {
                        idDoctor = ler.GetInt32(0);
                    }
                }
            }
            return idDoctor;
        }

        public DataTable Search(string numberCertificate)
        {
            using (var conex2 = GetConnection())
            {
                conex2.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conex2;
                    command.CommandText = "SearchDoctor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", numberCertificate);
                    SqlDataReader read = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(read);
                    return table;
                }
            }
        }

    }//fim classe
}
