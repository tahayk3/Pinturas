using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetFacturaTableAdapters;
using System.Data;
namespace BLL
{
    public class ClassFactura
    {
        private DataTable1TableAdapter CANTIDAD;
        private DataTable2TableAdapter FACTURA;
        private ExistenciaTableAdapter SALVAR;
        //constructor que instancia (crea el objeto)
        public ClassFactura()
        {
            CANTIDAD = new DataTable1TableAdapter();
            FACTURA = new DataTable2TableAdapter();
            SALVAR = new ExistenciaTableAdapter();
        }
        //Metodos
        public int ListarExistencia(int id)
        {
            return (int)CANTIDAD.ScalarQueryExistencia(id);
        }//fin listar departamentos
        public int ListarUltimaFactura()
        {
            return (int)CANTIDAD.ScalarQueryUltimaFactura();
        }//fin listar departamentos
        public DataTable ListarFactura(int id)
        {
            return FACTURA.GetDataMostrarFactura(id);
        }//fin listar departamentos
        public decimal ListarSubTotal(int cantidad, int id)
        {
            return (decimal)CANTIDAD.ScalarQuerySubTotal(cantidad,id);
        }//fin listar departamentos
        public string GrabaFacturaTransaccional(int serie, int Id_empleado,int Id_cliente, List<ClassDTOFactura> listado)
        {
            string respuesta = "";
            DataTable tabla = new DataTable() { Columns = { "Id_producto", "Id_pago","cantidad_vendidos","sub_total" } };
            foreach (ClassDTOFactura item in listado)
            {
                tabla.Rows.Add(item.ID_producto, item.Id_pago, item.Cantidad_vendidos,item.Sub_total);
            }
            CANTIDAD.sp_CreaFactura1(serie,Id_empleado,Id_cliente, tabla, ref respuesta);
            return respuesta;
        }
        public string CancelarFacturaTransaccional(int Id_factura, string serie)
        {
            string respuesta = "";
            CANTIDAD.sp_cancelarFactura4(Id_factura, serie, ref respuesta);
            return respuesta;
        }
        public string SalvarCantidadTransaccional(List<ClassDTOSalvarExistencia> listado)
        {
            string respuesta = "";
            DataTable tabla = new DataTable() { Columns = { "cantidad", "Id_producto" } };
            foreach (ClassDTOSalvarExistencia item in listado)
            {
                tabla.Rows.Add(item.cantidad, item.Id_producto);
            }
            CANTIDAD.sp_SalvarCantidad1( tabla, ref respuesta);
            return respuesta;
        }
        public string ActualizarExistencia(int cantidad, int _Id)
        {
            try
            {
                SALVAR.UpdateQueryExistencia(cantidad, _Id);
                return "Se retorno reinicio la existencia";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
