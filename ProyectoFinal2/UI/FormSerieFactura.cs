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
    public partial class FormSerieFactura : Form
    {
        private ClassSerieFactura Logica;
        private ClassComprobarUser Logica3;
        public FormSerieFactura()
        {
            InitializeComponent();
            Logica = new ClassSerieFactura();
            Logica3 = new ClassComprobarUser();
        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarSerie();
            dataGridView1.Refresh();
        }
        public string v1, v2,deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
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
            }
            else if(deDonde =="2")
            {
                FormFactura fm = new FormFactura();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                string resp = Logica.NuevoCliente(textBox1.Text);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Serie grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ValidadCampos();
        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresa la serie");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox1, "");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int Id = Convert.ToInt32(label5.Text);
                string resp = Logica.ActualizarCliente(textBox1.Text, Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Serie actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
            }
            ValidadCampos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("serie = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void FormSerieFactura_Load(object sender, EventArgs e)
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
    }
}
