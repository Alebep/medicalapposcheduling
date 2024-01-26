using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Controller;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterDoctor : Form
    {
        bool editar = false;
        int id = 0;
        public RegisterDoctor()
        {
            InitializeComponent();
        }

        private void RegisterDoctor_Load(object sender, EventArgs e)
        {
            AtualizarDatagrid();
            CarregarCombo();
            metroCombBxFSpecialty.DisplayMember = "Name";
            metroCombBxFSpecialty.ValueMember = "id_speciality";
            metroComboBoxEmployye.DisplayMember = "Name";
            metroComboBoxEmployye.ValueMember = "id_employee";
        }

        void CarregarCombo()
        {
            ComboxsController comboxs = new ComboxsController();
            metroCombBxFSpecialty.DataSource = comboxs.Preencherspecialty();
            metroComboBoxEmployye.DataSource = comboxs.PreencheremployeeParaDoctor();
        }
        void Limpar()
        {
            metroCombBxFSpecialty.SelectedIndex =0;
            metroComboBoxEmployye.SelectedIndex = 0;
            metroTextBoxNumberCertificate.Text = string.Empty;
            metroTextBoxSearch.Text = string.Empty;
            editar = false;
            id = 0;
        }
        void AtualizarDatagrid()
        {
            DoctorController DataGrid = new DoctorController();
            dataGridView1.DataSource = DataGrid.Table();
        }

        private void metroButtonSend_Click(object sender, EventArgs e)
        {
            DoctorController dc = new DoctorController();
            bool temErro = false;
            string sp = string.Empty, cod= string.Empty;
            int idemployee = 0;
            if (metroTextBoxNumberCertificate.Text == string.Empty || metroTextBoxNumberCertificate.Text.Length >12 || metroTextBoxNumberCertificate.Text.Length<9)
            {
                pictureBoxNumberCertificate.Visible = true;
                temErro = true;
            }
            else
            {
                cod = metroTextBoxNumberCertificate.Text;
                pictureBoxNumberCertificate.Visible = false;
            }
            if (metroCombBxFSpecialty.SelectedIndex>0)
            {
                sp = metroCombBxFSpecialty.SelectedValue.ToString();
                pictureBoxSpecialty.Visible = false;
            }
            else
            {
                pictureBoxSpecialty.Visible = true;
                temErro = true;
            }
            if (metroComboBoxEmployye.SelectedIndex > 0)
            {
                pictureBoxEmployee.Visible = false;
                idemployee = Convert.ToInt32(metroComboBoxEmployye.SelectedValue);
            }
            else
            {
                temErro = true;
                pictureBoxEmployee.Visible = true;
            }
            if (!temErro)
            {
                DoctorController doctor = new DoctorController();
                if (editar)
                {
                    if (doctor.Alter(id, cod, Convert.ToInt32(sp), idemployee)) 
                    { 
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            AtualizarDatagrid();
                            CarregarCombo();
                        } 
                    }
                    else
                        MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (doctor.Insert(cod,Convert.ToInt32(sp),idemployee))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            AtualizarDatagrid();
                            CarregarCombo();
                        }
                    }
                    else
                        MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxSearch.Text == string.Empty)
            {
                AtualizarDatagrid();
                metroTextBoxSearch.Text = string.Empty;
                metroTextBoxSearch.Focus();
            }
            else
            {
                DoctorController controllerDc= new DoctorController();
                dataGridView1.DataSource = controllerDc.SearchTable(metroTextBoxSearch.Text);
            }
        }

        private void metroButtonClear_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void metroButtonAlter_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroTextBoxNumberCertificate.Text = dataGridView1.CurrentRow.Cells["num_prof_medical_certificate"].Value.ToString();
                metroCombBxFSpecialty.SelectedValue = dataGridView1.CurrentRow.Cells["id_specialty"].Value;
                metroComboBoxEmployye.SelectedValue = dataGridView1.CurrentRow.Cells["fk_id_employee"].Value;
                editar = true;
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_doctor"].Value.ToString());
                //metroTextBox1.Text = Convert.ToString(id);
            }
        }

        private void metroButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Perguntar.Fperguntar("Точно хотитие удалить", "удалить?"))
                {
                    DoctorController doctor = new DoctorController();
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_doctor"].Value.ToString());
                    if (doctor.Delete(id))
                    {
                        if (MessageBox.Show("удалил", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            AtualizarDatagrid();
                        }
                    }
                    else
                        MessageBox.Show("Не удалил", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
