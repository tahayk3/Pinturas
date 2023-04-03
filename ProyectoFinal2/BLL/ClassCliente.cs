using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetClienteTableAdapters;
namespace BLL
{
   public class ClassCliente
    {
        //ATRIBUTOS
        private Cliente2TableAdapter CLIENTE;
        //constructor que instancia (crea el objeto)
        public ClassCliente()
        {
            CLIENTE = new Cliente2TableAdapter();
        }
        //Metodos
        public DataTable ListarCliente()
        {
            return CLIENTE.GetDataCliente();
        }//fin listar departamentos
        public string NuevoCliente(string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, int telefono, string correo)
        {
            try
            {
                    CLIENTE.InsertQueryCliente(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, telefono, correo);
                    return "Se grabo un nuevo departamento";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarCliente(string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, int telefono, string correo, int _id)
        {
            try
            {
                CLIENTE.UpdateQueryCliente(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, telefono, correo, _id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
