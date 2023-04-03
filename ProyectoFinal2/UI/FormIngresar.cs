using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace UI
{
    public partial class FormIngresar : Form
    {
        private ClassEmpleado Logica;
        public FormIngresar()
        {
            InitializeComponent();
        Logica = new ClassEmpleado();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string resp = Logica.ComprobarLogin(textBox1.Text, textBox2.Text);
            if (resp.ToUpper().Contains("1"))
            {
                MessageBox.Show(this, "Comprueba el usuario y/o contraseña", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resp.ToUpper().Contains("2"))
            {
                MessageBox.Show("Bienvenido al sistema");
                Menu fm = new Menu();
                fm.v1 = textBox1.Text;
                fm.v2 = textBox2.Text;
                this.Hide();
                fm.ShowDialog();
                this.Close();
            }
        }
        private void FormIngresar_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
