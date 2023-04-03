using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using Microsoft.Reporting.WinForms;
using LiveCharts;
using LiveCharts.Wpf;
using SeriesCollection = System.Windows.Forms.DataVisualization.Charting.SeriesCollection;

namespace UI
{
    public partial class FormReportes : Form
    {
        private ClassComprobarUser Logica3;
        private ClassEstadisticas Logica;
        public FormReportes()
        {
            Logica3 = new ClassComprobarUser();
            Logica = new ClassEstadisticas();
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        public string v1, v2;
        void Listar2()
        {
            dataGridView2.DataSource = Logica3.MostrarEmpleado(v1, v2);
            dataGridView2.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var data = Logica.ListarEstadistica8();
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet1", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.R5.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = Logica.ListarEstadistica6(dateTimePicker1.Value, dateTimePicker2.Value);
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet1", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.R3.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["Grafica"].XValueMember = "Nombre_cliente";
            chart1.Series["Grafica"].YValueMembers = "Clientes_con_mas_consumo";
            chart1.DataSource = Logica.ListarEstadistica3();
            chart1.DataBind();
            //
            var data = Logica.ListarEstadistica3();
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet3", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.Estadistica3.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var data = Logica.ListarEstadistica4(dateTimePicker1.Value, dateTimePicker2.Value);
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet1", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.R1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var data = Logica.ListarEstadistica5(dateTimePicker1.Value, dateTimePicker2.Value);
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet1", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.R2.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var data = Logica.ListarEstadistica7(Convert.ToInt32(textBox1.Text));
            ReportDataSource Reporte;
            Reporte = new ReportDataSource("DataSet1", data);
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = @"UI.Reportes.R4.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Reporte);
            this.reportViewer1.RefreshReport();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
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
            this.reportViewer1.RefreshReport();
        }
    }
}
