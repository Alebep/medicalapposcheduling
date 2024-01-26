using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Controller.cache;
using Common;

namespace ModuloDeRegistroClinica_mostrar0.View
{
    public partial class EditDeleteEmployee : Form
    {
        EmployeeController EmployeeController = new EmployeeController();
        public EditDeleteEmployee()
        {
            InitializeComponent();
        }

        private void EditDeleteEmployee_Load(object sender, EventArgs e)
        {
            Atualizar();
            if (UserLoginCache.Nivel == 2)
            {
                BtnDelete.Visible = false;
                BtnAlter.Visible = false;
            }
        }
        public void Atualizar()
        {
            EmployeeController Employeer = new EmployeeController();
            dataGridView1.DataSource = Employeer.TableEmployee();
        }
        private void BtnAlter_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EditEmployee editEmployee = new EditEmployee();
                ComboxsController combox = new ComboxsController();
                editEmployee.metroComboBox1.Items.Add("Адиминистратор");
                editEmployee.metroComboBox1.Items.Add("Секретар");
                editEmployee.metroComboBox1.Items.Add("врач");
                editEmployee.metroTxbName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                editEmployee.metroTxbLastName.Text = dataGridView1.CurrentRow.Cells["Last_name"].Value.ToString();
                editEmployee.metroDateTime1.Text = dataGridView1.CurrentRow.Cells["Date_of_birth"].Value.ToString();
                editEmployee.metroTxbEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                editEmployee.metroTxbAddress.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                editEmployee.metroTxbPatronymic.Text = dataGridView1.CurrentRow.Cells["Patronymic"].Value.ToString();
                editEmployee.maskedTextBoxPostalCode.Text = dataGridView1.CurrentRow.Cells["Postal_code"].Value.ToString();
                editEmployee.maskedTextPhoneNumber.Text = dataGridView1.CurrentRow.Cells["Phone_number"].Value.ToString();
                editEmployee.metroComboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Responsibility"].Value.ToString()) - 1;
                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["fk_gender"].Value.ToString()) == 1)
                    editEmployee.radioM.Select();
                else
                    editEmployee.radioF.Select();
                editEmployee.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_employee"].Value.ToString());
                editEmployee.EditDeleteEmployee = this;//passei essa classe com propriedade da classe editPatient
                editEmployee.Show();
            }
            else
                MessageBox.Show("надо выбрать строка");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотитие удалить?", "удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (EmployeeController.DeleteEmployee(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_employee"].Value.ToString())))
                    {
                        Class1 mensagem = new Class1();
                        MessageBox.Show(mensagem.msgSucessDelete, "удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Atualizar();
                    }
                    else
                        MessageBox.Show("не прошел", "удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
