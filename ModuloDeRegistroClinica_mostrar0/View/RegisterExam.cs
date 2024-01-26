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
using Controller.cache;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterExam : Form
    {
        bool editar = false;
        int id = 0;
        public RegisterExam()
        {
            InitializeComponent();
        }

        private void RegisterExam_Load(object sender, EventArgs e)
        {
            CarregarData();
            if (UserLoginCache.Nivel == 2)
            {
                metroButton3.Enabled = false;
                metroButton3.Visible = false;
                metroButton2.Enabled = false;
                metroButton2.Visible = false;
            }
        }
        void CarregarData()
        {
            ExamController exam = new ExamController();
            dataGridView1.DataSource = exam.Table();
        }
        void limpar()
        {
            editar = false;
            pictureBoxPatromic.Visible = false;
            metroTextBox1.Text = string.Empty;
            metroTxbLastName.Text = string.Empty;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool temErro = false;
            Uteis uteis = new Uteis();
            string[] error = new string[5];
            string tipico=string.Empty;
            string exam = uteis.NomeDentrosPadroes(ref pictureBoxPatromic, metroTxbLastName.Text, ref error[0], ref temErro, tipico);
            if (!temErro)
            {
                 ExamController examController = new ExamController();
                if (!editar)
                {
                    if (examController.Insert(exam))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            CarregarData();
                        }
                        
                    }
                    else
                        if (MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            CarregarData();
                }
                else
                {
                    if (examController.Alter(id, exam))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            CarregarData();
                        }
                    }
                    else
                        MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroTxbLastName.Text = dataGridView1.CurrentRow.Cells["осмотры"].Value.ToString();
                editar = true;
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_exam"].Value.ToString());
                metroTextBox1.Text = Convert.ToString(id);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ExamController controller = new ExamController();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_exam"].Value.ToString());
                if (Perguntar.Fperguntar("вы точно хотитие удалить", "Удалить"))
                {
                    if (controller.Delete(id))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            CarregarData();
                        }
                    }
                    else
                        MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
