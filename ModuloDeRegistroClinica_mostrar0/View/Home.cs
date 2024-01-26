using System;
using Controller.cache;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class Home : Form
    {
        const string principalN2 = "Главная", consultaN2 = "Прием", RegistroN2 = "регистрация пациента", histN2 = "История", horN2 = "Расписание";
        const string procurarN2= "Искать",exameN2= "Осмотр";
        const string principalN1 = "Врачи", pacient = "Пациенты", funcionario = "Cотрудники";
        bool admin;
        public Home()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            LoadDataUser();
            Nivel();
        }
        void Nivel()
        {
            if (UserLoginCache.Nivel == 2)
            {
                btnFormularioPrincipal.Text = principalN2;
                Btn2.Text = consultaN2;
                Btn3.Text = RegistroN2;
                Btn4.Text = procurarN2;
                Btn5.Text = exameN2;
                Btn6.Text = horN2;
                Btn7.Text = histN2;
                Btn8.Visible = false;
                admin = false;
            }
            else if (UserLoginCache.Nivel==1)
            {
                admin = true;
                btnFormularioPrincipal.Text = principalN1;
                Btn2.Text = consultaN2;
                Btn3.Text = pacient;
                Btn4.Text = funcionario;
                Btn5.Text = exameN2;
                Btn6.Text = horN2;
                Btn7.Text = histN2;
                btnFormularioPrincipal.Image = Image.FromFile(@"G:\Dropbox\Projecto final\Tese\1Doctor-blue-icon.png");
                Btn4.Image = Image.FromFile(@"G:\Dropbox\Projecto final\ВКР\Programa\ICONOS BLUE\person-settings1.png");
            }
        }
        private void LoadDataUser()
        {
            label_Cargo.Text = UserLoginCache.Cargo;
            labelSobrenome_Nome.Text = UserLoginCache.Sobrenome;
            labelNome.Text =  UserLoginCache.Nome;
        }

        private void panelCouteudoOoGrande_Paint(object sender, PaintEventArgs e)
        {

        }
        #region funcionakidade do form
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelCouteudoOoGrande.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)//TROQUEI RESTAURAR E MAXIMAZAR
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void panel_barraTitulo_MouseMove(object sender, MouseEventArgs e)// mexer a form
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*AbrirFormulario<registerPatient>();
            btnFormularioPrincipal.BackColor = Color.FromArgb(12, 61, 92);*/
            CorPadraoBtn();
            btnFormularioPrincipal.BackColor= Color.FromArgb(12, 61, 92);
            if (!admin)
            {
                if (btnFormularioPrincipal.Text == principalN2)
                {
                    AbrirFormulario<One>();
                }
            }
            else
                AbrirFormulario<RegisterDoctor>();
        }

        private void button3_Click(object sender, EventArgs e)//esse e o botao btn2
        {
            //AbrirFormulario<AdicionarDoutor>();
            CorPadraoBtn();
            Btn2.BackColor = Color.FromArgb(12, 61, 92);
            if (!admin)
            {
                if (Btn2.Text == consultaN2)
                {
                    AbrirFormulario<RegisterConsultation>();
                }
            }
            else
                AbrirFormulario<MenuConsulta>();
        }

        private void PanelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы хотитие выйти", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            CorPadraoBtn();
            Btn3.BackColor = Color.FromArgb(12, 61, 92);
            if (Btn3.Text == RegistroN2)
            {
                AbrirFormulario<registerPatient>();
            }
            else
            {
                AbrirFormulario<MenuPatient>();
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            CorPadraoBtn();
            Btn5.BackColor = Color.FromArgb(12, 61, 92);
            if (Btn5.Text == exameN2)
            {
                if (UserLoginCache.Nivel == 2) 
                    AbrirFormulario<RegisterMakeExam>();
                else
                    AbrirFormulario<MenuExam>();
            }
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            AbrirFormulario<RegisterUser>();
            CorPadraoBtn();
            Btn8.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<HistoryPatient>();
            CorPadraoBtn();
            Btn7.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelSobrenome_Nome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<EditAndDeletePatient>();
            CorPadraoBtn();
            Btn6.BackColor = Color.FromArgb(12, 61, 92);
            if (Btn6.Text == horN2)
            {
                AbrirFormulario<RegisterTimeTableDc>();
            }
            Btn6.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void panel_barraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<Teste>();
            if (Btn4.Text == procurarN2)
            {
                AbrirFormulario<MenuN2Pesquisar>();
            }
            else
            {
                AbrirFormulario<MenuEmployee>();
            }
            CorPadraoBtn();
            Btn4.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void PanelFormularios_Paint_1(object sender, PaintEventArgs e)
        {

        }
        #endregion
        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        internal void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PanelFormularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelFormularios.Controls.Add(formulario);
                PanelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
               /* formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                this.PanelFormularios.Controls.Add(formulario);
                this.PanelFormularios.Tag = formulario;
                formulario.BringToFront();
                formulario.Show();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);*/
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        //mudar cor de botao
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["registerPatient"] == null)
                Btn3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form2"] == null)
                Btn6.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form3"] == null)
                Btn2.BackColor = Color.FromArgb(4, 41, 68);
        }
        void CorPadraoBtn()
        {
            btnFormularioPrincipal.BackColor = Color.FromArgb(4, 41, 68);
            Btn2.BackColor= Color.FromArgb(4, 41, 68);
            Btn3.BackColor = Color.FromArgb(4, 41, 68);
            Btn4.BackColor = Color.FromArgb(4, 41, 68);
            Btn5.BackColor = Color.FromArgb(4, 41, 68);
            Btn6.BackColor = Color.FromArgb(4, 41, 68);
            Btn7.BackColor = Color.FromArgb(4, 41, 68);
            Btn8.BackColor = Color.FromArgb(4, 41, 68);
        }
    }
}
