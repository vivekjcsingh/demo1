using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ado11
{
    static class Class1
    {
        static SqlConnection con;
        //static public SqlConnection getconnection()
        //{
        //    con = new SqlConnection("Data Source=.;Initial Catalog=connection1;Integrated Security=True");
        //    return con;
        //}

        static public SqlConnection getconnection()
        {
            String conn = ConfigurationManager.ConnectionStrings["constrng"].ToString();
            con = new SqlConnection(conn);
            return con;
        }
    }
}
