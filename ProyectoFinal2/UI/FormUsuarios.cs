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
    public partial class FormUsuarios : Form
    {
        private ClassEmpleado Logica;
        private ClassDepartamentoComboBox Logica2;
        private ClassComprobarUser Logica3;
        public FormUsuarios()
        {
            InitializeComponent();
            Logica3 = new ClassComprobarUser();
            Logica2 = new ClassDepartamentoComboBox();
            Logica = new ClassEmpleado();
        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarEmpleado();
            dataGridView1.Refresh();
        }
        
        void llenarcombobox()
        {
            comboBox2.DataSource = Logica2.ListarComboBox();
            comboBox2.DisplayMember = "nombre_cargo";
            comboBox2.ValueMember = "Id_departamento";
            comboBox2.Refresh();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
        }
        public string v1, v2,deDonde;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormUsuarios_Load(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            if(deDonde =="menu")
            {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "menu";
                fm.ShowDialog();
                this.Close();
            } else if(deDonde == "factura")
            {
                FormFactura fm = new FormFactura();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "factura";
                fm.ShowDialog();
                this.Close();
            }else if (deDonde == "usuarioMenu")
            {
                Menu fm = new Menu();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = "usuarioMenu";
                fm.ShowDialog();
                this.Close();
            }
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
                string resp = Logica.ActualizarEmpleado(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text, textBox8.Text, textBox9.Text, Convert.ToInt32(comboBox2.SelectedValue), Id);
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
            }
            ValidadCampos();
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
                errorProvider1.SetError(textBox2, "Ingresa el segundo nombre");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox3, "Ingresa el primer apellido");
            }
            if (textBox4.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox4, "Ingresa el segundo apellido");
            }
            if (textBox5.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox5, "Ingresa la fecha de cumpleaños");
            }
            if (textBox6.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox6, "Ingresa el telefono");
            }
            if (textBox7.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox7, "Ingresa el correo");
            }
            if (textBox8.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox8, "Ingresa el usuario");
            }
            if (textBox9.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox9, "Ingresa la contraseña");
            }
            if (comboBox2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboBox2, "Ingresa el departamento");
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
        private void button4_Click(object sender, EventArgs e)
        {
                BorrarMensajeError();
            if (ValidadCampos())
            {
                string resp = Logica.NuevoEmpleado(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text, textBox8.Text, textBox9.Text, Convert.ToInt32(comboBox2.SelectedValue));
                if (resp.ToUpper().Contains("ERROR"))
                    MessageBox.Show(resp, "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(resp, "Editorial grabada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ValidadCampos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void __Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && dataGridView1.Rows.Count > 0)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("primer_nombre = '{0}'", textBox10.Text);
            else
                MessageBox.Show("Busca algo primero");
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (deDonde=="menu")
            {
                deDonde = "usuarioMenu";
                FormDepartamento fm = new FormDepartamento();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
            if (deDonde == "factura")
            {
                deDonde = "factura";
                FormDepartamento fm = new FormDepartamento();
                this.Hide();
                fm.v1 = v1;
                fm.v2 = v2;
                fm.deDonde = deDonde;
                fm.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = comboBox2.ValueMember;
            llenarcombobox();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
