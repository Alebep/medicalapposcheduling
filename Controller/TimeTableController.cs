using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using System.Data;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace Controller
{
    public class TimeTableController
    {
        TimetableDAO TimetableDAO = new TimetableDAO();
        public bool Insert(TimeDoctor timeDoctorDate)
        {
            return TimetableDAO.Insert(timeDoctorDate.FkDoctor,timeDoctorDate.EntryTime,timeDoctorDate.DepartureTime,timeDoctorDate.FkDayweek);
        }
        public bool Alter(TimeDoctor timeDoctorDate)
        {
            return TimetableDAO.Alter(timeDoctorDate);
        }
        public bool Delete(int id)
        {
            return TimetableDAO.Delete(id);
        }
        public DataTable Table()
        {
            return TimetableDAO.Table();
        }
        public DataTable Search(string name)
        {
            return TimetableDAO.Search(name);
        }
        public string Error()
        {
            return TimetableDAO.erro;
        }

        public bool DoctorHaveTimeThisDAy(int idDoctor,int idDay,TimeSpan time)
        {
            return TimetableDAO.DoctorHaveTimeInThisDay(idDoctor,time,idDay);
        }
    }
}
