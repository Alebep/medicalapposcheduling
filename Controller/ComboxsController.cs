using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace Controller
{
   public class ComboxsController
    {
        ComboBoxsTodasDAO ComboBoxsTodas = new ComboBoxsTodasDAO();
        public DataTable PreencherComBoxCompany()
        {
            return ComboBoxsTodas.ComboBoxCompany();
        }
        public DataTable Preencheremployee()
        {
            return ComboBoxsTodas.ComboBoxEmployee();
        }
        public DataTable PreencheremployeeParaDoctor()
        {
            return ComboBoxsTodas.ComboBoxEmployeePaaaDoctor();
        }
        public DataTable Preencherspecialty()
        {
            return ComboBoxsTodas.ComboBoxSpeciality();
        }
        public DataTable PreencherDoctor()
        {
            return ComboBoxsTodas.ComboBoxDoutorListaDosDoutores();
        }
        public DataTable PreencherDayWeek()
        {
            return ComboBoxsTodas.ComboBoxDayWeek();
        }
        public DataTable PreencherSearchInDoctorBySpecialty(String specialty)
        {
            return ComboBoxsTodas.DoctorSpecialty(specialty);
        }

        public DataTable PreencherPatient()
        {
            return ComboBoxsTodas.ComboxPatient();
        }
        public DataTable ComboBoxEmployeeforUser()
        {
            return ComboBoxsTodas.ComboBoxEmployeeforUser();
        }

        public DataTable PreecherExame()
        {
            return ComboBoxsTodas.Exame();
        }
        public DataTable PreencherConsultation()
        {
            return ComboBoxsTodas.Consultation();
        }
    }
}
