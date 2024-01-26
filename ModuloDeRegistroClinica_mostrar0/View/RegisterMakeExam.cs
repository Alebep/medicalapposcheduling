using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Common;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterMakeExam : Form
    {
        public RegisterMakeExam()
        {
            InitializeComponent();
        }
        void Limpar()
        {
            metroCombBxConsultation.SelectedIndex = 0;
            metroComboBoxExam.SelectedIndex = 0;
            richTextBox1.Text = string.Empty;
            metroTextBoxNumberCertificate.Text = string.Empty;
        }
        void Carregar()
        {
            MakeExamController makeExam = new MakeExamController();
            dataGridView1.DataSource = makeExam.MakeExam();
        }
        void CarreharCombox()
        {
            ComboxsController comboxs = new ComboxsController();
            metroCombBxConsultation.DataSource = comboxs.PreencherConsultation();
            metroCombBxConsultation.DisplayMember = "Name";
            metroCombBxConsultation.ValueMember = "id_consultation";
            metroComboBoxExam.DataSource = comboxs.PreecherExame();
            metroComboBoxExam.DisplayMember = "exam";
            metroComboBoxExam.ValueMember = "id_exam";

        }
        private void RegisterMakeExam_Load(object sender, EventArgs e)
        {
            Carregar();
            CarreharCombox();
        }

        private void metroButtonSend_Click(object sender, EventArgs e)
        {
            MakeExamController makeExam = new MakeExamController();
            if (makeExam.InsertMakeExam(Convert.ToInt32(metroCombBxConsultation.SelectedValue), Convert.ToInt32(metroComboBoxExam.SelectedValue), richTextBox1.Text, metroTextBoxNumberCertificate.Text))
            {
                Class1 mesg = new Class1();
                MessageBox.Show(mesg.msgSucess,mesg.success,MessageBoxButtons.OK,MessageBoxIcon.Information);
                CarreharCombox();
                Carregar();
                Limpar();
            }
        }

        private void metroButtonClear_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
