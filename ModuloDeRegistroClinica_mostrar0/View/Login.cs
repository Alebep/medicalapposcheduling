using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Verificar_se_tem_letras_em_russo_ou_lantina;
using Controller;
using ModuloDeRegistroClinica_mostrar0.View;

namespace ModuloDeRegistroClinica_mostrar0
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            GraphicsPath graphics = new GraphicsPath();
            forma.AddEllipse(0,0, pictureBox1LoginFechar.Width, pictureBox1LoginFechar.Height);
            pictureBox1LoginFechar.Region = new Region(forma);
            graphics.AddEllipse(0,0, pictureBoxErrorr.Width, pictureBoxErrorr.Height);
            pictureBoxErrorr.Region = new Region(graphics);
            //base.OnPaint(e);
        }

        private void TxtbUsuario_login_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Fechar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TxtbUsuario_login_Enter(object sender, EventArgs e)
        {
            if(TxtbUsuarioLogin.Text== "Пользователь")
            {
                TxtbUsuarioLogin.Text = "";
                TxtbUsuarioLogin.ForeColor = Color.LightGray;
            }
        }

        private void TxtbUsuario_login_Leave(object sender, EventArgs e)
        {
            if (TxtbUsuarioLogin.Text == "")
            {
                TxtbUsuarioLogin.Text = "Пользователь";
                TxtbUsuarioLogin.ForeColor = Color.DimGray;
            }
        }

        private void TxtbPassword_login_Enter(object sender, EventArgs e)
        {
            if (TxtbPassword_login.Text == "Пароль")
            {
                TxtbPassword_login.Text = "";
                TxtbPassword_login.ForeColor = Color.LightGray;
                TxtbPassword_login.UseSystemPasswordChar = true;
            }
        }

        private void TxtbPassword_login_Leave(object sender, EventArgs e)
        {
            if (TxtbPassword_login.Text == "")
            {
                TxtbPassword_login.Text = "Пароль";
                TxtbPassword_login.ForeColor = Color.DimGray;
                TxtbPassword_login.UseSystemPasswordChar = false;
            }
        }

        private void btn_entrarNoSistema_Click(object sender, EventArgs e)
        {
            if (TxtbPassword_login.Text != "Пароль" && TxtbUsuarioLogin.Text != "Пользователь")
            {
                Russo russo = new Russo();
                if (!russo.ContemLetraDoAlfabetoCirilico(TxtbUsuarioLogin.Text) && !russo.ContemLetraDoAlfabetoCirilico(TxtbPassword_login.Text))
                {
                    UserController userControl = new UserController();
                    var validationlogin = userControl.loginUser(TxtbUsuarioLogin.Text, TxtbPassword_login.Text);
                    userControl.CriarCacheUser();
                    if (validationlogin)
                    {
                        this.Hide();
                        BoasVindasECarregamentoSysm boasVindas = new BoasVindasECarregamentoSysm();
                        boasVindas.ShowDialog();
                        Home principal = new Home();
                        principal.Show();
                        principal.FormClosed += Logout;
                    }
                    else
                    {
                        string m = "Не удаётся войти\n Пожалуйста, проверьте правильность написания логина и пароля.";
                        MsgError(m);//RUSSO DEPOIS
                        TxtbPassword_login.Text= "Пароль";
                        TxtbPassword_login.UseSystemPasswordChar = false;
                        TxtbUsuarioLogin.Focus();
                    }
                }
                else
                {
                    string s = /*"Толко латинский буква!" + "\n"+*/"Пожалуйста, измените раскладку клавиатуры\n"+" на латинский алфавит";
                    MsgError(s);
                    if (russo.ContemLetraDoAlfabetoCirilico(TxtbPassword_login.Text))
                    {
                        TxtbPassword_login.Text = "Пароль";
                        TxtbPassword_login.ForeColor = Color.DimGray;
                        TxtbPassword_login.UseSystemPasswordChar = false;
                    }
                    if (russo.ContemLetraDoAlfabetoCirilico(TxtbUsuarioLogin.Text))
                    {
                        TxtbUsuarioLogin.Text = "Пользователь";
                        TxtbUsuarioLogin.ForeColor = Color.DimGray;
                    }
                }
            }
            else 
            { 
                MsgError("Введите имя пользователя и пароль");//depois em russo
            }
        }

        private void MsgError(string msg)
        {
            labelMsgError.Text = msg;
            labelMsgError.Visible = true;
            pictureBoxErrorr.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            //eesse metod deve ser chamado sempre que s sai do sistema da forma correta(pelo logout do formulario principal)
            TxtbPassword_login.Text = "Пароль";
            TxtbPassword_login.UseSystemPasswordChar = false;
            TxtbUsuarioLogin.Focus();
            labelMsgError.Visible = false;
            pictureBoxErrorr.Visible = false;
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
