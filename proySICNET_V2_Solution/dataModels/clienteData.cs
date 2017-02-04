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


        #region "Funcion Listado Cab"

        public List<Cliente> FPub_ListadoClientes(String v_CODIGO, String v_CLIENTE)
        {
            return FPriv_ListadoClientes(v_CODIGO, v_CLIENTE);
        }

        private List<Cliente> FPriv_ListadoClientes(String v_CODIGO, String v_CLIENTE)
        {
            List<Cliente> clientes = new List<Cliente>();

            cn.getCn.Open();

            SqlCommand cmd = new SqlCommand("SP_CLIENTES_BUSQUEDA_CAB", cn.getCn);


            cmd.Parameters.AddWithValue("@CODIGO", v_CODIGO);
            cmd.Parameters.AddWithValue("@CLIENTE", v_CLIENTE);

            cmd.CommandType = CommandType.StoredProcedure;

            using (var read = cmd.ExecuteReader())
            {
                while (read.Read()) {

                    Cliente Cliente = new Cliente(Convert.ToString(read["CODIGO"]), (string)read["DOCUMENTO"], (string)read["TIPO_DOCUMENTO"], (string)read["NOMBRES"], (string)read["APELLIDO_PATERNO"],
                                                  (string)read["APELLIDO_MATERNO"], (DateTime)read["FECHA_NACIMIENTO"], (DateTime)read["FECHA_REGISTRO"],
                                                   (int)read["DEPARTAMENTO"], (int)read["DISTRITO"], (int)read["PROVINCIA"], (string)read["DIRECCION"]);

                    clientes.Add(Cliente);
                }
            }

            cn.getCn.Close();

            return clientes;

        }

        #endregion

        #region "Funcion Mostrar Detalle"


        public Cliente FPub_DetalleCliente(string v_CODIGO)
        {
            return FPriv_DetalleCliente(v_CODIGO);
        }


        private Cliente FPriv_DetalleCliente(string v_CODIGO)
        {

            Cliente cliente = null;

            cn.getCn.Open();
            SqlCommand cmd = new SqlCommand("SP_CLIENTE_DETALLE_CAB", cn.getCn);
            cmd.Parameters.AddWithValue("@CODIGO", v_CODIGO);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    cliente = new Cliente(read["CODIGO"].ToString(), (string)read["DOCUMENTO"], (string)read["NOMBRES"], (string)read["APELLIDO_PATERNO"],
                                                  (string)read["APELLIDO_MATERNO"], (DateTime)read["FECHA_NACIMIENTO"], (DateTime)read["FECHA_REGISTRO"],
                                                    (string)read["DIRECCION"], (string)read["DEP_DESCRIPCION"], (string)read["PROV_DESCRIPCION"],(string)read["DIS_DESCRIPCION"] );
                }
            }


            return cliente;

        }

        #endregion


        #region "Funcion Mantenimiento"

        public int FPub_ClienteMantenimiento(string v_Ind,Cliente cliente){

            return Fpriv_ClienteMantenimiento(v_Ind, cliente);
        }

        private int Fpriv_ClienteMantenimiento(string v_Ind,Cliente cliente)           
        {

            int res;

            cn.getCn.Open();
            SqlCommand cmd = new SqlCommand("SP_CLIENTE_AGREGAR", cn.getCn);
            cmd.Parameters.AddWithValue("@IND", v_Ind);
            cmd.Parameters.AddWithValue("@DOCUMENTO", cliente.documento);
            cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", cliente.tipo_documento);
            cmd.Parameters.AddWithValue("@NOMBRES", cliente.nombres);
            cmd.Parameters.AddWithValue("@APELLIDO_PATERNO", cliente.apellido_paterno);
            cmd.Parameters.AddWithValue("@APELLIDO_MATERNO", cliente.apellido_materno);
            cmd.Parameters.AddWithValue("@RAZON_SOCIAL", cliente.razon_social);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", cliente.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", cliente.departamento);
            cmd.Parameters.AddWithValue("@DISTRITO", cliente.distrito);
            cmd.Parameters.AddWithValue("@PROVINCIA", cliente.provincia);
            cmd.Parameters.AddWithValue("@DIRECCION", cliente.direccion);
            cmd.CommandType = CommandType.StoredProcedure;
            res = cmd.ExecuteNonQuery();

            return res;
        }

        #endregion
    }
}
