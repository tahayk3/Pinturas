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
    public partial class FormControlAlmacen : Form
    {
        private ClassControlAlmacen Logica;
        private ClassComprobarUser Logica3;
        public FormControlAlmacen()
        {
            InitializeComponent();
            Logica = new ClassControlAlmacen();
            Logica3 = new ClassComprobarUser();
        }
        void Listar(int id)
        {
            dataGridView1.DataSource = Logica.ListarPedidoProducto(id);
            dataGridView1.Refresh();
        }
        public string v1, v2;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        void llenarPedidos()
        {
            comboBox1.DataSource = Logica.ListarPedido();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "Id_pedido";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) >= 1)
                Listar(Convert.ToInt32(comboBox1.SelectedValue));
            else
                MessageBox.Show("Escoge un pedido");
            Logica.PedidoFinalizado(Convert.ToInt32(comboBox1.SelectedValue));
        }
        public string cantidad, Id_pedidoProducto, Id_producto, Id_pedido = "";

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            label4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cantidad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label10.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            label9.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Id_pedido = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Id_pedidoProducto = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Id_producto = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label4.Text!="-1")
            {
                if (label4.Text != ".")
                {
                    {
                        Logica.PedidoFinalizado(Convert.ToInt32(comboBox1.SelectedValue));
                        FormExistencia fm = new FormExistencia();
                        this.Hide();
                        fm.v1 = v1;
                        fm.cantidad = cantidad;
                        fm.Id_pedidoProducto = Id_pedidoProducto;
                        fm.Id_producto = Id_producto;
                        fm.Id_pedido = Id_pedido;
                        fm.v2 = v2;
                        fm.ShowDialog();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Escoge un detalle de la lista");
            }
            MessageBox.Show("Finalizado");
        }

        private void FormControlAlmacen_Load(object sender, EventArgs e)
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
            llenarPedidos();
            Logica.PedidoFinalizado(Convert.ToInt32(comboBox1.SelectedValue));
        }
    }
}
