using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class connectionSQL
    {
        private readonly string connectionToSQL;
        public connectionSQL()
        {
            connectionToSQL = @"Data Source=tcp:DESKTOP-RGEUDPI\SQLEXPRESS,49500;Initial Catalog=Clinica;Persist Security Info=True;User ID=AcessAppClinica;Password=alex ";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionToSQL);
        }
    }
}
