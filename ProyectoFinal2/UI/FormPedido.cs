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
    public partial class FormPedido : Form
    {
        private ClassPedido Logica;
        private ClassEmpleado Logica2;
        private ClassComprobarUser Logica3;
        private ClassProducto Logica4;
        public FormPedido()
        {
            InitializeComponent();
            Logica = new ClassPedido();
            Logica2 = new ClassEmpleado();
            Logica3 = new ClassComprobarUser();
            Logica4 = new ClassProducto();
        }
        void LlenarCombos()
        {
            comboBox3.DataSource = Logica.ListarProducto();
            comboBox3.DisplayMember = "nombre_producto";
            comboBox3.ValueMember = "Id_producto";
            comboBox3.Refresh();
            comboBox2.DataSource = Logica.ListarProveedores();
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "Id_proveedor";
            comboBox2.Refresh();
            comboBox1.DataSource = Logica2.ListarEmpleado();
            comboBox1.DisplayMember = "primer_nombre";
            comboBox1.ValueMember = "Id_empleado";
            comboBox1.Refresh();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarPago();
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            LlenarCombos();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError2();
            if (ValidadCampos2())
            {
                string respuesta;
                int CodigoEmpleado = Convert.ToInt32(comboBox1.SelectedValue);
                int CodigoProveedor = Convert.ToInt32(comboBox2.SelectedValue);

                List<ClassDTOpedido> ListadoPedido = new List<ClassDTOpedido>();

                for (int x = 0; x < listBox1.Items.Count; x++)
                {
                    for (int y = 0; y < listBox2.Items.Count; y++)
                    {
                        if (x == y)
                        {
                            ListadoPedido.Add(new ClassDTOpedido { cantidad = Convert.ToInt32(listBox2.Items[x].ToString()), Id_producto = Convert.ToInt32(listBox1.Items[y].ToString()) });
                        }
                    }
                }
                respuesta = Logica.GrabaPrestamoTransaccional(CodigoEmpleado, CodigoProveedor, ListadoPedido);
                MessageBox.Show(respuesta);
            }
            ValidadCampos2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        public string v1, v2;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormPedido_Load(object sender, EventArgs e)
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

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
           
        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresa la cantidad");
            }
            if (comboBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox3, "Ingresa el proveedor");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(comboBox3, "");

        }
        private bool ValidadCampos2()
        {
            bool ok = true;
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa al empleado");
            }
            if (comboBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox2, "Ingresa el proveedor");
            }
            if (listBox1.Items.Count <= 0)
            {
                ok = false;
                errorProvider1.SetError(listBox1, "Ingresa el producto");
            }
            if (listBox2.Items.Count <= 0)
            {
                ok = false;
                errorProvider1.SetError(listBox2, "Ingresa la cantidad");
            }
            return ok;
        }
        private void BorrarMensajeError2()
        {
            errorProvider1.SetError(comboBox1, "");
            errorProvider1.SetError(comboBox2, "");

        }
        private void button9_Click(object sender, EventArgs e)
        {

            BorrarMensajeError();
            if (ValidadCampos())
            {
                listBox1.Items.Add(comboBox3.SelectedValue);
                listBox2.Items.Add(Convert.ToInt32(textBox1.Text));
            }
            ValidadCampos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
