using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using System.Data;
using System.Threading.Tasks;

namespace Controller
{
    public class ConsultationController
    {
        MarcacaoDeConsultasDAO ConsultasDAO = new MarcacaoDeConsultasDAO();
        string erro = string.Empty;
       public bool Insert(DataConsultation consultation)
        {
            return ConsultasDAO.Insert(consultation);
        }
        public bool Delete(int id)
        {
            return ConsultasDAO.Delete(id);
        }
        public bool Alter(DataConsultation consultation)
        {
            return ConsultasDAO.Alter(consultation);
        }
        public DataTable DataTable()
        {
            return ConsultasDAO.Table();
        }
        public DataTable Search(string search)
        {
            return ConsultasDAO.Search(search);
        }
        public string MsgErroConsultation()
        {
            return ConsultasDAO.erro;
        }
        public DataTable ConsultationHome()
        {
            return ConsultasDAO.TableHomeConsultation(DateTime.Today);
        }

        public bool StatusUpdata(string status, int id)
        {
            return ConsultasDAO.StatusUpdata(status, id);
        }
        public DataTable HistoryPatient(int id)
        {
            return ConsultasDAO.HistoryPatiente(id);
        }
    }
}
