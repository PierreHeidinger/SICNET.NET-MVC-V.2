using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using entityModels;
using System.Data;



namespace dataModels
{
    public class clienteData
    {
        conexionBD cn = new conexionBD();


        #region "Funcion Listado Clientes"
        
        public List<cliente> FPub_ListadoClientes(String v_CODIGO, String v_CLIENTE)
        {
            return FPriv_ListadoClientes( v_CODIGO,  v_CLIENTE);
        }

        private List<cliente> FPriv_ListadoClientes(String v_CODIGO,String v_CLIENTE)
        {
            List<cliente> clientes = new List<cliente>();

            cn.getCn.Open();

             SqlCommand cmd = new SqlCommand("SP_CLIENTES_BUSQUEDA_CAB", cn.getCn);

           
            cmd.Parameters.AddWithValue("@CODIGO", v_CODIGO);            
            cmd.Parameters.AddWithValue("@CLIENTE", v_CLIENTE);

            cmd.CommandType = CommandType.StoredProcedure;

            using (var read = cmd.ExecuteReader())
            {
                while (read.Read()) { 

                    cliente Cliente = new cliente(Convert.ToString(read["CODIGO"]),(string)read["DOCUMENTO"], (string)read["TIPO_DOCUMENTO"], (string)read["NOMBRES"],(string)read["APELLIDO_PATERNO"],
                                                  (string)read["APELLIDO_MATERNO"],(DateTime)read["FECHA_NACIMIENTO"],(DateTime)read["FECHA_REGISTRO"],
                                                   (int)read["DEPARTAMENTO"],(int)read["DISTRITO"],(int)read["PROVINCIA"],(string)read["DIRECCION"], (string)read["TIPO_DOCUMENTO_DESCRIPCION"]);

                    clientes.Add(Cliente);  
                }
            }

            cn.getCn.Close();

            return clientes;

        }
        
        #endregion

    }
}
