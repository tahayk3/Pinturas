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
    public partial class FormCambiarUC : Form
    {
        private ClassEmpleado Logica;
        private ClassComprobarUser Logica3;
        public FormCambiarUC()
        {
            InitializeComponent();
            Logica = new ClassEmpleado();
            Logica3 = new ClassComprobarUser();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        void Listar()
        {
            dataGridView1.DataSource = Logica.ComprobarLogin2(textBox8.Text,textBox9.Text);
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void FormCambiarUC_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = true; 
            textBox9.Enabled = true;
            comboBox2.Enabled = false;
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
        }
        public string v1, v2;
        private void button5_Click(object sender, EventArgs e)
        {
            FormIngresar fm = new FormIngresar();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }
        private bool ValidadCampos()
        {
            bool ok = true;
            if (textBox8.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox8, "Ingresa el un usuario");
            }
            if (textBox9.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textBox9, "Ingresa la contraseña");
            }
            return ok;
        }
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(textBox8, "");
            errorProvider1.SetError(textBox9, "");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (ValidadCampos())
            {
                if(label5.Text!="label5")
                {
                    int Id = Convert.ToInt32(label5.Text);
                    string resp = Logica.ActualizarEmpleado(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text, textBox8.Text, textBox9.Text, Convert.ToInt32(comboBox2.Text), Id);
                    if (resp.ToUpper().Contains("ERROR"))
                        MessageBox.Show(resp, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(resp, "usuario actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listar();
                }
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

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
