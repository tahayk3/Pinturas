using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetCategoriaProductoTableAdapters;
namespace BLL
{
    public class ClassCategoriaProductos
    {
        //ATRIBUTOS
        private CategoriaProductoTableAdapter CATEGORIA;
        //constructor que instancia (crea el objeto)
        public ClassCategoriaProductos()
        {
            CATEGORIA = new CategoriaProductoTableAdapter();
        }
        //Metodos
        public DataTable ListarCategoria()
        {
            //esto falla
            return CATEGORIA.GetDataCategoriaProducto();
        }//fin listar departamentos

        public string NuevaCategoria(string nombre)
        {
            try
            {

                CATEGORIA.InsertQueryCategoriaProducto(nombre);
                return "Se grabo una nueva categoria";

            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarCategoria(string nombre, int _id)
        {
            try
            {
                CATEGORIA.UpdateQueryCategoriaProducto(nombre, _id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
