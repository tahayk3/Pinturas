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
    public partial class FormCliente : Form
    {
        private ClassCliente Logica;
        private ClassComprobarUser Logica3;
        public FormCliente()
        {
            InitializeComponent();
            Logica = new ClassCliente();
            Logica3 = new ClassComprobarUser();
        }
        //funcion listar
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarCliente();
            dataGridView1.Refresh();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(deDonde=="1")
            {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            } else if(deDonde =="2")
            {
                FormFactura fm = new FormFactura();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormIngresar fm = new FormIngresar();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }
        public string v1, v2, deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormCliente_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            label1.Visible = true;
            Listar2();
            for (int fila = 0; fila < dataGridView2.Rows.Count - 1; fila++)
            {
                for (int col = 0; col < dataGridView2.Rows[fila].Cells.Count; col++)
                {
                    string valor = dataGridView2.Rows[fila].Cells[col].Value.ToString();
                    if (col == 0)
                    {
                        label18.Text = valor;
                    }
                    if (col == 1)
                    {
                        label17.Text = valor;
                    }
                    if (col == 2)
                    {
                        label16.Text = valor;
                    }
                    if (col == 3)
                    {
                        label15.Text = valor;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                string resp = Logica.NuevoCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ValidadCampos();

        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresa el primer nombre");
            }
            if (textBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox2, "Ingresa el segundo nombre");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox3, "Ingresa el primer apellido");
            }
            if (textBox4.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox4, "Ingresa el segundo apellido");
            }
            if (textBox5.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox5, "Ingresa el telefono");
            }
            if (textBox6.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox6, "Ingresa el correo");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(textBox5, "");
            errorProvider1.SetError(textBox6, "");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int Id = Convert.ToInt32(label5.Text);
                string resp = Logica.ActualizarCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
            }
            ValidadCampos();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("primer_nombre = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
