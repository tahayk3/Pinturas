using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetPedidoTableAdapters;

namespace BLL
{
  public  class ClassPedido
    {
        //ATRIBUTOS
        private PedidoTableAdapter PEDIDO;
        private ProveedoresTableAdapter PROVEEDORES;
        private ProductoTableAdapter PRODUCTO;
        //constructor que instancia (crea el objeto)
        public ClassPedido()
        {
            PEDIDO = new PedidoTableAdapter();
            PROVEEDORES = new ProveedoresTableAdapter();
            PRODUCTO = new ProductoTableAdapter();
        }
        //Metodos
        public DataTable ListarPago()
        {
            return PEDIDO.GetDataPedido();
        }//fin listar departamentos
        public DataTable ListarProducto()
        {
            return PRODUCTO.GetDataProducto2();
        }//fin listar departamentos
        public DataTable ListarProveedores()
        {
            return PROVEEDORES.GetData();
        }//fin listar departamentos
        public string GrabaPrestamoTransaccional(int estudiante, int proveedor, List<ClassDTOpedido> listado)
        {
            string respuesta = "";
            DataTable tabla = new DataTable() { Columns = { "cantidad", "Id_producto"  } };
            foreach (ClassDTOpedido item in listado)
            {
                tabla.Rows.Add(item.cantidad,item.Id_producto);
            }
            PEDIDO.sp_CreaPedidoP6(estudiante,proveedor, tabla, ref respuesta);
            return respuesta;
        }
    }
}
