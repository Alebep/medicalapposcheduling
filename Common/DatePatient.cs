using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class DatePatient
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patroymi { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public  string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int? Company { get; set; }
        public int Sex { get; set; }
        public DateTime Dateofbirth { get; set; }
    }
}
