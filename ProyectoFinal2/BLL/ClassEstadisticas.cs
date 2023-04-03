using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetEstadisticasTableAdapters;
namespace BLL
{
    public class ClassEstadisticas
    {
        private Metodo_pagoTableAdapter ESTADISTICA;
        private ProductoMasVendido10_Adapter ESTADISTICA2;
        private DataTable1TableAdapter ESTADISTICA3;
        private esta1TableAdapter ESTA1;
        private Producto1TableAdapter ESTA2;
        private Producto2TableAdapter ESTA3;
        private DataTable2TableAdapter ESTA4;
        private Producto3TableAdapter ESTA5;
        //constructor que instancia (crea el objeto)
        public ClassEstadisticas()
        {
            ESTADISTICA = new Metodo_pagoTableAdapter();
            ESTADISTICA2 = new ProductoMasVendido10_Adapter();
            ESTADISTICA3 = new DataTable1TableAdapter();
            ESTA1 = new esta1TableAdapter();
            ESTA2 = new Producto1TableAdapter();
            ESTA3 = new Producto2TableAdapter();
            ESTA4 = new DataTable2TableAdapter();
            ESTA5 = new Producto3TableAdapter();
        }
        //Metodos
        public DataTable ListarEstadistica()
        {
            return ESTADISTICA.GetDataEstadistica1();
        }//fin listar departamentos
        public DataTable ListarEstadistica2()
        {
            return ESTADISTICA2.GetDataEstadistica2();
        }//fin listar departamentos
        public DataTable ListarEstadistica3()
        {
            return ESTADISTICA3.GetDataEstadistica3();
        }//fin listar departamentos
        public DataTable ListarEstadistica4(DateTime ini, DateTime fin)
        {
            return ESTA1.GetData(ini,fin);
        }//fin listar departamentos
        public DataTable ListarEstadistica5(DateTime ini, DateTime fin)
        {
            return ESTA2.GetDataEsta2(ini, fin);
        }//fin listar departamentos
        public DataTable ListarEstadistica6(DateTime ini, DateTime fin)
        {
            return ESTA3.GetData3(ini, fin);
        }//fin listar departamentos
        public DataTable ListarEstadistica7(int ini)
        {
            return ESTA4.GetData(ini);
        }//fin listar departamentos
        public DataTable ListarEstadistica8()
        {
            return ESTA5.GetData5();
        }//fin listar departamentos
    }
}
