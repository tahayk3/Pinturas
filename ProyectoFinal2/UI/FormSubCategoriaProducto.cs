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
    public partial class FormSubCategoriaProducto : Form
    {
        private ClassSubCategoria Logica;
        private ClassCategoriaProductos Logica2;
        private ClassComprobarUser Logica3;
        public FormSubCategoriaProducto()
        {
            InitializeComponent();
            Logica = new ClassSubCategoria();
            Logica2 = new ClassCategoriaProductos();
            Logica3 = new ClassComprobarUser();
        }
        //funcion listar
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarSubCategoria();
            dataGridView1.Refresh();
        }
        public string v1, v2,deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        void llenarcombobox()
        {
            comboBox1.DataSource = Logica2.ListarCategoria();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "Id_categoriaProducto";
            comboBox1.Refresh();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (deDonde == "sub")
            {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "sub";
                fm.ShowDialog();
                this.Close();
            }
            else if (deDonde == "factura")
            {
                FormProducto fm = new FormProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "factura";
                fm.ShowDialog();
                this.Close();
            }
            else if (deDonde == "producto")
            {
                FormProducto fm = new FormProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "producto";
                fm.ShowDialog();
                this.Close();
            }
            else if (deDonde == "historial")
            {
                FormProducto fm = new FormProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "historial";
                fm.ShowDialog();
                this.Close();
            }
        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox2, "Ingresa el nombre");
            }
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa la categoria");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(comboBox1, "");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int Id = Convert.ToInt32(label5.Text);
                string resp = Logica.ActualizarSubCategoria(Convert.ToInt32(comboBox1.SelectedValue), textBox2.Text, Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Sub categoria actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
            }
            ValidadCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             BorrarMensajeError();
            if (ValidadCampos())
            {
                string resp = Logica.NuevoSubCategoria(Convert.ToInt32(comboBox1.SelectedValue), textBox2.Text);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Sub categoria grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ValidadCampos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            comboBox1.Text = "";
            llenarcombobox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(deDonde=="menu")
            {
                string deDonde = "menu";
                FormCategoriaProducto fm = new FormCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
            if (deDonde == "producto")
            {
                string deDonde = "producto";
                FormCategoriaProducto fm = new FormCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
            if (deDonde == "sub")
            {
                string deDonde = "sub";
                FormCategoriaProducto fm = new FormCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
            if (deDonde == "factura")
            {
                string deDonde = "factura";
                FormCategoriaProducto fm = new FormCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
            if (deDonde == "historial")
            {
                string deDonde = "historial";
                FormCategoriaProducto fm = new FormCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
        }

        private void FormSubCategoriaProducto_Load(object sender, EventArgs e)
        {
            label6.Text = deDonde;
            label4.Visible = false;
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
