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
using DAL.DataSetSubCategoriaTableAdapters;

namespace UI
{
    public partial class Menu : Form
    {
        private ClassComprobarUser Logica2;
        public Menu()
        {
            InitializeComponent();
            Logica2 = new ClassComprobarUser();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "1";
            FormDepartamento fm = new FormDepartamento();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "1";
            FormMetodoPago fm = new FormMetodoPago();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }
        public string v1, v2,deDonde;
        void Listar()
        {
            dataGridView1.DataSource = Logica2.MostrarEmpleado(v1,v2);
            dataGridView1.Refresh();
        }
       static int valor = 0;
        private void Menu_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label1.Visible = false;
            if(valor==0)
            {
                Listar();
                for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
                {
                    for (int col = 0; col < dataGridView1.Rows[fila].Cells.Count; col++)
                    {
                        string valor = dataGridView1.Rows[fila].Cells[col].Value.ToString();
                        if (col == 0)
                        {
                            label6.Text = valor;
                        }
                        if (col == 1)
                        {
                            label7.Text = valor;
                        }
                        if (col == 2)
                        {
                            label8.Text = valor;
                        }
                        if (col == 3)
                        {
                            label9.Text = valor;
                        }
                    }
                }
                if(label9.Text== "Administrador")
                {
                    button16.Enabled = true;
                    button15.Enabled = true;
                    button14.Enabled = true;
                    button17.Enabled = true;
                    button7.Enabled = true;
                    button3.Enabled = true;
                    button18.Enabled = true;
                    button2.Enabled = true;
                    button5.Enabled = true;
                    button9.Enabled = true;
                    button6.Enabled = true;
                    button12.Enabled = true;
                    button11.Enabled = true;
                    button10.Enabled = true;
                }
                if (label9.Text == "Cajero")
                {
                    button16.Enabled = false;
                    button15.Enabled = false;
                    button14.Enabled = false;
                    button17.Enabled = false;
                    button7.Enabled = false;
                    button3.Enabled = false;
                    button18.Enabled = false;
                    button2.Enabled = false;
                    button5.Enabled = false;
                    button9.Enabled = false;
                    button6.Enabled = false;
                    button12.Enabled = false;
                    button11.Enabled = true;
                    button10.Enabled = false;
                }
                if (label9.Text == "Bodeguero")
                {
                    button16.Enabled = false;
                    button15.Enabled = false;
                    button14.Enabled = false;
                    button17.Enabled = false;
                    button7.Enabled = false;
                    button3.Enabled = false;
                    button18.Enabled = true;
                    button2.Enabled = false;
                    button5.Enabled = false;
                    button9.Enabled = false;
                    button6.Enabled = false;
                    button12.Enabled = false;
                    button11.Enabled = false;
                    button10.Enabled = false;
                }
            }
            valor++;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            valor = 0;
            FormPedido fm = new FormPedido();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {
            if(imageNumber == 10)
            {
                imageNumber = 1;
            }
            Fotos.ImageLocation = string.Format("C:\\ProyectoFinal2\\UI\\imagenes\\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
                LoadNextImage();
        }

        private void Fotos_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "1";
            FormCliente fm = new FormCliente();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormIngresar fm = new FormIngresar();
            this.Hide();
            fm.ShowDialog();
            this.Close();
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
            label1.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "menu";
            FormUsuarios fm = new FormUsuarios();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            valor = 0;
            FormCambiarUC fm = new FormCambiarUC();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            valor = 0;
            FormIngresar fm = new FormIngresar();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            valor = 0;
            FormProveedores fm = new FormProveedores();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "menu";
            FormCategoriaProducto fm = new FormCategoriaProducto();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "sub";
            FormSubCategoriaProducto fm = new FormSubCategoriaProducto();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "historial";
            FormHistorialPrecioVenta fm = new FormHistorialPrecioVenta();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "producto";
            FormProducto fm = new FormProducto();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            valor = 0;
            FormControlAlmacen fm = new FormControlAlmacen();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            valor = 0;
            FormControlAlmacen fm = new FormControlAlmacen();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "1";
            FormSerieFactura fm = new FormSerieFactura();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            valor = 0;
            FormReportes fm = new FormReportes();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            valor = 0;
            string deDonde = "1";
            FormFactura fm = new FormFactura();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }
    }
}
