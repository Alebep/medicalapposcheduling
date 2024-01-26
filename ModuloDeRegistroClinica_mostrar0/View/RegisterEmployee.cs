using Common;
using Controller;
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

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterEmployee : Form
    {
        string msg;
        public RegisterEmployee()
        {
            InitializeComponent();
        }

        private void RegisterEmployee_Load(object sender, EventArgs e)
        {
            EmployeeController employeeController = new EmployeeController();
            //TornarInvisivelLabels();
            limpar();
            CarregarCombo();
            metroDateTime1.MaxDate = DateTime.Now;
            metroCombBxFSpecialty.DisplayMember = "Name";
            metroCombBxFSpecialty.ValueMember = "id_speciality";
            radioM.Checked = true;
            metroComboBox1.Items.Add("Адиминистратор");
            metroComboBox1.Items.Add("Секретар");
            metroComboBox1.Items.Add("врач");
        }
        private void limpar()
        {
            metroTextBoxNumberCertificate.Enabled = false;
            metroCombBxFSpecialty.Enabled = false;
            maskedTextPhoneNumber.Text = string.Empty;
            metroTxbName.Text = string.Empty;
            metroTxbLastName.Text = string.Empty;
            metroTxbEmail.Text = string.Empty;
            metroTxbPatronymic.Text = string.Empty;
            metroTxbAddress.Text = string.Empty;
            radioF.Checked = false;
            radioM.Checked = true;
            maskedTextBoxPostalCode.Text = string.Empty;
            //+7(   )    -  -
        }
        void CarregarCombo()
        {
            ComboxsController comboxs = new ComboxsController();
            metroCombBxFSpecialty.DataSource = comboxs.Preencherspecialty();

        }
        public void TornarInvisivelLabels()
        {
           /* labelLastName.Visible = false;
            labelName.Visible = false;
            labelPatronymic.Visible = false;
            labelEmail.Visible = false;
            //labelAddress.Visible = false;
            //labelPostalCode.Visible = false;*/
            pictureBoxPostal.Visible = false;
           // labelPhoneNumber.Visible = false;
            pictureBoxAdress.Visible = false;
            pictureBoxDataNasc.Visible = false;
            pictureBoxEmail.Visible = false;
            pictureBoxLastName.Visible = false;
            pictureBoxName.Visible = false;
            pictureBoxPatromic.Visible = false;
            pictureBoxPhone.Visible = false;
           
        }
        private void fechar()
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Uteis uteis = new Uteis();
            string[] error = new string[10];// 0-2-> nomes 3->email; 
            //List<string> error = new List<string>();
            string numberCertificate = string.Empty;
            int idSpecialty = 0;
            string tipico = "Нельзя латинского буквы и нельзя номер;";
            bool temErro = false;
            employee.Patronymic = uteis.NomeDentrosPadroes(ref pictureBoxPatromic, metroTxbPatronymic.Text, ref error[0], ref temErro, tipico);
            employee.LastName = uteis.NomeDentrosPadroes(ref pictureBoxLastName, metroTxbLastName.Text, ref error[1], ref temErro, tipico);
            employee.Name = uteis.NomeDentrosPadroes(ref pictureBoxName, metroTxbName.Text, ref error[2], ref temErro, tipico);

            if (Utilitarios.EmailValido(metroTxbEmail.Text))
            {
                employee.Email = metroTxbEmail.Text;
                pictureBoxEmail.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxEmail.Visible = true;
                if (metroTxbEmail.Text != string.Empty)
                {
                    error[3] = "не правильно Электронная почта";
                }
            }

            if (maskedTextPhoneNumber.Text != "+7(   )    -  -")
            {
                employee.PhoneNumber = maskedTextPhoneNumber.Text;
                pictureBoxPhone.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPhone.Visible = true;
            }

            if (maskedTextBoxPostalCode.Text != "")
            {
                employee.PostalCode = maskedTextBoxPostalCode.Text;
                pictureBoxPostal.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPostal.Visible = true;
            }

            employee.Date_of_birth = metroDateTime1.Value.Date;

            if (metroTxbAddress.Text != "")
            {
                employee.Address = metroTxbAddress.Text;
                pictureBoxAdress.Visible = false;
            }
            else
                pictureBoxAdress.Visible = true;

            if (radioM.Checked)
                employee.FkGender = 1;
            else
                employee.FkGender = 2;

            string msg = null;
            uteis.MeterErrosNaMsg(ref msg, error);

            if (metroComboBox1.SelectedIndex == 0)
                employee.Responsibility = 1;
            else if(metroComboBox1.SelectedIndex==1)
                employee.Responsibility = 2;
            else
                employee.Responsibility = 3;
            if (metroComboBox1.Text == "врач")
            {
                if (metroTextBoxNumberCertificate.Text.Length >= 10 && metroTextBoxNumberCertificate.Text.Length<=12)
                {
                    numberCertificate = metroTextBoxNumberCertificate.Text;
                    pictureBoxNumberCertificate.Visible = false;
                }
                else
                {
                    temErro = true;
                    pictureBoxNumberCertificate.Visible = true;
                }
                if (metroCombBxFSpecialty.SelectedIndex>0)
                {
                    idSpecialty = Convert.ToInt32(metroCombBxFSpecialty.SelectedValue.ToString());
                    pictureBoxSpecialty.Visible = false;
                }
                else
                {
                    temErro = true;
                    pictureBoxSpecialty.Visible = true;
                }
            }
            else
            {
                pictureBoxNumberCertificate.Visible = false;
                pictureBoxSpecialty.Visible = false;
            }
            
            if (!temErro)
            {
               EmployeeController employeeController = new EmployeeController();
               if(employeeController.InsertEmployee(employee, numberCertificate,idSpecialty))
                {
                    
                   if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        limpar();
   
                }
                else
                    MessageBox.Show(" НЕ передал данный \nошибка:" + employeeController.MsgErroEmployee().ToString(), "НЕ Прошле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

            }
        }

        private void pictureBox1LoginFechar_Click(object sender, EventArgs e)
        {
            fechar();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
            TornarInvisivelLabels();
            msg = " ";
            //label8.Text = "";
        }

        private void metroComboBox1_TextChanged(object sender, EventArgs e)
        {
            if(metroComboBox1.Text== "врач")
            {
                metroCombBxFSpecialty.Enabled = true;
                metroTextBoxNumberCertificate.Enabled = true;
            }
            else
            {
                metroCombBxFSpecialty.Enabled = false;
                metroCombBxFSpecialty.SelectedIndex = 0;
                metroTextBoxNumberCertificate.Enabled = false;
                metroTextBoxNumberCertificate.Text = string.Empty;
            }
        }

        private void radioF_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
