using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetSerieFacturaTableAdapters;
using System.Data;
namespace BLL
{
   public class ClassSerieFactura
    {
        //ATRIBUTOS
        private SerieTableAdapter SERIE;
        //constructor que instancia (crea el objeto)
        public ClassSerieFactura()
        {
            SERIE = new SerieTableAdapter();
        }
        //Metodos
        public DataTable ListarSerie()
        {
            return SERIE.GetDataSerieFactura();
        }//fin listar departamentos
        public string NuevoCliente(string serie)
        {
            try
            {
                SERIE.InsertQuerySerieFactura(serie);
                return "Se grabo una nueva serie";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }//fin NuevaEditorial (insertar y mostrar mensaje)
        public string ActualizarCliente(string serie,int _id)
        {
            try
            {
                SERIE.UpdateQuerySerieFactura(serie, _id);
                return "Se actualizo el registro de la serie correctanete";
            }
            catch (Exception error)
            {
                return "ERROR" + error.Message;
            }
        }//fin ActualizarEditorial
    }
}
