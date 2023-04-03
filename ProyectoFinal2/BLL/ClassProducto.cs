using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetProductoTableAdapters;
namespace BLL
{
   public  class ClassProducto
    {
        private ProductoTableAdapter PRODUCTO;
        //constructor que instancia (crea el objeto)
        public ClassProducto()
        {
            PRODUCTO = new ProductoTableAdapter();
        }
        //Metodos
        public DataTable ListarProductos()
        {
            return PRODUCTO.GetDataProducto2();
        }
        public string NuevoProducto(int Id_SubCategoriaProducto, string nombre_producto, decimal precioVenta,  string descripcion)
        {
            try
            {
                PRODUCTO.InsertQueryProducto(Id_SubCategoriaProducto, nombre_producto,precioVenta,descripcion);
                return "Se grabo un nuevo departamento";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarProducto(int Id_SubCategoriaProducto, string nombre_producto, decimal precioVenta, string descripcion, int _Id)
        {
            try
            {
                PRODUCTO.UpdateQueryProducto(Id_SubCategoriaProducto, nombre_producto, precioVenta, descripcion, _Id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
        public string ActualizarProductoExistencia(int cantidad, int _Id)
        {
            try
            {
                PRODUCTO.UpdateQueryExistencia(cantidad, _Id);
                return "Se actualizo el registro de existencia se actualizo correctamente wii";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
        public string GrabaHistorial()
        {
            string respuesta = "";
            PRODUCTO.sp_Historial1(ref respuesta);
            return respuesta;
        }
        public string GrabaHistorial2(int id,decimal precio_actual)
        {
            string respuesta = "";
            PRODUCTO.sp_Historial2(id,precio_actual, ref respuesta);
            return respuesta;
        }
    }
}
