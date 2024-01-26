using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Common;
using Controller;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller.cache;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterTimeTableDc : Form
    {
        readonly ComboxsController comboxsController = new ComboxsController();
        bool editar;
        int id;
        public RegisterTimeTableDc()
        {
            InitializeComponent();
        }
        void CarregarDoctor()
        {
            metroCombBxDoctor.DataSource = comboxsController.PreencherDoctor();
            metroCombBxDoctor.DisplayMember = "Name";
            metroCombBxDoctor.ValueMember = "id_doctor";
        }
        void CarregargarDay()
        {
            metroComboxDay.DataSource = comboxsController.PreencherDayWeek();
            metroComboxDay.DisplayMember = "day";
            metroComboxDay.ValueMember = "id_dayweek";
        }
        void TodaGridview()
        {
            TimeTableController timeTableController = new TimeTableController();
            dataGridView1.DataSource = timeTableController.Table();
        }
        private void RegisterTimeTableDc_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            CarregarDoctor();
            CarregargarDay();
            TodaGridview();
            if (UserLoginCache.Nivel == 2)
            {
                metroButtonDelete.Enabled = false;
                metroButtonDelete.Visible = false;
                metroButtonAlter.Enabled = false;
                metroButtonAlter.Visible = false;
                metroButtonSend.Enabled = false;
            }
        }
        void Limpar()
        {
            metroCombBxDoctor.SelectedIndex = 0;
            metroComboxDay.SelectedIndex = 0;
            maskedTextBox1DepaurtHours.Text = string.Empty;
            maskedTextBoxEntreyHours.Text = string.Empty;
            metroTextBoxSearch.Text = string.Empty;
            textBox1.Text = string.Empty;
        }

        private void metroButtonSend_Click(object sender, EventArgs e)
        {
            bool temErro = false;
            TimeDoctor timeDoctor = new TimeDoctor();
            if (metroCombBxDoctor.SelectedIndex == 0)
            {
                pictureBoxDoctor.Visible = true;
                temErro = true;
            }
            else
            {
                timeDoctor.FkDoctor = Convert.ToInt32(metroCombBxDoctor.SelectedValue);
                pictureBoxDoctor.Visible = false;
            }

            if (metroComboxDay.SelectedIndex==0)
            {
                pictureBox1Day.Visible = true;
                temErro = true;
            }
            else
            {
                pictureBox1Day.Visible = false;
                timeDoctor.FkDayweek = Convert.ToInt32(metroComboxDay.SelectedValue);
            }
            if(maskedTextBoxEntreyHours.Text!= "  :")
            {
                string[] horaDividida = maskedTextBoxEntreyHours.Text.Split(':');
                timeDoctor.EntryTime = new TimeSpan(Convert.ToInt32(horaDividida[0]), Convert.ToInt32(horaDividida[1]),00);
                pictureBox1EntryTime.Visible = false;
            }
            else
            {
                temErro = true;
                pictureBox1EntryTime.Visible = true;
            }

            if (maskedTextBox1DepaurtHours.Text != "  :")
            {
                string[] horaDividida = maskedTextBox1DepaurtHours.Text.Split(':');
                timeDoctor.DepartureTime = new TimeSpan(Convert.ToInt32(horaDividida[0]), Convert.ToInt32(horaDividida[1]), 00);
                pictureBox1Saida.Visible = false;
                textBox1.Text = timeDoctor.Idtimetable.ToString();
            }
            else
            {
                temErro = true;
                pictureBox1Saida.Visible = true;
            }

            if (!temErro && timeDoctor.EntryTime < timeDoctor.DepartureTime)
            {
                TimeTableController controller = new TimeTableController();
                if (!editar)
                {
                    if (controller.Insert(timeDoctor))
                    {
                        Class1 mensagem = new Class1();
                        if (MessageBox.Show(mensagem.msgSucess, mensagem.success, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            TodaGridview();
                            editar = false;
                            id = 0;
                        }
                    }
                    else
                        MessageBox.Show("НЕ передал данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    textBox1.Text = id.ToString();
                    timeDoctor.Idtimetable = id;
                    if (controller.Alter(timeDoctor))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            TodaGridview();
                            editar = false;
                            id = 0;
                        }
                    }
                    else
                        MessageBox.Show("НЕ передал данный"+controller.Error(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Время вход болше время выход", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButtonClear_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void metroButtonAlter_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroComboxDay.Text = dataGridView1.CurrentRow.Cells["day"].Value.ToString();
                metroCombBxDoctor.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                maskedTextBoxEntreyHours.Text = dataGridView1.CurrentRow.Cells["entry_time"].Value.ToString();
                maskedTextBox1DepaurtHours.Text = dataGridView1.CurrentRow.Cells["departure_time"].Value.ToString();
                editar = true;
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_timetable"].Value.ToString());
                textBox1.Text = id.ToString();
                //metroTextBox1.Text = Convert.ToString(id);
            }
        }

        private void metroButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Perguntar.Fperguntar("Точно хотитие удалить", "удалить?"))
                {
                    TimeTableController controller = new TimeTableController();
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_timetable"].Value.ToString());
                    if (controller.Delete(id))
                    {
                        if (MessageBox.Show("удалил", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            TodaGridview();
                        }
                    }
                    else
                        MessageBox.Show("Не удалил", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxSearch.Text == string.Empty)
            {
                TodaGridview();
                metroTextBoxSearch.Focus();
                metroTextBoxSearch.Text = string.Empty;
            }
            else
            {
                TimeTableController tableController = new TimeTableController();
                dataGridView1.DataSource = tableController.Search(metroTextBoxSearch.Text);
            }
        }
    }//fim
}
