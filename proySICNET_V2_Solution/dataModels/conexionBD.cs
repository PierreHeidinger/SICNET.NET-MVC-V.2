using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace dataModels
{
    public class conexionBD
    {
        SqlConnection cn = new SqlConnection("server=PIERRE-PC\\PIERRE;database=SICNET_BD;uid=sa;pwd=sql");

        public SqlConnection getCn
        {
            get { return cn; }
        }

        
    }
}
