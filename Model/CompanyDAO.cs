using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class CompanyDAO : connectionSQL
    {
        public string erro = string.Empty;
        public bool Insert(Company company)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertCompany";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name",company.Name);
                    command.Parameters.AddWithValue("@Phone_number",company.Phone_number);
                    command.Parameters.AddWithValue("@Address",company.Adrees);
                    command.Parameters.AddWithValue("@Email",company.Email);
                    try
                    {
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

        public bool Alter(Company company)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "AlterCompany";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", company.Id_company);
                    command.Parameters.AddWithValue("@Name", company.Name);
                    command.Parameters.AddWithValue("@Phone_number", company.Phone_number);
                    command.Parameters.AddWithValue("@Address", company.Adrees);
                    command.Parameters.AddWithValue("@Email", company.Email);
                    try
                    {
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

        public bool DeleteCompany(int id)
        {
            using (var connectio = GetConnection())
            {
                connectio.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connectio;
                    command.CommandText = "DELETE FROM [dbo].[Company] WHERE id_company=@id";
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

        public DataTable TableCompany()
        {
            DataTable CompanyTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Clinica].[dbo].[Company]";
                    SqlDataReader company = command.ExecuteReader();
                    CompanyTable.Load(company);
                }
            }
            return CompanyTable;
        }

    }//fim class
}
