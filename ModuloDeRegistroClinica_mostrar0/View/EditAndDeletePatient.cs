using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Windows.Forms;
using Controller;
using Controller.cache;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class EditAndDeletePatient : Form
    {
        public EditAndDeletePatient()
        {
            InitializeComponent();
        }

        public void MostrarPatient()
        {
            PatientCotroller patient = new PatientCotroller();
            dataGridView1.DataSource = patient.TablePatient();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditAndDeletePatient_Load(object sender, EventArgs e)
        {
            MostrarPatient();
            if (UserLoginCache.Nivel==2)
            {
                BtnApagar.Visible = false;
                BtnEditPatient.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPatient editPatient = new EditPatient();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool t = false;
                ComboxsController combox = new ComboxsController();
                editPatient.metroTxbName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                editPatient.metroTxbLastName.Text = dataGridView1.CurrentRow.Cells["Last_name"].Value.ToString();
                editPatient.metroDateTime1.Text = dataGridView1.CurrentRow.Cells["Date_of_birth"].Value.ToString();
                editPatient.metroTxbEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                editPatient.metroTxbAddress.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                editPatient.metroTxbPatronymic.Text = dataGridView1.CurrentRow.Cells["Patronymic"].Value.ToString();
                editPatient.maskedTextBoxPostalCode.Text = dataGridView1.CurrentRow.Cells["Postal_code"].Value.ToString();
                //editPatient.metroCombBxTmSeguro.Text= dataGridView1.CurrentRow.Cells[""];
                editPatient.metroCombBxFkTypeContract.DataSource = combox.PreencherComBoxCompany();
                editPatient.metroCombBxFkTypeContract.ValueMember = "id_company";
                editPatient.metroCombBxFkTypeContract.DisplayMember = "Name";
                try
                {
                    editPatient.metroCombBxFkTypeContract.SelectedValue = dataGridView1.CurrentRow.Cells["fk_company"].Value.ToString();// selecao combpox apartor da BD
                }
                catch
                {
                    t = true;
                }
                editPatient.metroCombBxTmSeguro.Items.Add("Частный");
                editPatient.metroCombBxTmSeguro.Items.Add("медицинская страховка");
                if (t)
                    editPatient.metroCombBxTmSeguro.SelectedIndex = 0;
                else
                    editPatient.metroCombBxTmSeguro.SelectedIndex = 1;
                editPatient.maskedTextPhoneNumber.Text = dataGridView1.CurrentRow.Cells["Phone_number"].Value.ToString();
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["fk_gender"].Value.ToString()) == 1)
                    editPatient.radioM.Select();
                else
                    editPatient.radioF.Select();
                editPatient.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_patient"].Value.ToString());
                editPatient.editpatient = this;//passei essa classe com propriedade da classe editPatient
                editPatient.Show();
            }
            else
                MessageBox.Show("надо выбрать строка");
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            PatientCotroller PatientCotroller = new PatientCotroller();
            Class1 mensagem = new Class1();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (PatientCotroller.DeletePatient(dataGridView1.CurrentRow.Cells["id_patient"].Value.ToString()))
                {
                    if (MessageBox.Show(mensagem.msgSucessDelete, "Удаление", MessageBoxButtons.OK) == DialogResult.OK)
                        MostrarPatient();
                }
                else
                    MessageBox.Show("Не удалил данние", "Oщибко", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("надо выбрать строка");
        }
    }//fim class
}
