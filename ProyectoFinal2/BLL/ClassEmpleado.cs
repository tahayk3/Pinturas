using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetEmpleadoTableAdapters;
namespace BLL
{
    public class ClassEmpleado
    {
        //ATRIBUTOS
        private EmpleadoTableAdapter EMPLEADO;
        private View_Info_EmpleadoTableAdapter VISTA;
        //constructor que instancia (crea el objeto)
        public ClassEmpleado()
        {
            EMPLEADO = new EmpleadoTableAdapter();
            VISTA = new View_Info_EmpleadoTableAdapter();
        }
        //Metodos
        public DataTable ListarEmpleado()
        {
            return EMPLEADO.GetDataEmpleado();
        }//fin listar departamentos
        public string NuevoEmpleado(string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_cumpleaños, int telefono, string correo, string usuario, string contraseña, int Id_departamento)
        {
            try
            {
              DataTable tabla=  EMPLEADO.GetDataByNoRepetido(usuario);
                if(tabla.Rows.Count<1)
                {
                    EMPLEADO.InsertQueryEmpleado(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_cumpleaños, telefono, correo, usuario, contraseña, Id_departamento);
                    return "Se grabo un nuevo empleado";
                }
                else
                return "ERROR: el usuario "+usuario+" ya existe";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarEmpleado(string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_cumpleaños, int telefono, string correo, string usuario, string contraseña, int Id_departamento, int _Id)
        {
            try
            {
                EMPLEADO.UpdateQueryEmpleado(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_cumpleaños, telefono, correo, usuario, contraseña, Id_departamento, _Id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
        public string ComprobarLogin(string nombre, string contraseña)
        {
            try
            {
                DataTable tabla = EMPLEADO.GetDataByComprobarLogin(nombre, contraseña);
                if (tabla.Rows.Count < 1)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public DataTable ComprobarLogin2(string nombre, string contraseña)
        {
            return EMPLEADO.GetDataByCambiarUC(nombre, contraseña);
        }//fin NuevaEditorial (insertar y mostrar mensaje)

        public DataTable MostrarEmpleado(string usuario, string contraseña)
        {
            return EMPLEADO.GetDataByCambiarUC(usuario, contraseña);
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public DataTable Vista_empleado()
        {
            return VISTA.GetDataVistaEmpleado();
        }
    }
}
