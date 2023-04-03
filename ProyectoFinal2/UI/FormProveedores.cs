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
    public partial class FormProveedores : Form
    {
        private ClassProveedores Logica;
        private ClassComprobarUser Logica2;
        public FormProveedores()
        {
            Logica = new ClassProveedores();
            Logica2 = new ClassComprobarUser();
            InitializeComponent();
        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarProveedores();
            dataGridView1.Refresh();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void Listar2()
        {
            dataGridView2.DataSource = Logica2.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormProveedores_Load(object sender, EventArgs e)
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
        public string v1, v2;

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
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
                errorProvider1.SetError(textBox2, "Ingresa el telefono");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox3, "Ingresa el correo");
            }
            if (textBox4.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox4, "Ingresa el comentario");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int Id = Convert.ToInt32(label5.Text);
                string resp = Logica.ActualizarProveedor(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Proveedor actualizad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
            }
            ValidadCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                string resp = Logica.NuevoProveedor(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Proveedor grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ValidadCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Menu fm = new Menu();
            fm.v1 = v1;
            fm.v2 = v2;
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && dataGridView1.Rows.Count>0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre = '{0}'", textBox5.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu fm = new Menu();
            fm.v1 = v1;
            fm.v2 = v2;
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }
    }
}
