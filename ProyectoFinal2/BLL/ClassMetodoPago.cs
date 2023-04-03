using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetMetodoPagoTableAdapters;
namespace BLL
{
  public  class ClassMetodoPago
    {
        //ATRIBUTOS
        private Metodo_pagoTableAdapter MetodoPago;
        //constructor que instancia (crea el objeto)
        public ClassMetodoPago()
        {
            MetodoPago = new Metodo_pagoTableAdapter();
        }
        //Metodos
        public DataTable ListarMetodoPago()
        {
            return MetodoPago.GetDataMetodoPago();
        }//fin listar departamentos
        public string NuevoMetodoPago(string nombre_cargo)
        {
            try
            {
                MetodoPago.InsertQueryMetodoPago(nombre_cargo);
                    return "Se grabo un nuevo departamento";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarMetodoPago(string nombre_cargo, int _id)
        {
            try
            {
                MetodoPago.UpdateQueryMetodoPago(nombre_cargo, _id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
