using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetComprobarUserTableAdapters;
namespace BLL
{
   public class ClassComprobarUser
    {
        //ATRIBUTOS
        private DataTable1TableAdapter MOSTRAR;
        //constructor que instancia (crea el objeto)
        public ClassComprobarUser()
        {
            MOSTRAR = new DataTable1TableAdapter();
        }
        //Metodos
        public DataTable MostrarEmpleado(string usuario, string contraseña)
        {
            return MOSTRAR.GetDataMostrar(usuario, contraseña);
        }//fin NuevaEditorial (insertar y mostrar mensaje)
    }
}
