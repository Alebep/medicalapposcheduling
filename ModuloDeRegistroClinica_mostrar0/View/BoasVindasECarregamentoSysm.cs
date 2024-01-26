using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller.cache;
namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class BoasVindasECarregamentoSysm : Form
    {
        public BoasVindasECarregamentoSysm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BoasVindasECarregamentoSysm_Load(object sender, EventArgs e)
        {
            if (UserLoginCache.Nivel == 1)
                labelUserName.Text = UserLoginCache.Nome;
            else
                labelUserName.Text = UserLoginCache.Sobrenome+", "+UserLoginCache.Nome;
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity<1)
                this.Opacity += 0.05;
            circularProgressBar1.Value++;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if(circularProgressBar1.Value==100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity==0)
            {
                timer2.Stop();
                this.Close();
            }
        }
    }
}
