using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using Model;
using System.Data.SqlTypes;

namespace Controller
{
    public class EmployeeController
    {
        private EmployeeDAO EmployeeeDAO = new EmployeeDAO();
        
        public string MsgErroEmployee()
        {
            return EmployeeeDAO.erro;
        }
        public bool InsertEmployee(Employee employee, string numberCertificate,int specialty)
        {
            if (employee.Patronymic == null)
                employee.Patronymic = SqlString.Null;
            if (employee.Email == null)
                employee.Email = SqlString.Null;
            if (employee.PostalCode == null)
                employee.PostalCode = SqlString.Null;

            if (numberCertificate == string.Empty)
            {
                return EmployeeeDAO.Insert(employee);
            }
            else if (numberCertificate.Length >= 10 && EmployeeeDAO.Insert(employee))
            {
                DoctorDAO Doctor = new DoctorDAO();
                return Doctor.Insert(numberCertificate,specialty, EmployeeeDAO.PegarIdComParametros(employee.Email));//meter doutor
            }
            else
            {
                return false;
            }
        
            
        }

        public bool AlterEmployee(Employee employee)
        {
            if (employee.Patronymic == null)
                employee.Patronymic = SqlString.Null;
            if (employee.Email == null)
                employee.Email = SqlString.Null;
            if (employee.PostalCode == null)
                employee.PostalCode = SqlString.Null;
            return EmployeeeDAO.AlterEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return EmployeeeDAO.DeleteEmployee(id);
        }

        public DataTable TableEmployee()
        {
            return EmployeeeDAO.TableEmployee();
        }

        /*public string teste(string email)
        {
            return Convert.ToString(EmployeeeDAO.PegarIdComParametros(email));
        }*/
    }

}
