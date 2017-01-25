using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using entityModels;


namespace dataModels
{
    public class utilitariosData
    {

        conexionBD cn = new conexionBD();


        #region "Departamentos"


        public List<Departamento> FPub_ListDepartamentos()
        {
            return FPriv_ListaDepartamentos();
        }

        private List<Departamento> FPriv_ListaDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();

            cn.getCn.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID_DEPARTAMENTO,DEPARTAMENTO FROM TB_DEPARTAMENTO", cn.getCn);

            
            Departamento inicio = new Departamento();
            inicio.Id_departamento = 0;
            inicio.Departamento_descripcion = "--Departamento--";

            departamentos.Add(inicio);
            


            using (var read = cmd.ExecuteReader())
            {
                while (read.Read())
                {

                    Departamento departamento = new Departamento();
                    departamento.Id_departamento = (int)read["ID_DEPARTAMENTO"];
                    departamento.Departamento_descripcion = (string)read["DEPARTAMENTO"];

                    departamentos.Add(departamento);
                }
            }

            

            cn.getCn.Close();

            return departamentos;
        }


        #endregion

        #region "Provincias"


        public List<Provincia> FPub_ListProvincias( int v_DEPARTAMENTO)
        {
            return FPriv_ListaProvincias(v_DEPARTAMENTO);
        }

        private List<Provincia> FPriv_ListaProvincias( int v_DEPARTAMENTO)
        {
            List<Provincia> provincias = new List<Provincia>();

            cn.getCn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM TB_PROVINCIA WHERE ID_DEPARTAMENTO = @ID_DEPARTAMENTO", cn.getCn);
            cmd.Parameters.AddWithValue("@ID_DEPARTAMENTO", v_DEPARTAMENTO);

            
            Provincia inicio = new Provincia();
            inicio.Id_Departamento = 0;
            inicio.Provincia_descripcion = "--Provincia--";
            inicio.Id_Departamento = 0;

            provincias.Add(inicio);
            
     

            using (var read = cmd.ExecuteReader())
            {
                while (read.Read())
                {

                    Provincia provincia = new Provincia();
                    provincia.Id_Provincia = (int)read["ID_PROVINCIA"];
                    provincia.Provincia_descripcion = (string)read["PROVINCIA"];
                    provincia.Id_Departamento = (int)read["ID_DEPARTAMENTO"];

                    provincias.Add(provincia);
                }
            }



            cn.getCn.Close();

            return provincias;
        }


        #endregion

        #region "Distritos"


        public List<Distrito> FPub_ListDistritos(int v_PROVINCIA)
        {
            return FPriv_ListDistritos(v_PROVINCIA);
        }

        private List<Distrito> FPriv_ListDistritos(int v_PROVINCIA)
        {
            List<Distrito> distritos = new List<Distrito>();

            cn.getCn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM TB_DISTRITO WHERE ID_PROVINCIA = @ID_PROVINCIA", cn.getCn);
            cmd.Parameters.AddWithValue("@ID_PROVINCIA", v_PROVINCIA);

            
            Distrito inicio = new Distrito();
            inicio.Id_Distrito = 0;
            inicio.Distrito_descripcion = "--Distrito--";
        
            distritos.Add(inicio);
            


            using (var read = cmd.ExecuteReader())
            {
                while (read.Read())
                {

                    Distrito distrito = new Distrito();
                    distrito.Id_Distrito = (int)read["ID_DISTRITO"];
                    distrito.Distrito_descripcion = (string)read["DISTRITO"];
                  
                    distritos.Add(distrito);
                }
            }



            cn.getCn.Close();

            return distritos;
        }


        #endregion


    }
}
