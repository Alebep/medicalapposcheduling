using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;
using System.Data;

namespace Model
{
    public class ComboBoxsTodasDAO : connectionSQL
    {
        public DataTable ComboxPatient()
        {
            DataTable Patient = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_patient, CONCAT(Last_name,' ',Name) as Name from [Clinica].[dbo].[patient]";
                    SqlDataReader company = command.ExecuteReader();
                    Patient.Load(company);
                    DataRow row = Patient.NewRow();
                    row["Name"] = "";
                    Patient.Rows.InsertAt(row, 0);
                }
            }
            return Patient;
        }
        public DataTable ComboBoxCompany()
        {
            DataTable CompanyTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Clinica].[dbo].[Company]";
                    SqlDataReader company = command.ExecuteReader();
                    CompanyTable.Load(company);
                    DataRow row = CompanyTable.NewRow();
                    row["Name"] = "";
                    row["Phone_number"] = "";
                    row["Address"] = "";
                    row["Email"] = "";
                    CompanyTable.Rows.InsertAt(row, 0);
                }
            }
                return CompanyTable;
        }

        public DataTable ComboBoxEmployee()
        {
            DataTable employeeTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT [Id_employee],concat([Name],' ',[Last_Name]) as Name FROM [Clinica].[dbo].[employee]";
                    SqlDataReader Table = command.ExecuteReader();
                    employeeTable.Load(Table);
                    DataRow row = employeeTable.NewRow();
                    row["Name"] = "";
                    employeeTable.Rows.InsertAt(row, 0);
                }
            }
            return employeeTable;
        }

        public DataTable ComboBoxEmployeeforUser()
        {
            DataTable employeeTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EmployeeUser";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Table = command.ExecuteReader();
                    employeeTable.Load(Table);
                    DataRow row = employeeTable.NewRow();
                    row["Name"] = "";
                    employeeTable.Rows.InsertAt(row, 0);
                }
            }
            return employeeTable;
        }

        public DataTable ComboBoxEmployeePaaaDoctor()
        {
            DataTable employeeTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CarregarComboxEmployeeComOsDoctors";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Table = command.ExecuteReader();
                    employeeTable.Load(Table);
                    DataRow row = employeeTable.NewRow();
                    row["Name"] = "";
                    employeeTable.Rows.InsertAt(row, 0);
                }
            }
            return employeeTable;
        }

        public DataTable ComboBoxSpeciality()
        {
            DataTable specialityTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT [id_speciality],[specialty] as Name FROM [Clinica].[dbo].[speciality]";
                    SqlDataReader Table = command.ExecuteReader();
                    specialityTable.Load(Table);
                    DataRow row = specialityTable.NewRow();
                    row["Name"] = "";
                    specialityTable.Rows.InsertAt(row, 0);
                }
            }
            return specialityTable;
        }
      
        public DataTable ComboBoxDoutorListaDosDoutores()
        {
            DataTable doctor = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ComboBoxDoutores";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Table = command.ExecuteReader();
                    doctor.Load(Table);
                    DataRow row = doctor.NewRow();
                    row["Name"] = "";
                    doctor.Rows.InsertAt(row, 0);
                }
            }
            return doctor;
        }

        public DataTable ComboBoxDayWeek()
        {
            DataTable dayWeek = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from dayWeek";
                    SqlDataReader Table = command.ExecuteReader();
                    dayWeek.Load(Table);
                    DataRow row = dayWeek.NewRow();
                    row["day"] = "";
                    dayWeek.Rows.InsertAt(row, 0);
                }
            }
            return dayWeek;
        }

        public DataTable DoctorSpecialty(string search)
        {
            DataTable doctor = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarOoDoutorPelaEspecialidade";
                    command.Parameters.AddWithValue("@specialty",search);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Table = command.ExecuteReader();
                    doctor.Load(Table);
                    DataRow row = doctor.NewRow();
                    row["Name"] = "";
                    doctor.Rows.InsertAt(row, 0);
                }
            }
            return doctor;
        }
        
        public DataTable Consultation()
        {
            DataTable consultation = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "PreencherConsultation";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Table = command.ExecuteReader();
                    consultation.Load(Table);
                    DataRow row = consultation.NewRow();
                    row["Name"] = "";
                    consultation.Rows.InsertAt(row,0);
                }
            }
            return consultation;
        }

        public DataTable Exame()
        {
            DataTable exame = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT [id_exam],[exam]FROM [Clinica].[dbo].[exam]";
                    command.CommandType = CommandType.Text;
                    SqlDataReader Table = command.ExecuteReader();
                    exame.Load(Table);
                    DataRow row = exame.NewRow();
                    row["exam"] = "";
                    exame.Rows.InsertAt(row, 0);
                }
            }
            return exame;
        }

    }//fim class
}
