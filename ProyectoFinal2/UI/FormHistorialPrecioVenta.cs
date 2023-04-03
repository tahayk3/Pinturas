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
    public partial class FormHistorialPrecioVenta : Form
    {
        private ClassHistorialPrecioVenta Logica;
        private ClassProducto Logica2;
        private ClassComprobarUser Logica3;
        public FormHistorialPrecioVenta()
        {
            InitializeComponent();
            Logica = new ClassHistorialPrecioVenta();
            Logica2 = new ClassProducto();
            Logica3 = new ClassComprobarUser();
        }
        void Listar(int id)
        {
            dataGridView1.DataSource = Logica.ListarHistorial(id);
            dataGridView1.Refresh();
        }
        public string v1, v2,deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();

        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa el producto");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(comboBox1, "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                int fid = 0;
                Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);
                Listar(fid);
            }
            ValidadCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void llenarcombobox()
        {
            comboBox1.DataSource = Logica2.ListarProductos();
            comboBox1.DisplayMember = "nombre_producto";
            comboBox1.ValueMember = "Id_producto";
            comboBox1.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string deDonde = "historial";
            FormProducto fm = new FormProducto();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Id_producto = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void FormHistorialPrecioVenta_Load(object sender, EventArgs e)
        {
            llenarcombobox();
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
