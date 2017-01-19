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
            inicio.Departamento_descripcion = "--SELECCIONE--";

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




    }
}
