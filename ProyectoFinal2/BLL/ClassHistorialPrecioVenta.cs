using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetHistorialPrecioVentaTableAdapters;
using System.Net.Http.Headers;

namespace BLL
{
  public  class ClassHistorialPrecioVenta
    {
        private HistorialPrecioVentaTableAdapter HISTORIAL;
        public ClassHistorialPrecioVenta()
        {
            HISTORIAL = new HistorialPrecioVentaTableAdapter();
        }
        //Metodos
        public DataTable ListarHistorial(int id)
        {
            return HISTORIAL.GetDataHistorialPrecioVenta(id);
        }//fin listar departamentos
        public string NuevoCliente(int Id_producto, DateTime fecha_mod, decimal precioVenta)
        {
            try
            {
                HISTORIAL.InsertQueryHistorialPrecioVenta(Id_producto,fecha_mod,precioVenta);
                return "Se grabo un nuevo historial";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarCliente(int Id_producto, DateTime fecha_mod, decimal precioVenta, int _id)
        {
            try
            {
                HISTORIAL.UpdateQueryHistorialPrecioVenta(Id_producto,fecha_mod,precioVenta, _id);
                return "Se actualizo el registro de historial correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
