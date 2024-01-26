using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Common
{
    public class DataConsultation
    {
        public int Id { get; set; }
        public int Fkdoctor { get; set; }
        public int Fk_patient { set; get; }
        public int Fk_user { set; get; }
        public DateTime Date { set; get; }
        public SqlDouble? Weight { set; get; }
        public SqlDouble? Heart_rate { set; get; }
        public SqlDouble? Height { set; get; }
        public SqlString? Prognostic { set; get; }
        public SqlInt16? Reconsult { set; get; }
        public SqlInt16? Id_past_consultation { set; get; }
        public TimeSpan Time { set; get; }
        public string Status { set; get; }
    }
}
