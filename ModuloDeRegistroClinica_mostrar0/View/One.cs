using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Controller;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class One : Form
    {
        int id=0;
        public One()
        {
            InitializeComponent();
        }

        void CarregarData()
        {
            ConsultationController consultation = new ConsultationController();
            dataGridView1.DataSource = consultation.ConsultationHome();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CarregarData();
            metroComboBoxSpecialty.Items.Add("записан на прием");
            metroComboBoxSpecialty.Items.Add("в очередь");
            metroComboBoxSpecialty.Items.Add("выполняется");
            metroComboBoxSpecialty.Items.Add("проведена");
            metroComboBoxSpecialty.Items.Add("не проведена");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Teste Formulario = new Teste();
            Formulario.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox7_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroComboBoxSpecialty.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_consultation"].Value.ToString());
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (id != 0)
            {
                ConsultationController controller = new ConsultationController();
                if (controller.StatusUpdata(metroComboBoxSpecialty.Text, id))
                {
                    MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarData();
                }
                else
                    MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("надо выбрать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxSearch.Text == string.Empty)
            {
                CarregarData();
                metroTextBoxSearch.Focus();
                metroTextBoxSearch.Text = string.Empty;
            }
            else
            {
                ConsultationController controller = new ConsultationController();
                dataGridView1.DataSource = controller.Search(metroTextBoxSearch.Text);
            }
        }
    }
}