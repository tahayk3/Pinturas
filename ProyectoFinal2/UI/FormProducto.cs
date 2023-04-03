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
    public partial class FormProducto : Form
    {

        private ClassProducto Logica;
        private ClassSubCategoria Logica2;
        private ClassComprobarUser Logica3;
        public FormProducto()
        {
            InitializeComponent();
            Logica3 = new ClassComprobarUser();
            Logica2 = new ClassSubCategoria();
            Logica = new ClassProducto();
        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarProductos();
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
            comboBox1.DataSource = Logica2.ListarSubCategoria();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "Id_SubCategoriaProducto";
            comboBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int Id = Convert.ToInt32(label5.Text);
                string resp = Logica.ActualizarProducto(Convert.ToInt32(comboBox1.SelectedValue), textBox1.Text, Convert.ToDecimal(textBox2.Text), textBox3.Text, Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
                decimal Actual_precio = Convert.ToDecimal(valor_actual);
                int Actual_id = Convert.ToInt32(Id_actual);
                string respuesta;
                respuesta = Logica.GrabaHistorial2(Actual_id, Actual_precio);
                MessageBox.Show(respuesta);
            }
            ValidadCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if(ValidadCampos())
            {
                string resp = Logica.NuevoProducto(Convert.ToInt32(comboBox1.SelectedValue), textBox1.Text, Convert.ToDecimal(textBox2.Text), textBox3.Text);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string respuesta;
                respuesta = Logica.GrabaHistorial();
                MessageBox.Show(respuesta);
            }
            ValidadCampos();
        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if(textBox1.Text=="")
            {
                ok = false;
                errorProvider1.SetError(textBox1,"Ingresa el nombre del producto");
            }
            if (textBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox2, "Ingresa el precio de venta del producto");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox3, "Ingresa la descripcion del producto");
            }
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa la sub categoria");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
        }
        private void button5_Click(object sender, EventArgs e)
        {
           if(deDonde=="producto")
            {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            }
           else if(deDonde=="factura")
            {
                FormFactura fm = new FormFactura();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            }
            else if (deDonde == "historial")
            {
                FormHistorialPrecioVenta fm = new FormHistorialPrecioVenta();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "historial";
                fm.ShowDialog();
                this.Close();
            }

        }
        public string valor_actual ="";
        public string Id_actual = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarcombobox();
            groupBox1.Enabled = true;
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Id_actual = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            valor_actual = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            button4.Enabled = true;
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre_producto = '{0}'", textBox5.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            llenarcombobox();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (deDonde == "producto")
            {
                string deDonde = "producto";
                FormSubCategoriaProducto fm = new FormSubCategoriaProducto();
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
                FormSubCategoriaProducto fm = new FormSubCategoriaProducto();
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
                FormSubCategoriaProducto fm = new FormSubCategoriaProducto();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            label4.Text = deDonde;
            Listar();
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
