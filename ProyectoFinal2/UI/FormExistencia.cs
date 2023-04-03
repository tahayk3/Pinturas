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
    public partial class FormExistencia : Form
    {
        private ClassComprobarUser Logica3;
        private ClassControlAlmacen Logica;
        public FormExistencia()
        {
            InitializeComponent();
            Logica3 = new ClassComprobarUser();
            Logica = new ClassControlAlmacen();
        }
        public string v1, v2,cantidad,Id_pedidoProducto,Id_producto,Id_pedido;

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormControlAlmacen fm = new FormControlAlmacen();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public int cuentas = 0;
        public int restantes = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            cuentas++;
            label13.Text = Convert.ToString(cuentas);
            string respuesta;
            int Id_productoPedido2 = Convert.ToInt32(cantidad);
            int Id_producto2 = Convert.ToInt32(Id_producto);
            if(checkBox1.Checked)
            respuesta = Logica.GrabaEXISTENCIABODEGA(Convert.ToDateTime("12/31/9999"),Id_productoPedido2, Id_producto2);
            else
            respuesta = Logica.GrabaEXISTENCIABODEGA(dateTimePicker1.Value, Id_productoPedido2, Id_producto2);
            MessageBox.Show(respuesta);
            Logica.PedidoFinalizado(Convert.ToInt32(label10.Text));
            Logica.ProductoPedidoFinalizado(Convert.ToInt32(Id_pedido), Convert.ToInt32(Id_producto), Convert.ToInt32(cantidad));
            if (cuentas == Convert.ToInt32(label2.Text))
            {
                button8.Enabled = true;
                FormControlAlmacen fm = new FormControlAlmacen();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.ShowDialog();
                this.Close();
            }
        }
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormExistencia_Load(object sender, EventArgs e)
        {
            label13.Text = "0";
            textBox1.Text = "1";
            textBox1.Enabled = false;
            dataGridView2.Visible = false;
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
            label1.Text = cantidad;
            label2.Text = Id_pedidoProducto;
            label10.Text = Id_producto;
            label11.Text = Id_pedido;
            button8.Enabled = false;
            Logica.ProductoPedidoFinalizado(Convert.ToInt32(Id_pedido), Convert.ToInt32(Id_producto), Convert.ToInt32(cantidad));
        }
    }
}
