using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetControlAlmacenTableAdapters;
using System.Data;
namespace BLL
{
    public class ClassControlAlmacen
    {
        private DataTable1TableAdapter LISTARPEDIDO;
        private DataTable2TableAdapterPedido PEDIDO;
        //constructor que instancia (crea el objeto)
        public ClassControlAlmacen()
        {
            LISTARPEDIDO = new DataTable1TableAdapter();
            PEDIDO = new DataTable2TableAdapterPedido();
        }
        //Metodos
        public DataTable ListarPedidoProducto(int id)
        {
            return LISTARPEDIDO.GetDataPedidoProducto(id);
        }//fin listar departamentos
        public DataTable ListarPedido()
        {
            return PEDIDO.GetDataPedido();
        }//fin listar departamentos
        public string GrabaEXISTENCIABODEGA(DateTime fecha_expiracion, int Id_productoPedido, int producto)
        {
            string respuesta = "";
            LISTARPEDIDO.sp_ControlAlmacen9(fecha_expiracion,Id_productoPedido,producto,  ref respuesta);
            return respuesta;
        }
        public string PedidoFinalizado(int pedido)
        {
            string respuesta = "";
            LISTARPEDIDO.sp_PedidoFinalizado1(pedido, ref respuesta);
            return respuesta;
        }
        public string ProductoPedidoFinalizado(int pedido, int producto, int pedidoProducto)
        {
            string respuesta = "";
            LISTARPEDIDO.sp_PedidoProductoFinalizado3(pedido,producto,pedidoProducto, ref respuesta);
            return respuesta;
        }
    }
}
