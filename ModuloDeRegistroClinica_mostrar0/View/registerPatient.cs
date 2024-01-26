using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using System.Text.RegularExpressions;
using Common;
using UtilitariosClasseFrNet;
using Verificar_se_tem_letras_em_russo_ou_lantina;
using System.Windows.Forms;
using Controller;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class registerPatient : Form
    {
        string msg = " ";
        public registerPatient()
        {
            InitializeComponent();
        }
        private void registerPatient_Load(object sender, EventArgs e)
        {
            ComboxsController comboxsController = new ComboxsController();
            TornarInvisivelLabels();
            metroDateTime1.MaxDate = DateTime.Now;
            radioM.Checked = true;
            metroCombBxTmSeguro.Items.Add("Частный");
            metroCombBxTmSeguro.Items.Add("медицинская страховка");
            metroCombBxTmSeguro.SelectedIndex = 0;
            metroCombBxFkTypeContract.Enabled = false;
            metroCombBxFkTypeContract.DataSource = comboxsController.PreencherComBoxCompany();
            metroCombBxFkTypeContract.ValueMember = "id_company";
            metroCombBxFkTypeContract.DisplayMember = "Name";
            statusStrip1.Visible = false;
        }
        private void preencherComboxCompany()
        {

        }
        public void TornarInvisivelLabels()
        {
            labelLastName.Visible = false;
            labelName.Visible = false;
            labelPatronymic.Visible = false;
            labelEmail.Visible = false;
            //labelAddress.Visible = false;
            //labelPostalCode.Visible = false;
            pictureBoxPostal.Visible = false;
            labelPhoneNumber.Visible = false;
            pictureBoxAdress.Visible = false;
            pictureBoxCompany.Visible = false;
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
        public bool InvisivelLabel(Control textb)
        {
            if (textb.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void limpar()
        {
            maskedTextPhoneNumber.Text = string.Empty;
            metroTxbName.Text = string.Empty;
            metroTxbLastName.Text = string.Empty;
            metroTxbEmail.Text = string.Empty;
            metroTxbPatronymic.Text = string.Empty;
            metroTxbAddress.Text = string.Empty;
            radioF.Checked = false;
            radioM.Checked = true;
            metroCombBxTmSeguro.SelectedIndex = 0;
            statusStrip1.Visible = false;
            metroCombBxFkTypeContract.Enabled = false;
            //+7(   )    -  -
        }
        private void metroTxbLastName_Leave(object sender, EventArgs e)
        {
            if(metroTxbLastName.Text == "")
            {
                labelLastName.Visible = false;   
            }
            else
            {
                labelLastName.Visible = true;
            }
        }

        private void metroTxbLastName_Enter(object sender, EventArgs e)
        {
            if (metroTxbLastName.Text == "")
            {
                labelLastName.Visible = false;
            }
            else
            {
                labelLastName.Visible = true;
            }
        }
       

        private void metroTxbLastName_TextChanged(object sender, EventArgs e)
        {
            if (metroTxbLastName.Text == "")
            {
                labelLastName.Visible = false;
            }
            else
            {
                labelLastName.Visible = true;
            }
        }

        private void metroTxbName_TextChanged(object sender, EventArgs e)
        {
            if (metroTxbName.Text == "")
            {
                labelName.Visible = false;
            }
            else
            {
                labelName.Visible = true;
            }
        }

        private void metroTxbName_Leave(object sender, EventArgs e)
        {
            if (metroTxbName.Text == "")
            {
                labelName.Visible = false;
            }
            else
            {
                labelName.Visible = true;
            }
        }

        private void metroTxbName_Enter(object sender, EventArgs e)
        {
            if (metroTxbName.Text == "")
            {
                labelName.Visible = false;
            }
            else
            {
                labelName.Visible = true;
            }
        }

        private void metroTxbPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (metroTxbPatronymic.Text == "")
            {
                labelPatronymic.Visible = false;
            }
            else
            {
                labelPatronymic.Visible = true;
            }
        }

        private void metroTxbEmail_TextChanged(object sender, EventArgs e)
        {
            labelEmail.Visible = InvisivelLabel(metroTxbEmail);
        }

        private void metroTxbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            //labelPhoneNumber.Visible = InvisivelLabel(metroTxbPhoneNumber);
        }

        private void metroTxbPostalCode_Click(object sender, EventArgs e)
        {

        }

        private void metroTxbPostalCode_TextChanged(object sender, EventArgs e)
        {
            //labelPostalCode.Visible = InvisivelLabel(metroTxbPostalCode);
        }

        private void metroTxbAddress_TextChanged(object sender, EventArgs e)
        {
            //labelAddress.Visible = InvisivelLabel(metroTxbAddress);
        }



        private void maskedTextPhoneNumber_Leave(object sender, EventArgs e)
        {
            //labelPhoneNumber.Visible = InvisivelLabel(maskedTextPhoneNumber);
           
        }

        private void maskedTextPhoneNumber_Enter(object sender, EventArgs e)
        {
            /*
            if(maskedTextPhoneNumber.Text == "Телефон")
            { 
            maskedTextPhoneNumber.Text = "";
            maskedTextPhoneNumber.Mask = "+7(000) 000-00-00";
            maskedTextPhoneNumber.ForeColor = Color.Black; ;
            //maskedTextPhoneNumber.Font.Italic = false;
            }
            label8.Text = maskedTextPhoneNumber.Text;*/
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1LoginFechar_Click(object sender, EventArgs e)
        {
            fechar();
        }
        private void maskedTextPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            
            //maskedTextPhoneNumber.Mask = "+7(000) 000-00-00";
            string temp = maskedTextPhoneNumber.Text.Substring(3, 3) + maskedTextPhoneNumber.Text.Substring(8, 3) +
                maskedTextPhoneNumber.Text.Substring(12, 2);
            try
            {
                temp+= maskedTextPhoneNumber.Text.Substring(15, 2).ToString();
            }
            catch (Exception)
            {

            }
            if (temp == "        ")
                labelPhoneNumber.Visible = false;
            else
               labelPhoneNumber.Visible = true;
           // label8.Text = temp.Length.ToString();
           

        }

        private void metroBtnSendPatient_Click(object sender, EventArgs e)
        {
            DatePatient patient = new DatePatient();
            Uteis uteis = new Uteis();
            int cnt = 0;
            string[] error = new string[10];// 0-2-> nomes 3->email; 
            //List<string> error = new List<string>();
            string tipico= "цифры и буквы латинского алфавита не допускаются(поля: фамилия, имя, отчество)";
            bool temErro=false;
            patient.Patroymi = uteis.NomeDentrosPadroes(ref pictureBoxPatromic, metroTxbPatronymic.Text, ref error[0], ref temErro, tipico);
            patient.LastName = uteis.NomeDentrosPadroes(ref pictureBoxLastName, metroTxbLastName.Text, ref error[1], ref temErro,tipico);
            patient.Name = uteis.NomeDentrosPadroes(ref pictureBoxName, metroTxbName.Text, ref error[2], ref temErro,tipico);
            tsNenhuma.Text = "";

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
                    error[3] = "введите существующий адрес электронной почты";
                   // tsNenhuma.Text = error[3];
                }
                cnt++;
            }

            if (maskedTextPhoneNumber.Text != "+7(   )    -  -"  && maskedTextPhoneNumber.Text.Length==17)
            {
                patient.PhoneNumber = maskedTextPhoneNumber.Text;
                pictureBoxPhone.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPhone.Visible = true;
                error[4] = "Введите действительный номер мобильного телефона";
                cnt++;
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
                cnt++;
            }

            patient.Dateofbirth= metroDateTime1.Value.Date;

            if (metroTxbAddress.Text != "")
            {
                patient.Adress = metroTxbAddress.Text;
                pictureBoxAdress.Visible = false;
            }
            else
            {
                pictureBoxAdress.Visible = true;
                cnt++;
            }

            if (radioM.Checked)
                patient.Sex = 1;
            else
                patient.Sex = 2;
            

            //uteis.MeterErrosNaMsg(ref msg, error);

            if (metroCombBxTmSeguro.SelectedIndex == 0)
            {
                patient.Company = null;
                pictureBoxCompany.Visible = false;
            }
            else
            {
                if (metroCombBxFkTypeContract.SelectedIndex > 0)
                {
                    patient.Company = Convert.ToInt32(metroCombBxFkTypeContract.SelectedValue);//item selecionado combobox
                    metroCombBxFkTypeContract.Enabled = true;
                    pictureBoxCompany.Visible = false;
                }
                else
                {
                    pictureBoxCompany.Visible = true;
                    temErro = true;
                }
            }

            if (!temErro)
            {
                PatientCotroller patientCotroller = new PatientCotroller();
                Class1 mensagem = new Class1();
                statusStrip1.Visible = false;
                if (patientCotroller.RegisterPatient(patient, (metroCombBxTmSeguro.SelectedIndex == 0)))
                {
                    MessageBox.Show(mensagem.msgSucess, mensagem.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    /*tsNenhuma.Text = "Передал данный";
                    tsNenhuma.ForeColor = Color.Green;*/
                    limpar();
                }
                else
                {
                    MessageBox.Show(" НЕ передал данный \nошибка:" + patientCotroller.ErroRegisterMsg().ToString(), "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                statusStrip1.Visible = true;
                tsNenhuma.ForeColor = Color.Red;
                if (pictureBoxName.Visible && pictureBoxLastName.Visible && pictureBoxPatromic.Visible)
                    cnt += 3;
                bool ativar = pictureBoxName.Visible || pictureBoxLastName.Visible || pictureBoxPatromic.Visible;
                //ts.Text = cnt.ToString();
                if (cnt<7) 
                {
                    if (!uteis.MeterErrosApr(ref msg, error) && (cnt==1 || (ativar && cnt<=3)))
                    {
                        tsNenhuma.Text = msg;
                    }
                    else
                    {
                        tsNenhuma.Text = "пожалуйста, заполните правильно все поля";
                    }
                }
                else
                {
                    tsNenhuma.Text = "пожалуйста, заполните правильно все поля";
                }
            }

            /*if (temErro)
                label8.Text = msg;
            else
                label8.Text = "";*/
            //label8.Text = ;//metroDateTime1.Value.Date.ToString("dd-MM-yyyy");
        }

       

        private void metroButton2_Click(object sender, EventArgs e)
        {
            limpar();
            TornarInvisivelLabels();
            msg = " ";
            //label8.Text = "";
        }

        private void metroCombBxTmSeguro_TextChanged(object sender, EventArgs e)
        {
            if (metroCombBxTmSeguro.SelectedIndex == 0)
            {
                metroCombBxFkTypeContract.Enabled = false;
            }
            else
            {
                metroCombBxFkTypeContract.Enabled = true;
            }
        }
    }
}
