using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace Controller
{
    public class MakeExamController
    {
        MakeExamDAO MakeExamDAO = new MakeExamDAO();
        public bool InsertMakeExam(int idConcul, int idExam, string desc, string value)
        {
            return MakeExamDAO.Insert(idConcul,idExam,desc,value);
        }
        public DataTable MakeExam()
        {
            return MakeExamDAO.TableExam();
        }
    }
}