using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ado11
{
    class disconnecteddata
    {
        static void Main()
        {
            SqlConnection con = Class1.getconnection();
            SqlDataAdapter da = new SqlDataAdapter("select * from Manager_table ",con);
            SqlCommandBuilder db = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);

            

            //insert
            DataRow drw = ds.Tables[0].NewRow();
            drw["id"] = 105;
            drw["firstname"] = "rahul";
            drw["exprience"] = 202;
            drw["phone"] = "mayur vihar";
            drw["email_id"] = "rahulsingh@gamil.com";

            ds.Tables[0].Rows.Add(drw);
           // ds.AcceptChanges();
            da.Update(ds);


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    Console.WriteLine("column name :-" + dc.ToString());
                    Console.WriteLine(dr[dc] + " ");

                }
            }
            Console.ReadLine();



        }
    }
}
