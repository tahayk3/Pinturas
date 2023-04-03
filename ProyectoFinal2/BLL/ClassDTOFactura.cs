using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassDTOFactura
    {
        public int ID_producto { get; set; }
        public int Id_pago { get; set; }
        public int Cantidad_vendidos { get; set; }
        public decimal Sub_total { get; set; }
    }
}
