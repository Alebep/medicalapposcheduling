using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class HistoryPatient : Form
    {
        ComboxsController Patient = new ComboxsController();
        public HistoryPatient()
        {
            InitializeComponent();
        }
        void Carregar(int id)
        {
            ConsultationController controller = new ConsultationController();
            dataGridView1.DataSource = controller.HistoryPatient(id);
        }
        private void HistoryPatient_Load(object sender, EventArgs e)
        {
            metroComboBoxPatient.DataSource = Patient.PreencherPatient();
            metroComboBoxPatient.DisplayMember = "Name";
            metroComboBoxPatient.ValueMember = "id_patient";
            labelName.Visible = false;
            labelDataNasc.Visible = false;
            labelAltura.Visible = false;
            label4.Visible = false;
        }

        private void metroComboBoxPatient_SelectedValueChanged(object sender, EventArgs e)
        {
            if (metroComboBoxPatient.SelectedIndex == 0)
            {
                ;
            }
            else
            {
                labelAltura.Visible = true;
                labelDataNasc.Visible = true;
                labelName.Visible = true;
                int id = Convert.ToInt32(metroComboBoxPatient.SelectedValue.ToString());
                PatientCotroller patientCotroller = new PatientCotroller();
                DateTime date = patientCotroller.NameBirthPatient(id).Dateofbirth;
                labelDataNasc.Text = date.Date.ToString("dd-MM-yyyy")+"("+(DateTime.Today.Year-date.Year).ToString()+")";
                labelName.Text = patientCotroller.NameBirthPatient(id).Name;
                Carregar(id);
            }
        }
    }
}
