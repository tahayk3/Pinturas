using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetProveedoresTableAdapters;
namespace BLL
{
    public  class ClassProveedores
    {

        //ATRIBUTOS
        private ProveedoresTableAdapter PROVEEDORES;
        //constructor que instancia (crea el objeto)
        public ClassProveedores()
        {
            PROVEEDORES = new ProveedoresTableAdapter();
        }
        //Metodos
        public DataTable ListarProveedores()
        {
            return PROVEEDORES.GetDataProveedores();
        }//fin listar departamentos
        public string NuevoProveedor(string nombre, int telefono, string correo, string comentario)
        {
            try
            {
                PROVEEDORES.InsertQueryProveedores(nombre,telefono,correo,comentario);
                return "Se grabo un nuevo departamento";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarProveedor(string nombre, int telefono, string correo, string comentario, int _Id)
        {
            try
            {
                PROVEEDORES.UpdateQuery(nombre,telefono,correo,comentario, _Id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
