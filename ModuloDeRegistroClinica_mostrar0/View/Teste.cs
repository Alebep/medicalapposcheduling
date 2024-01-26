using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Controller;
using System.Data;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class Teste : MetroFramework.Forms.MetroForm
    {
        public Teste()
        {
            InitializeComponent();
        }

        private void Teste_Load(object sender, EventArgs e)
        {
            CompanyController company = new CompanyController();
            //PatientCotroller patient = new PatientCotroller();
            metroComboBox1.DataSource = company.Tabela();
            metroComboBox1.DisplayMember = "Name";
            metroComboBox1.ValueMember = "id_company";
            comboBox1.DataSource = company.Tabela();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id_company";
        }
    }
}
