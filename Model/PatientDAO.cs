using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Text;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace Model
{
    public class PatientDAO : connectionSQL
    {
       public string erro;
        public bool RegisterPatient(DatePatient patient) 
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO [dbo].[patient] ([Last_name],[Name],[Patronymic],[Email],[Phone_number],"+ 
                    "[Date_of_birth],[Postal_code],[Address],[fk_company],[fk_gender])"
                    +"VALUES(@Last_name,@Name,@Patronymic,@Email,@Phone_number,@Date_of_birth"
                    +",@Postal_code,@Address,@fk_company,@fk_gender)";
                    command.Parameters.AddWithValue("@Last_name", patient.LastName);
                    command.Parameters.AddWithValue("@Name",patient.Name);
                    command.Parameters.AddWithValue("@Patronymic",patient.Patroymi);
                    command.Parameters.AddWithValue("@Email",patient.Email);
                    command.Parameters.AddWithValue("@Phone_number",patient.PhoneNumber);
                    command.Parameters.AddWithValue("@Date_of_birth",patient.Dateofbirth);
                    command.Parameters.AddWithValue("@Postal_code",patient.PostalCode);
                    command.Parameters.AddWithValue("@Address",patient.Adress);
                    command.Parameters.AddWithValue("@fk_company",patient.Company);
                    command.Parameters.AddWithValue("@fk_gender",patient.Sex);
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
        public bool RegisterPatient(DatePatient patient,int l)// sem convenio
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO [dbo].[patient] ([Last_name],[Name],[Patronymic],[Email],[Phone_number]," +
                    "[Date_of_birth],[Postal_code],[Address],[fk_gender])"
                    + "VALUES(@Last_name,@Name,@Patronymic,@Email,@Phone_number,@Date_of_birth"
                    + ",@Postal_code,@Address,@fk_gender)";
                    command.Parameters.AddWithValue("@Last_name", patient.LastName);
                    command.Parameters.AddWithValue("@Name", patient.Name);
                    command.Parameters.AddWithValue("@Patronymic", patient.Patroymi);
                    command.Parameters.AddWithValue("@Email", patient.Email);
                    command.Parameters.AddWithValue("@Phone_number", patient.PhoneNumber);
                    command.Parameters.AddWithValue("@Date_of_birth", patient.Dateofbirth);
                    command.Parameters.AddWithValue("@Postal_code", patient.PostalCode);
                    command.Parameters.AddWithValue("@Address", patient.Adress);
                    command.Parameters.AddWithValue("@fk_gender", patient.Sex);
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

        public DataTable TabelaPaciente()
        {
            DataTable table = new DataTable();
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var sqlcommand=new SqlCommand())
                {
                    sqlcommand.Connection = connectio;
                    sqlcommand.CommandText = "SELECT * FROM [Clinica].[dbo].[patient]";
                    SqlDataReader read = sqlcommand.ExecuteReader();
                    table.Load(read);
                    return table;
                }
            }
        }

       public bool AlterPatient(DatePatient patient)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "editarPatient";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Last_name", patient.LastName);
                        command.Parameters.AddWithValue("@Name", patient.Name);
                        command.Parameters.AddWithValue("@Patronymic", patient.Patroymi);
                        command.Parameters.AddWithValue("@Email", patient.Email);
                        command.Parameters.AddWithValue("@Phone_number", patient.PhoneNumber);
                        command.Parameters.AddWithValue("@Date_of_birth", patient.Dateofbirth);
                        command.Parameters.AddWithValue("@Postal_code",patient.PostalCode);
                        command.Parameters.AddWithValue("@Address", patient.Adress);
                        command.Parameters.AddWithValue("@fk_company", patient.Company);// quando for igual a zero na base de dados entrara como nulo
                        command.Parameters.AddWithValue("@fk_gender", patient.Sex);
                        command.Parameters.AddWithValue("@id", patient.id);
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

        public bool DeletePatient(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "apagarRgPatient";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id",id);
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public DatePatient NameBirthPatient(int id)
        {
            DatePatient patient= new DatePatient();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select Date_of_birth,CONCAT(Last_name,' ',Name ,' ',Patronymic) as name from patient where id_patient=@id";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();//excuta o comando
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                patient.Name = reader.GetString(1).ToString();
                                patient.Dateofbirth = reader.GetDateTime(0).Date;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        erro = ex.ToString();
                    }
                }
            }
            return patient;
        }
        

    }//fim classe
}
