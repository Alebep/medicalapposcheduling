using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;
using Common;
using System.Data;

namespace Controller
{
   public class PatientCotroller
    {
        PatientDAO patientDAO = new PatientDAO();
        public bool RegisterPatient(DatePatient patient,bool ePrivado)
        {
            if (ePrivado)
                return patientDAO.RegisterPatient(patient,1);//privado
            else
                return patientDAO.RegisterPatient(patient);
        }
        public string ErroRegisterMsg()
        {
            return patientDAO.erro;
        }
        public DataTable TablePatient()
        {
           return patientDAO.TabelaPaciente();
        }
        public bool AlterarPatient(DatePatient patient)
        {
            if (patient.Company == null)
                patient.Company = 0;
            return patientDAO.AlterPatient(patient);
        }

        public bool DeletePatient(string id)
        {
            return patientDAO.DeletePatient(Convert.ToInt32(id));
        }
        public DatePatient NameBirthPatient(int id)
        {
            return patientDAO.NameBirthPatient(id);
        }
    }
}
