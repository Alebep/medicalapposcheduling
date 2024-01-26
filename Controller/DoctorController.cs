using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace Controller
{
    public class DoctorController
    {
        DoctorDAO Doctor = new DoctorDAO();
        public bool Insert(string numCertificate,int spiciality,int fkEmployee)
        {
            if (numCertificate.Length >= 10 && numCertificate.Length < 12 && spiciality != 0 && spiciality > 0)
                return Doctor.Insert(numCertificate, spiciality, fkEmployee);
            else
                return false;
        }
        public bool Alter(int id,string numCertificate,int spiciality,int fkEmployee)
        {
            if (numCertificate.Length >= 10 && numCertificate.Length <= 12 && spiciality > 0)
                return Doctor.Alter(id,numCertificate, spiciality, fkEmployee);
            else
                return false;
        }

        public bool Delete(int id)
        {
            return Doctor.Delete(id);
        }

        public DataTable Table()
        {
            return Doctor.Table();
        }

        public int ReturnId(int fkEmployee)
        {
            return Doctor.PegarIdComParametros(fkEmployee);
        }

        public DataTable SearchTable(string numberCertificate)
        {
            return Doctor.Search(numberCertificate);
        }
    }
}
