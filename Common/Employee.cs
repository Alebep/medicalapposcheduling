using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Common
{
   public class Employee
    {
        public SqlInt32 IdEmployee { set; get; }
        public SqlString Name { set; get; }
        public SqlString LastName { set; get; }
        public SqlString Patronymic { set; get; }
        public SqlInt32 Responsibility { set; get; }
        public SqlString Email { set; get; }
        public SqlString PhoneNumber { set; get; }
        public DateTime Date_of_birth { set; get; }
        public SqlString PostalCode { set; get; }
        public SqlString Address { set; get; }
        public int FkGender { set; get; } 

        
        
        
    }
}
