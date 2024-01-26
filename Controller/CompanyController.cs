using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using Common;

namespace Controller
{
    public class CompanyController
    {
        CompanyDAO Company = new CompanyDAO();
        public string ErroMsg()
        {
            return Company.erro;
        }
        public DataTable Tabela()
        {
            return Company.TableCompany();
        }
        public bool Alter(Company company)
        {
            return Company.Alter(company);
        }
        public bool Insert(Company company)
        {
            return Company.Insert(company);
        }
        public bool Delete(int id)
        {
            return Company.DeleteCompany(id);
        }
    }
}
