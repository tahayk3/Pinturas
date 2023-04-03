using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetDepartamentoTableAdapters;
namespace BLL
{
    public class ClassDepartamento
    {
        //ATRIBUTOS
        private DepartamentoTableAdapter DEPARTAMENTO;
        //constructor que instancia (crea el objeto)
        public ClassDepartamento()
        {
            DEPARTAMENTO = new DepartamentoTableAdapter();
        }
        //Metodos
        public DataTable ListarDepartamentos()
        {
            //esto falla
            return DEPARTAMENTO.GetDataDepartamento();
        }//fin listar departamentos
        public string NuevaEditorial(string nombre_cargo, float _sueldo)
        {
            try 
            {

                    DEPARTAMENTO.InsertQueryDepartamento(nombre_cargo, _sueldo);
                    return "Se grabo un nuevo departamento";

            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarDepartamento(string nombre_cargo, float sueldo ,int _id)
        {
            try
            {
                DEPARTAMENTO.UpdateQueryDepartamento(nombre_cargo,sueldo, _id);
                return "Se actualizo el registro de departamento correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
