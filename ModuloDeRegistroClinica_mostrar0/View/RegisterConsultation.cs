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
using Controller.cache;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterConsultation : Form
    {
        ComboxsController staticComboBox = new ComboxsController();
        void Limpar()
        {
            metroCombBxPatient.SelectedIndex = 0;
            metroComboBoxDoctor.DataSource = null;
            metroComboBoxSpecialty.SelectedIndex = 0;
            maskedTextBoxHeight.Text = string.Empty;
            maskedTextBoxWeight.Text = string.Empty;
            richTextBoxPrognostic.Text = string.Empty;
            maskedTextBoxTime.Text = string.Empty;
            metroDateTime1.Value = DateTime.Today;
        }
        bool DoctorWork()
        {
            Uteis ConvertDayDlyaBD = new Uteis();
            TimeTableController time = new TimeTableController();
            int idDay = ConvertDayDlyaBD.ConverterDiaDaSemanaEmChaveDaBD(metroDateTime1.Value.DayOfWeek.ToString());
            string[] horaDividida = maskedTextBoxTime.Text.Split(':');
            int idDoctor = Convert.ToInt16(metroComboBoxDoctor.SelectedValue);
            if (maskedTextBoxTime.Text != "  :")
            {
                TimeSpan time1 = new TimeSpan(Convert.ToInt32(horaDividida[0]), Convert.ToInt32(horaDividida[1]), 00);
                return time.DoctorHaveTimeThisDAy(idDoctor, idDay, time1);
            }
            else
            {
                return false;
            }
        }

        void VerificarTimeDoctorDatePicker()
        {
            if (metroComboBoxDoctor.SelectedValue != null && maskedTextBoxTime.Text != "  :")
                if (!DoctorWork())
                    MessageBox.Show("В этот время и дата врач не работает", "Дата", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void CarregarSpecialty()
        {
            metroComboBoxSpecialty.DataSource = staticComboBox.Preencherspecialty();
            metroComboBoxSpecialty.DisplayMember = "Name";
            metroComboBoxSpecialty.ValueMember = "id_speciality";
        }
        void CarrarPatient()
        {
            metroCombBxPatient.DataSource = staticComboBox.PreencherPatient();
            metroCombBxPatient.DisplayMember = "Name";
            metroCombBxPatient.ValueMember = "id_patient";
        }
        void CarregarDoctor(String id)
        {
            ComboxsController specialtyDoctor = new ComboxsController();
            metroComboBoxDoctor.DataSource = specialtyDoctor.PreencherSearchInDoctorBySpecialty(id);
            metroComboBoxDoctor.DisplayMember = "Name";
            metroComboBoxDoctor.ValueMember = "id_doctor";
        }
        public RegisterConsultation()
        {
            InitializeComponent();
        }

        private void labelPatronymic_Click(object sender, EventArgs e)
        {

        }

        private void RegisterConsultation_Load(object sender, EventArgs e)
        {
            CarregarSpecialty();
            CarrarPatient();
            metroDateTime1.MinDate = DateTime.Today;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void metroComboBoxSpecialty_TextChanged(object sender, EventArgs e)
        {
            if (metroComboBoxSpecialty.SelectedIndex > 0)
            {
                CarregarDoctor(metroComboBoxSpecialty.SelectedValue.ToString());
                metroComboBoxDoctor.Enabled = true;
            }
            else
            {
                metroComboBoxDoctor.Enabled = false;
                metroComboBoxDoctor.DataSource = null;
                //metroComboBoxDoctor.SelectedIndex = 0;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataConsultation dataConsultation = new DataConsultation();
            bool temErro = false;

            if (metroComboBoxSpecialty.SelectedIndex > 0)
                pictureBoxSpecialty.Visible = false;
            else
                pictureBoxSpecialty.Visible = true;

            if (metroComboBoxDoctor.SelectedIndex > 0)
            {
                dataConsultation.Fkdoctor = Convert.ToInt16(metroComboBoxDoctor.SelectedValue.ToString());
                pictureBoxDoctor.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxDoctor.Visible = true;
            }

            if (metroCombBxPatient.SelectedIndex > 0)
            {
                dataConsultation.Fk_patient = Convert.ToInt16(metroCombBxPatient.SelectedValue.ToString());
                pictureBoxPatient.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBoxPatient.Visible = true;
            }

            if(maskedTextBoxTime.Text== "  :")
            {
                temErro = true;
                pictureBoxTime.Visible = true;
            }
            else
            {
                string[] horaDividida = maskedTextBoxTime.Text.Split(':');
                pictureBoxTime.Visible = false;
                dataConsultation.Time = new TimeSpan(Convert.ToInt32(horaDividida[0]), Convert.ToInt32(horaDividida[1]), 00); ;
            }

            if (maskedTextBoxWeight.Text == "")
                dataConsultation.Weight = null;
            else
                dataConsultation.Weight = Convert.ToDouble(maskedTextBoxWeight.Text);

            if (maskedTextBoxHeight.Text == "")
                dataConsultation.Height = null;
            else
                dataConsultation.Height = Convert.ToDouble(maskedTextBoxHeight.Text);

            if (richTextBoxPrognostic.Text == string.Empty)
                dataConsultation.Prognostic = null;
            else
                dataConsultation.Prognostic = richTextBoxPrognostic.Text;

            if (!string.IsNullOrEmpty(dataConsultation.Fkdoctor.ToString()))
            {
                if (DoctorWork())
                {
                    dataConsultation.Date = metroDateTime1.Value;
                    pictureBoxData.Visible = false;
                }
                else
                {
                    temErro = true;
                    pictureBoxData.Visible = true;
                }
            }
            else
            {
                temErro = true;
                pictureBoxData.Visible = true;
            }
            if (!temErro)
            {
                ConsultationController controller = new ConsultationController();
                dataConsultation.Fk_user = UserLoginCache.IdUser;
                dataConsultation.Status = "записан на прием";
                if (controller.Insert(dataConsultation))
                {
                    if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        Limpar();
                }
                else
                    MessageBox.Show(" НЕ передал данный \nошибка:" + controller.MsgErroConsultation(), "НЕ Прошле", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            VerificarTimeDoctorDatePicker();
        }

        private void metroDateTime1_Leave(object sender, EventArgs e)
        {
            VerificarTimeDoctorDatePicker();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
