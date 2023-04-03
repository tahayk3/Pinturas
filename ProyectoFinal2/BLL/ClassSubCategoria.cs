using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetSubCategoriaTableAdapters;
namespace BLL
{
    public class ClassSubCategoria
    {
        private SubCategoriaProductoTableAdapter SUB;
        //constructor que instancia (crea el objeto)
        public ClassSubCategoria()
        {
            SUB = new SubCategoriaProductoTableAdapter();
        }
        //Metodos
        public DataTable ListarSubCategoria()
        {
            return SUB.GetDataSubCategoria();
        }//fin listar departamentos
        public string NuevoSubCategoria(int Id_SubCategoriaPorducto, string nombre)
        {
            try
            {
                SUB.InsertQuerySubCategoria(Id_SubCategoriaPorducto,nombre);
                return "Se grabo una nueva sub categoria";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarSubCategoria(int Id_SubCategoriaPorducto, string nombre, int _id)
        {
            try
            {
                SUB.UpdateQuerySubCategoria(Id_SubCategoriaPorducto,nombre, _id);
                return "Se actualizo el registro de sub categoria correctamente";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
