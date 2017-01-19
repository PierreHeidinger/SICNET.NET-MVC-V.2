using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataModels;
using entityModels;

namespace bussinesModel
{
    public class clienteBussines
    {

        clienteData obj_cliente = new clienteData();

        //Busqueda de Clientes en el panel principal
        public List<Cliente> FPub_Listar_Clientes(string v_CODIGO, String v_CLIENTE)
        {
            List<Cliente> vacio = new List<Cliente>();

            if (!string.IsNullOrEmpty(v_CODIGO))
            {
                if(v_CODIGO.Length == 4) {
                    return obj_cliente.FPub_ListadoClientes(v_CODIGO, v_CLIENTE);
                }
            }

            if (!string.IsNullOrEmpty(v_CLIENTE))
            {
                return obj_cliente.FPub_ListadoClientes(v_CODIGO, v_CLIENTE);
            }

            return vacio;
        }


        //Detalle y Edicion del Cliente

        public Cliente FPub_DetalleCliente(string v_CODIGO)
        {
            return obj_cliente.FPub_DetalleCliente(v_CODIGO);
        }

    }
}
