using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class TimeDoctor
    {
        public int Idtimetable { get; set; }
        public int FkDoctor { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int FkDayweek { get; set; }
    }
}
