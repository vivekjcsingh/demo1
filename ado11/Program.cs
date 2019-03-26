using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ado11
{
    class Program
    {
        SqlConnection con;
         void retrivedata()
        {
            int flag=0;
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "retrivedata";
            com.CommandType = System.Data.CommandType.StoredProcedure;
            Console.WriteLine("Enter id");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            SqlParameter p = new SqlParameter("@flag", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.ReturnValue;

            SqlParameter p1 = new SqlParameter("@firstname", System.Data.SqlDbType.VarChar, 20);
            SqlParameter p2 = new SqlParameter("@exprience", System.Data.SqlDbType.Int);
            SqlParameter p3 = new SqlParameter("@deptid", System.Data.SqlDbType.Int);
            SqlParameter p4 = new SqlParameter("@phone", System.Data.SqlDbType.VarChar, 10);
            SqlParameter p5 = new SqlParameter("@address", System.Data.SqlDbType.VarChar, 50);
            SqlParameter p6 = new SqlParameter("@email_id", System.Data.SqlDbType.VarChar, 20);

            p1.Direction = System.Data.ParameterDirection.Output;
            p2.Direction = System.Data.ParameterDirection.Output;
            p3.Direction = System.Data.ParameterDirection.Output;
            p4.Direction = System.Data.ParameterDirection.Output;
            p5.Direction = System.Data.ParameterDirection.Output;
            p6.Direction = System.Data.ParameterDirection.Output;

            com.Parameters.Add(p);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            con.Open();
            com.ExecuteNonQuery();
            try
            {
                flag = (int)com.Parameters["@flag"].Value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (flag == 1)
            {
                Console.WriteLine("Name is " + com.Parameters["@firstname"].Value.ToString());
                Console.WriteLine("exprience is " + (int)com.Parameters["@exprience"].Value);
                Console.WriteLine("deptid is " + (int)com.Parameters["@deptid"].Value);
                Console.WriteLine("phone is " + com.Parameters["@phone"].Value.ToString());
                Console.WriteLine("address is " + com.Parameters["@address"].Value.ToString());
                Console.WriteLine("email_id is " + com.Parameters["@email_id"].Value.ToString());
            }
            else
            {
                Console.WriteLine("Such record is not there");
            }
            con.Close();
            Console.ReadLine();


        }
        void fatchdata()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "fatchdata";
            com.CommandType = System.Data.CommandType.StoredProcedure;
            Console.WriteLine("Enter the id");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            SqlParameter p = new SqlParameter("@flag", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.ReturnValue;
            com.Parameters.Add(p);
            con.Open();
            com.ExecuteNonQuery();
            int flag = (int)com.Parameters["@flag"].Value;
            if (flag == 0)
                Console.WriteLine("record is valied");
            else
                Console.WriteLine("record is invalid");

            con.Close();
            Console.ReadLine();

        }
       void search()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from Manager_table where id=@id ";
            Console.WriteLine("Enter the id of the employee");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr[i] + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine("NO record exits");
            }
            dr.Close();
            con.Close();
            Console.ReadLine();
        }

        public void insert()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "insertdata";
            com.CommandType = System.Data.CommandType.StoredProcedure;
            Console.WriteLine("Enter the id ");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("enter firstname");
            com.Parameters.AddWithValue("@firstname", Console.ReadLine());
            Console.WriteLine("Enter exprience ");
            com.Parameters.AddWithValue("@exprience", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("Enter the deptid");
            com.Parameters.AddWithValue("@deptid", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("Enter phone number");
            com.Parameters.AddWithValue("@phone", Console.ReadLine());
            Console.WriteLine("Enter the address ");
            com.Parameters.AddWithValue("@address", Console.ReadLine());
            Console.WriteLine("Enter the email_id ");
            com.Parameters.AddWithValue("@email_id", Console.ReadLine());
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("data inserted");
            Console.ReadLine();

        }

        void delete()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "delete Manager_table where id=@id";
            Console.WriteLine("Enter the id to delete from database");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("data deleted");
            Console.ReadLine();

        }

        void update()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "update Manager_table set firstname=@firstname,exprience=@exprience,deptid=@deptid,phone=@phone,address=@address,email_id=@email_id where id=@id";
            Console.WriteLine("Enter the id");
            com.Parameters.AddWithValue("@id", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("enter firstname");
            com.Parameters.AddWithValue("@firstname", Console.ReadLine());
            Console.WriteLine("Enter exprience ");
            com.Parameters.AddWithValue("@exprience", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("Enter the deptid");
            com.Parameters.AddWithValue("@deptid", Convert.ToByte(Console.ReadLine()));
            Console.WriteLine("Enter phone number");
            com.Parameters.AddWithValue("@phone", Console.ReadLine());
            Console.WriteLine("Enter the address ");
            com.Parameters.AddWithValue("@address", Console.ReadLine());
            Console.WriteLine("Enter the email_id ");
            com.Parameters.AddWithValue("@email_id", Console.ReadLine());
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("data updated ");
            Console.ReadLine();

        }

        void alldata()
        {
            con = Class1.getconnection();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from Manager_table ";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr[i] + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine("NO record exits");
            }
            dr.Close();
            con.Close();
            Console.ReadLine();


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to insert data");
            Console.WriteLine("Enter 2 to delete data");
            Console.WriteLine("Enter 3 to update data");
            Console.WriteLine("Enter 4 to search data");
            Console.WriteLine("Enter 5 to get all data");
            Console.WriteLine("Enter 6 Id is valid or not");
            Console.WriteLine("Enter 7 to retirive data");
            Program obj = new Program();
            int i = Convert.ToByte(Console.ReadLine());

            switch (i)
            {
                case 1: 
                    obj.insert();
                break;

                case 2:
                    obj.delete();
                break;

                case 3:
                    obj.update();
                break;

                case 4:
                    obj.search();
                break;

                case 5:
                    obj.alldata();
                break;
                case 6:
                    obj.fatchdata();
                break;
                case 7:
                    obj.retrivedata();
                break;
            }

        }
    }
}
