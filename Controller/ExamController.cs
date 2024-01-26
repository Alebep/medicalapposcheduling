using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace Controller
{
    public class ExamController
    {
        ExamDAO Exam = new ExamDAO();
        public bool Alter(int id, string exam)
        {
            return Exam.Alter(id, exam);
        }
        public bool Delete(int id)
        {
            return Exam.Delete(id);
        }
        public bool Insert(string exam)
        {
            return Exam.Insert(exam);
        }
        public DataTable Table()
        {
            return Exam.TableExam();
        }
    }
}
