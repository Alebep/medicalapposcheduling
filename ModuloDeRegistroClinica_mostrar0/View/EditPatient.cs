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
using UtilitariosClasseFrNet;


namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class EditPatient : Form
    {
        public int? Id = null;
        string msg;
        public EditAndDeletePatient editpatient = new EditAndDeletePatient();
        public EditPatient()
        {
            InitializeComponent();
        }

        private void EditPatient_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void metroBtnSendPatient_Click(object sender, EventArgs e)
        {
            DatePatient patient = new DatePatient();
            Uteis uteis = new Uteis();
            string[] error = new string[10];// 0-2-> nomes 3->email; 
            //List<string> error = new List<string>();
            string tipico = "Нельзя латинского буквы и нельзя номер;";
            bool temErro = false;
            patient.Patroymi = uteis.NomeDentrosPadroes(ref pictureBoxPatromic, metroTxbPatronymic.Text, ref error[0], ref temErro, tipico);
            patient.LastName = uteis.NomeDentrosPadroes(ref pictureBoxLastName, metroTxbLastName.Text, ref error[1], ref temErro, tipico);
            patient.Name = uteis.NomeDentrosPadroes(ref pictureBoxName, metroTxbName.Text, ref error[2], ref temErro, tipico);

            if (Utilitarios.EmailValido(metroTxbEmail.Text))
            {
                patient.Email = metroTxbEmail.Text;
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
                patient.PhoneNumber = maskedTextPhoneNumber.Text;
                pictureBoxPhone.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPhone.Visible = true;
            }

            if (maskedTextBoxPostalCode.Text != "")
            {
                patient.PostalCode = maskedTextBoxPostalCode.Text;
                pictureBoxPostal.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPostal.Visible = true;
            }

            patient.Dateofbirth = metroDateTime1.Value.Date;

            if (metroTxbAddress.Text != "")
            {
                patient.Adress = metroTxbAddress.Text;
                pictureBoxAdress.Visible = false;
            }
            else
                pictureBoxAdress.Visible = true;

            if (radioM.Checked)
                patient.Sex = 1;
            else
                patient.Sex = 2;

            uteis.MeterErrosNaMsg(ref msg, error);

            if (metroCombBxTmSeguro.SelectedIndex == 0)
            {
                patient.Company = null;
            }
            else
            {
                patient.Company = Convert.ToInt32(metroCombBxFkTypeContract.SelectedValue);//item selecionado combobox
                metroCombBxFkTypeContract.Enabled = true;
            }

            if (!temErro)
            {
                PatientCotroller patientCotroller = new PatientCotroller();
                Class1 mensagem = new Class1();
                patient.id = (int) Id;
                if (patientCotroller.AlterarPatient(patient))
                {
                    editpatient.MostrarPatient();
                    if (MessageBox.Show(mensagem.msgSucessModif, mensagem.success, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        this.Close();
                }
                else
                {
                    MessageBox.Show(" НЕ передал данный \nошибка:" + patientCotroller.ErroRegisterMsg().ToString(), "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroCombBxTmSeguro_TextChanged(object sender, EventArgs e)
        {
            if (metroCombBxTmSeguro.SelectedIndex == 0)
                metroCombBxFkTypeContract.Enabled = false;
            else
                metroCombBxFkTypeContract.Enabled = true;
        }

        private void pictureBox1LoginFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
