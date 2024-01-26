using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosClasseFrNet;
using Common;
using Controller;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class RegisterUser : Form
    {
        bool editar = false;
        int id = 0;
        public RegisterUser()
        {
            InitializeComponent();
        }
        ComboxsController comboxs = new ComboxsController();
        private void RegisterUser_Load(object sender, EventArgs e)
        {
            metroComboBox1.Items.Add("Адиминистратор");
            metroComboBox1.Items.Add("Секретар");
            metroComboBox1.Items.Add("врач");
            Carregar();
        }
        void Carregar()
        {
            UserController control = new UserController();
            dataGridView1.DataSource = control.Table();
            metroComboBoxEmployye.DataSource = comboxs.ComboBoxEmployeeforUser();
            metroComboBoxEmployye.DisplayMember = "Name";
            metroComboBoxEmployye.ValueMember = "Id_employee";
            metroComboBox2.DataSource = comboxs.Preencheremployee();
            metroComboBox2.DisplayMember = "Name";
            metroComboBox2.ValueMember = "Id_employee";
            //dataGridView1.Columns["password"].Visible = false;
        }
        void Tabela()
        {
            UserController control = new UserController();
            dataGridView1.DataSource = control.Table();
        }
        void Limpar()
        {
            pictureBox2passwd.Visible = false;
            pictureBoxEmploy.Visible = false;
            pictureBoxNivel.Visible = false;
            pictureBoxUser.Visible = false;
            metroTextBox1.Text = string.Empty;
            metroTxbAddress.Text = string.Empty;
            metroComboBoxEmployye.SelectedIndex = 0;
            metroComboBox1.SelectedIndex = 1;
            metroTextBoxPasswd2.Text = string.Empty;
            pictureBox2passwd2conf.Visible = false;
            statusStrip1.Visible = false;
        }
        private void metroBtnSendPatient_Click(object sender, EventArgs e)
        {
            UserController controller = new UserController();
            bool temErro = false,v=false;
            string user = string.Empty, passwd = string.Empty;
            int idlevel = 0, idemployee = 0;
            if (metroTextBox1.Text == string.Empty && metroTextBoxPasswd2.Text== string.Empty)
            {
                pictureBox2passwd.Visible = true;
                pictureBox2passwd2conf.Visible = true;
                temErro = true;
                tsNenhuma.Text = "пожалуйста, заполните правильно все поля";
            }
            else
            { 
                if (metroTextBox1.Text.Length > 8 )
                {
                    if (metroTextBox1.Text == metroTextBoxPasswd2.Text)
                    {
                        passwd = metroTextBox1.Text;
                        pictureBox2passwd2conf.Visible = false;
                        pictureBox2passwd.Visible = false;
                    }
                    else
                    {
                        temErro = true;
                        tsNenhuma.Text = "Пароли не совпадают";
                        pictureBox2passwd.Visible = true;
                        pictureBox2passwd2conf.Visible = true;
                    }
                }
                else
                {
                    temErro = true;
                    tsNenhuma.Text = "пароль должен иметь длину не менее 8 символов";
                    pictureBox2passwd.Visible = true;
                    pictureBox2passwd2conf.Visible = true;
                }
            }
            if (metroTxbAddress.Text == string.Empty)
            {
                pictureBoxUser.Visible = true;
                temErro = true;
            }
            else
            {
                if (metroTxbAddress.Text.Length>3) 
                {
                    user = metroTxbAddress.Text;
                    pictureBoxUser.Visible = false;
                }
                else
                {
                    pictureBoxUser.Visible = true;
                    temErro = true;
                    tsNenhuma.Text = "имя пользователя не должно быть короче 3 символов";
                    v = true;
                }
            }
            if (metroComboBoxEmployye.SelectedIndex > 0 || metroComboBox2.SelectedIndex > 0)
            {
                if (metroComboBoxEmployye.SelectedIndex > 0)
                {
                    pictureBoxEmploy.Visible = false;
                    idemployee = Convert.ToInt32(metroComboBoxEmployye.SelectedValue);
                }
                else
                {
                    idemployee = Convert.ToInt32(metroComboBox2.SelectedValue);
                }
            }
            else
            {
                temErro = true;
                pictureBoxEmploy.Visible = true;
            }
            if (metroComboBox1.SelectedIndex >= 0)
            {
                pictureBoxEmploy.Visible = false;
                idlevel = Convert.ToInt32(metroComboBox1.SelectedIndex)+1;
                //metroTxbAddress.Text = idlevel.ToString();
            }
            else
                pictureBoxNivel.Visible = true;
            if (!temErro)
            {
                statusStrip1.Visible = false;
                if (!editar)
                {
                    Class1 mensagem = new Class1();
                    if (controller.Insert(user, passwd, idlevel, idemployee))
                    {
                        Tabela();
                        if (MessageBox.Show(mensagem.msgSucess, mensagem.success, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            Carregar();
                        }
                    }
                    else
                       if (MessageBox.Show(" НЕ Передал данный" + controller.ErroMsg().ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        Carregar();
                }
                else
                {
                    if(controller.Alter(id,user, passwd, idlevel, idemployee))
                    {
                        editar = false;
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            Carregar();
                        }
                    }
                    else
                       if (MessageBox.Show(" НЕ Передал данный" + controller.ErroMsg().ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                          Carregar();
                }
            }//tem erro
            else
            {
                statusStrip1.Visible = true;
                if (!pictureBox2passwd.Visible)
                {
                    if (!v)
                    {
                        if (pictureBoxNivel.Visible || pictureBoxEmploy.Visible || pictureBoxUser.Visible)
                            tsNenhuma.Text = "Правильно заполните все поля с ошибкой";
                    }
                }
                

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                metroTextBox1.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
                metroTxbAddress.Text = dataGridView1.CurrentRow.Cells["Usser"].Value.ToString();
                metroComboBox1.SelectedIndex =Convert.ToInt32(dataGridView1.CurrentRow.Cells["fk_levell"].Value.ToString())-1;
                metroComboBox2.SelectedValue= dataGridView1.CurrentRow.Cells["fk_employee"].Value.ToString();
                editar = true;
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_user"].Value.ToString());
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            UserController user = new UserController();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Perguntar.Fperguntar("вы точно хотитие удалить?","удаление"))
                {
                    if (user.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_user"].Value.ToString())))
                    {
                        if (MessageBox.Show("Передал данный", "Прошле", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Limpar();
                            Carregar();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" НЕ удаллил данный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
            }
        }
    }
}
