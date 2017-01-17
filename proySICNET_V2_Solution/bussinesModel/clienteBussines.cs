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
       public List<cliente> FPub_Listar_Clientes(string v_CODIGO, String v_CLIENTE)
        { 
                return obj_cliente.FPub_ListadoClientes( v_CODIGO,  v_CLIENTE);
        }

    }
}
