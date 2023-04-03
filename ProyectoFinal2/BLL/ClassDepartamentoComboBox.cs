using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetDepartamentoComboBoxTableAdapters;
namespace BLL
{
  public class ClassDepartamentoComboBox
    {
        private DepartamentoTableAdapter COMBOBOX;
        public ClassDepartamentoComboBox()
        {
            COMBOBOX = new DepartamentoTableAdapter();
        }
        public DataTable ListarComboBox()
        {
            return COMBOBOX.GetDataComboBox();
        }//fin listar departamentos
    }
}
