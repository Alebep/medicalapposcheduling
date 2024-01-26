﻿using System;
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
    public partial class MenuEmployee : Form
    {
        public MenuEmployee()
        {
            InitializeComponent();
        }

        private void MenuEmployee_Load(object sender, EventArgs e)
        {

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
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<RegisterEmployee>();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<EditDeleteEmployee>();
        }

        private void оToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<RegisterCompany>();
        }
    }
}
