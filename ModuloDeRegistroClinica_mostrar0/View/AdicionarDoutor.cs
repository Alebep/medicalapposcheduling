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
    public partial class AdicionarDoutor : Form
    {
        public AdicionarDoutor()
        {
            InitializeComponent();
        }

        private void AdicionarDoutor_Load(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new One(), sender);
            //AbrirFormulario<Home>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home(), sender);
            //AbrirFormulario<One>();
        }
       
    }
}
