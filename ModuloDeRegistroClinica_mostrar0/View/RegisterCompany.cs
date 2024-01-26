using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosClasseFrNet;
using Common;
using Controller;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterCompany : Form
    {
        bool editar = false;
        int id = 0;
        public RegisterCompany()
        {
            InitializeComponent();
        }

        private void RegisterCompany_Load(object sender, EventArgs e)
        {
            atualizar();
        }
        private void atualizar()
        {
            CompanyController TableCompany = new CompanyController();
            dataGridView1.DataSource = TableCompany.Tabela();
        }
        private void limpar()
        {
            editar = false;
            id = 0;
            metroTxbAddress.Text = string.Empty;
            metroTxbEmail.Text = string.Empty;
            metroTextBox1.Text = string.Empty;
            maskedTextPhoneNumber.Text = string.Empty;
            pictureBox1.Visible = false;
            pictureBoxAdress.Visible = false;
            pictureBoxEmail.Visible = false;
            pictureBoxPhone.Visible = false;
        }
        private void metroBtnSendPatient_Click(object sender, EventArgs e)
        {
            bool temErro = false;
            Company company = new Company();
            if(metroTxbAddress.Text==string.Empty)
            {
                pictureBoxAdress.Visible = true;
                temErro = true;
            }
            else
            {
                company.Adrees = metroTxbAddress.Text;
                pictureBoxAdress.Visible = false;
            }
            if (metroTextBox1.Text == string.Empty)
            {
                temErro = true;
                pictureBox1.Visible = true;
            }
            else
            {
                company.Name = metroTextBox1.Text;
                pictureBox1.Visible = false;
            }
            if (Utilitarios.EmailValido(metroTxbEmail.Text))
            {
                company.Email = metroTxbEmail.Text; 
                pictureBoxEmail.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxEmail.Visible = true;
            }

            if (maskedTextPhoneNumber.Text != "+7(   )    -  -")
            {
                company.Phone_number = maskedTextPhoneNumber.Text;
                pictureBoxPhone.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPhone.Visible = true;
            }
            if (!temErro)
            {
                CompanyController companyController = new CompanyController();
                if (!editar)
                {
                    if (companyController.Insert(company))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            atualizar();
                        }
                    }
                    else
                        if (MessageBox.Show(" НЕ Передал данный" + companyController.ErroMsg().ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        atualizar();
                }
                else
                {
                    company.Id_company = id;
                    if (companyController.Alter(company))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            atualizar();
                        }
                    }
                    else
                        if (MessageBox.Show(" НЕ Передал данный" + companyController.ErroMsg().ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            atualizar();
                }
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroTextBox1.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                maskedTextPhoneNumber.Text = dataGridView1.CurrentRow.Cells["Phone_number"].Value.ToString();
                metroTxbAddress.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                metroTxbEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                editar = true;
                id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_company"].Value.ToString());
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CompanyController company = new CompanyController();
                if (Perguntar.Fperguntar("вы точно хотитие удалить", "Удалить"))
                {
                    if (company.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_company"].Value.ToString())))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            limpar();
                            atualizar();
                        }
                    }
                    else
                        if (MessageBox.Show(" НЕ Передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        atualizar();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }//fim classe
}
