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
using System.Drawing;
using System.Drawing.Printing;
namespace UI
{
    public partial class FormFactura : Form
    {
        private ClassMetodoPago Logica7;
        private ClassCliente Logica6;
        private ClassEmpleado Logica5;
        private ClassSerieFactura Logica4;
        private ClassComprobarUser Logica3;
        private ClassProducto Logica2;
        private ClassFactura Logica;
        public FormFactura()
        {
            InitializeComponent();
            Logica7 = new ClassMetodoPago();
            Logica6 = new ClassCliente();
            Logica5 = new ClassEmpleado();
            Logica4 = new ClassSerieFactura();
            Logica3 = new ClassComprobarUser();
            Logica2 = new ClassProducto();
            Logica = new ClassFactura();
        }
        public string v1, v2,deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        } 
        void llenarcomobox2()
        {
            comboBox1.DataSource = Logica2.ListarProductos();
            comboBox1.DisplayMember = "nombre_producto";
            comboBox1.ValueMember = "Id_producto";
            comboBox1.Refresh();
        }
        void llenarcombobox()
        {
            comboBox2.DataSource = Logica4.ListarSerie();
            comboBox2.DisplayMember = "serie";
            comboBox2.ValueMember = "Id_serie";
            comboBox2.Refresh();

            comboBox3.DataSource = Logica5.ListarEmpleado();
            comboBox3.DisplayMember = "primer_nombre";
            comboBox3.ValueMember = "Id_empleado";
            comboBox3.Refresh();

            comboBox4.DataSource = Logica6.ListarCliente();
            comboBox4.DisplayMember = "primer_nombre";
            comboBox4.ValueMember = "Id_cliente";
            comboBox4.Refresh();

            comboBox5.DataSource = Logica7.ListarMetodoPago();
            comboBox5.DisplayMember = "metodo_pago";
            comboBox5.ValueMember = "Id_pago";
            comboBox5.Refresh();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public int ExistenciaReal = 0;
        private bool ValidadCampos3()
        {
            bool ok = true;
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa el producto");
            }
            return ok;
        }
        private void BorrarMensajeError3()
        {
            errorProvider1.SetError(comboBox1, "");
        }
        public int exist=0;
        List<ClassDTOSalvarExistencia> ListadoSalvar = new List<ClassDTOSalvarExistencia>();
        private void button10_Click(object sender, EventArgs e)
        {
            BorrarMensajeError3();
            if (ValidadCampos3())
            {
                int fid = 0;
                Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);
                var Existencia = Logica.ListarExistencia(fid);
                textBox1.Text = Convert.ToString(Existencia);
                ExistenciaReal = Existencia;
                exist = Convert.ToInt32(textBox1.Text);
                //Salvar existencias
                ListadoSalvar.Add(new ClassDTOSalvarExistencia { cantidad = exist, Id_producto = Convert.ToInt32(fid.ToString()) });
            }
            ValidadCampos3();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Existencia = Convert.ToInt32(textBox1.Text);
            if(Existencia<ExistenciaReal)
            Existencia = Existencia + 1;
            textBox1.Text = Convert.ToString(Existencia);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Existencia = Convert.ToInt32(textBox1.Text);
            if(Existencia>1)
            Existencia = Existencia - 1;
            textBox1.Text = Convert.ToString(Existencia);
        }
        private bool ValidadCampos2()
        {
            bool ok = true;
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox1, "Ingresa el producto");
            }
            if (textBox1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox1, "Ingresa la cantidad");
            }
            if (comboBox5.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox5, "Ingresa el metodo de pago");
            }
            return ok;
        }
        private void BorrarMensajeError2()
        {
            errorProvider1.SetError(comboBox1, "");
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(comboBox5, "");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            BorrarMensajeError2();
            if (ValidadCampos2())
            {
                int fid2 = 0;
                Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid2);
                int fid3 = 0;
                fid3 = Convert.ToInt32(textBox1.Text);
                var Sub_total = Logica.ListarSubTotal(fid3, fid2);
                string sub = Convert.ToString(Sub_total);
                //agregar
                listBox1.Items.Add(comboBox1.SelectedValue);
                listBox2.Items.Add(Convert.ToInt32(textBox1.Text));
                listBox3.Items.Add(comboBox5.SelectedValue);
                listBox4.Items.Add(Convert.ToDecimal(sub));
                //
                int n_existenica = Convert.ToInt32(textBox1.Text);
                textBox1.Text = "";
                int enviar = exist - n_existenica;
                string resp = Logica2.ActualizarProductoExistencia(n_existenica, fid2);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Inventario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                llenarcomobox2();
            }
            ValidadCampos2();
        }
        private bool ValidadCampos4()
        {
            bool ok = true;
            if (comboBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox2, "Ingresa la serie");
            }
            if (comboBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox3, "Ingresa el empleado");
            }
            if (comboBox4.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox4, "Ingresa cliente");
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
            if (listBox3.Items.Count <= 0)
            {
                ok = false;
                errorProvider1.SetError(listBox3, "Ingresa el metodo de pago");
            }
            if (listBox4.Items.Count <= 0)
            {
                ok = false;
                errorProvider1.SetError(listBox4, "Ingresa el sub total");
            }

            return ok;
        }
        private void BorrarMensajeError4()
        {
            errorProvider1.SetError(comboBox2, "");
            errorProvider1.SetError(comboBox3, "");
            errorProvider1.SetError(comboBox4, "");
            errorProvider1.SetError(listBox1, "");
            errorProvider1.SetError(listBox2, "");
            errorProvider1.SetError(listBox3, "");
            errorProvider1.SetError(listBox4, "");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BorrarMensajeError4();
            if (ValidadCampos4())
            {
                string respuesta;
                int Serie = Convert.ToInt32(comboBox2.SelectedValue);
                int Empleado = Convert.ToInt32(comboBox3.SelectedValue);
                int Cliente = Convert.ToInt32(comboBox4.SelectedValue);

                List<ClassDTOFactura> ListadoFactura = new List<ClassDTOFactura>();

                for (int x = 0; x < listBox1.Items.Count; x++)
                {
                    for (int y = 0; y < listBox2.Items.Count; y++)
                    {
                        for (int z = 0; z < listBox3.Items.Count; z++)
                        {
                            for (int v = 0; v < listBox4.Items.Count; v++)
                            {
                                if (x == y && y == z && z == v)
                                {
                                    ListadoFactura.Add(new ClassDTOFactura { ID_producto = Convert.ToInt32(listBox1.Items[x].ToString()), Cantidad_vendidos = Convert.ToInt32(listBox2.Items[y].ToString()), Id_pago = Convert.ToInt32(listBox3.Items[z].ToString()), Sub_total = (decimal)listBox4.Items[v] });
                                }
                            }
                        }
                    }
                }
                respuesta = Logica.GrabaFacturaTransaccional(Serie, Empleado, Cliente, ListadoFactura);
                MessageBox.Show(respuesta);
            }
            ValidadCampos4();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox3, "Ingresa el numero de factura");
            }

            return ok;
        }
        private void BorrarMensajeError()
        {

            errorProvider1.SetError(textBox3, "");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                dataGridView1.DataSource = Logica.ListarFactura(Convert.ToInt32(textBox3.Text));
                dataGridView1.Refresh();
            }
            ValidadCampos();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += Imprimir;
                printDocument1.Print();
            }
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 8);
            Font font2 = new Font("Arial Black", 12);
            Font font3 = new Font("Bowlby One SC", 8);
            int ancho = 500;
            int y = 90;
            string total = "";
            e.Graphics.DrawString("NIT EMPRESA: " + dataGridView1.Rows[0].Cells[0].Value.ToString(), font3, Brushes.Black, new RectangleF(50, y += 30, ancho, 20));
            e.Graphics.DrawString("ATENDIDO POR: " + dataGridView1.Rows[0].Cells[13].Value.ToString(), font3, Brushes.Black, new RectangleF(500, y, ancho, 20));
            e.Graphics.DrawString("FECHA DE VENTA: "+dataGridView1.Rows[0].Cells[1].Value.ToString(), font3, Brushes.Black, new RectangleF(50, y += 31, ancho, 20));
            e.Graphics.DrawString("NO: " + dataGridView1.Rows[0].Cells[10].Value.ToString(), font3, Brushes.Black, new RectangleF(500, y, ancho, 20));
            e.Graphics.DrawString("SERIE: " + dataGridView1.Rows[0].Cells[11].Value.ToString(), font3, Brushes.Black, new RectangleF(600, y, ancho, 20));
            y += 32;
            e.Graphics.DrawString("PRODUCTO", font2, Brushes.Black, new RectangleF(50, y, ancho, 20));
            e.Graphics.DrawString("CANTIDAD", font2, Brushes.Black, new RectangleF(200, y, ancho, 20));
            e.Graphics.DrawString("PRECIO", font2, Brushes.Black, new RectangleF(350, y, ancho, 20));
            e.Graphics.DrawString("M PAGO", font2, Brushes.Black, new RectangleF(500, y, ancho, 20));
            e.Graphics.DrawString("VALOR", font2, Brushes.Black, new RectangleF(600, y, ancho, 20));
            y = y + 35;
            for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
            {
                e.Graphics.DrawString("---------------------", font2, Brushes.Red, new RectangleF(600, y, ancho, 30));
                string nombreProducto = dataGridView1.Rows[fila].Cells[5].Value.ToString();
                string cant_ven = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                string precio= dataGridView1.Rows[fila].Cells[6].Value.ToString();
                string metodo_pago = dataGridView1.Rows[fila].Cells[14].Value.ToString();
                string sub_total = dataGridView1.Rows[fila].Cells[4].Value.ToString();
                total = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                e.Graphics.DrawString(nombreProducto, font, Brushes.Black, new RectangleF(50, y, ancho, 30));
                e.Graphics.DrawString(cant_ven, font, Brushes.Black, new RectangleF(200, y, ancho, 30));
                e.Graphics.DrawString(precio, font, Brushes.Black, new RectangleF(350, y, ancho, 30));
                e.Graphics.DrawString(metodo_pago,font, Brushes.Black, new RectangleF(500, y, ancho, 30));
                e.Graphics.DrawString(sub_total, font, Brushes.Black, new RectangleF(600, y, ancho, 30));
                y = y + 20;
            }
            e.Graphics.DrawString("TOTAL: " + total, font2, Brushes.Red, new RectangleF(600, y , ancho, 30));
            e.Graphics.DrawString("Total en letras: " + numalet.ToCardinal(total), font3, Brushes.Black, new RectangleF(50, y, ancho, 30));
            e.Graphics.DrawString("SUJETO A PAGO TRIMESTRALES", font, Brushes.Black, new RectangleF(340, y+=50, ancho, 30));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 1)
            {
                ListadoSalvar.Reverse();
                foreach (ClassDTOSalvarExistencia p in ListadoSalvar)
                {
                    string resp = Logica.ActualizarExistencia(p.cantidad, p.Id_producto);
                    if (resp.ToUpper().Contains("ERROR"))
                        MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(resp, "Editorial actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();
                    comboBox2.Enabled = true;
                    comboBox3.Enabled = true;
                    comboBox4.Enabled = true;
                }
            }
            else
                MessageBox.Show("No hay nada que retornar");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string deDonde = "2";
            FormMetodoPago fm = new FormMetodoPago();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string deDonde = "2";
            FormSerieFactura fm = new FormSerieFactura();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string deDonde = "factura";
            FormUsuarios fm = new FormUsuarios();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string deDonde = "2";
            FormCliente fm = new FormCliente();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                string respuesta;
                respuesta = Logica.CancelarFacturaTransaccional(Convert.ToInt32(textBox3.Text), Convert.ToString(textBox2.Text));
                MessageBox.Show(respuesta);
            }
            ValidadCampos();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string deDonde = "factura";
            FormProducto fm = new FormProducto();
            this.Hide();
            fm.v1 = v1;
            fm.v2 = v2;
            fm.deDonde = deDonde;
            fm.ShowDialog();
            this.Close();
        }

        private void FormFactura_Load(object sender, EventArgs e)
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
            llenarcombobox();
            llenarcomobox2();
            if (label15.Text == "Administrador")
                button16.Enabled = true;
            else
                button16.Enabled = false;
        }
    }
}
