using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Common;
using System.Windows.Forms;
using UtilitariosClasseFrNet;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class EditEmployee : Form
    {
        internal int id;
        internal EditDeleteEmployee EditDeleteEmployee;
        public EditEmployee()
        {
            InitializeComponent();
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void metroBtnSendPatient_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Uteis uteis = new Uteis();
            string[] error = new string[10];// 0-2-> nomes 3->email; 
            //List<string> error = new List<string>();
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
            else if (metroComboBox1.SelectedIndex == 1)
                employee.Responsibility = 2;
            else
                employee.Responsibility = 3;

            if (!temErro)
            {
                EmployeeController employeeController = new EmployeeController();
                Class1 mensagem = new Class1();
                employee.IdEmployee = id;
                if (employeeController.AlterEmployee(employee))
                {
                    this.Close();
                    if (MessageBox.Show(mensagem.msgSucessModif, mensagem.success, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        EditDeleteEmployee.Atualizar();
                        //this.Close();
                    }
                }
                else
                    MessageBox.Show(" НЕ передал данный \nошибка:" + employeeController.MsgErroEmployee().ToString(), "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
