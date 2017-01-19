using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataModels;
using entityModels;

namespace bussinesModel
{
    public class utilitariosBussines
    {

        utilitariosData obj_utilitarios = new utilitariosData();


        #region "DEPARTAMENTOS"

        public List<Departamento> FPub_ListaDepartamentos()
        {
            return obj_utilitarios.FPub_ListDepartamentos();
        }

        #endregion

    }
}
