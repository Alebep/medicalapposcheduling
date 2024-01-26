using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Common;

namespace Model
{
    public class EmployeeDAO : connectionSQL
    {
       public string erro;
       public bool Insert(Employee employee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = "InsertEmployee";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name",employee.Name);
                    command.Parameters.AddWithValue("@Last_Name",employee.LastName);
                    command.Parameters.AddWithValue("@Patronymic",employee.Patronymic);
                    command.Parameters.AddWithValue("@Responsibility",employee.Responsibility);
                    command.Parameters.AddWithValue("@Email",employee.Email);
                    command.Parameters.AddWithValue("@Phone_number",employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Date_of_birth",employee.Date_of_birth);
                    command.Parameters.AddWithValue("@Postal_code",employee.PostalCode);
                    command.Parameters.AddWithValue("@Address",employee.Address);
                    command.Parameters.AddWithValue("@fk_gender",employee.FkGender);
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

        public bool AlterEmployee(Employee employee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText="AlterEmployee";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_employee",employee.IdEmployee);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Last_Name", employee.LastName);
                    command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                    command.Parameters.AddWithValue("@Responsibility", employee.Responsibility);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone_number", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Date_of_birth", employee.Date_of_birth);
                    command.Parameters.AddWithValue("@Postal_code", employee.PostalCode);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@fk_gender", employee.FkGender);
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

        public DataTable TableEmployee()
        {
            DataTable table = new DataTable();
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var sqlcommand = new SqlCommand())
                {
                    sqlcommand.Connection = connectio;
                    sqlcommand.CommandText = "SELECT * FROM [Clinica].[dbo].[Employee]";
                    SqlDataReader read = sqlcommand.ExecuteReader();
                    table.Load(read);
                    return table;
                }
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var sqlcommand = new SqlCommand())
                {
                    sqlcommand.Connection = connectio;
                    sqlcommand.CommandText = "DELETE FROM [dbo].[employee] WHERE Id_employee=@id_employee";
                    sqlcommand.Parameters.AddWithValue("@id_employee", id);
                    try
                    {
                        int i = sqlcommand.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }catch(Exception ex)
                    {
                        erro = ex.ToString();
                        return false;
                    }
                }
            }
        }

        public int PegarIdComParametros(SqlString email)
        {
            int idEmployee = 0;
            using (var conex2 = GetConnection())
            {
                conex2.Open();
                using (var commandnivel = new SqlCommand())
                {
                    commandnivel.Connection = conex2;
                    commandnivel.CommandText = "SELECT [Id_employee] FROM [Clinica].[dbo].[employee] where Email=@email";
                    commandnivel.Parameters.AddWithValue("@email", email);
                    SqlDataReader ler = commandnivel.ExecuteReader();
                    while (ler.Read())
                    {
                        idEmployee = ler.GetInt32(0);
                    }
                }
            }
            return idEmployee;
        }

    }//fim classe
}
