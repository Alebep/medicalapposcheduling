using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class MenuPatient : Form
    {
        public MenuPatient()
        {
            InitializeComponent();
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registerPatient>();
        }

        internal void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panel1.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel1.Controls.Add(formulario);
                panel1.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            /*if (Application.OpenForms["Form1"] == null)
                btnFormularioPrincipal.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form2"] == null)
                Btn6.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form3"] == null)
                Btn2.BackColor = Color.FromArgb(4, 41, 68);*/
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<EditAndDeletePatient>();
        }
    }
}
