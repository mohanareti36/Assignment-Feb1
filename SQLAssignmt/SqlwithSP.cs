using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLAssignmt
{
    class opr1
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader cr = null;

        public int shw()
        {
            try
            {
                Console.WriteLine("data from table after the dml command");
                Console.WriteLine("-------------------------------------");
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("select * from emp", cn);
                cn.Open();
                cr = cmd.ExecuteReader();
                Console.WriteLine($"empid\tename\tsal\tdeptid");
                while (cr.Read())
                {
                    Console.WriteLine($"{cr["empid"]}\t{cr["empname"]}\t{cr["sal"]}\t{cr["deptno"]}");
                }
                return 0;


            }
            catch (Exception w)
            {
                Console.WriteLine(w.Message);

            }
            finally
            {
                cn.Close();
            }
            return 0;
        }
        public int inSP()
        {
            try
            {
                Console.WriteLine("enter emp name");
                var ename = Console.ReadLine();
                Console.WriteLine("enter emp sal");
                var sal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("enter dept num");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("sp_InsertEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Decimal).Value = sal;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to table");
                shw();
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int delSp()
        {
            try
            {
                Console.WriteLine("enter the emp id u want to delete");
                var id = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("sp_DelEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = id;
                cn.Open();
                int d = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted from table");
                shw();
                return d;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int upSp()
        {
            try
            {
                Console.WriteLine("enter emp id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter emp name");
                var ename = Console.ReadLine();
                Console.WriteLine("enter emp sal");
                var sal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("enter dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Decimal).Value = sal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
                cn.Open();
                int u = cmd.ExecuteNonQuery();
                Console.WriteLine("ONe row updated from the table");
                shw();
                return u;
            }
            catch (Exception w)
            {
                Console.WriteLine(w.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

    }
    class SqlwithSP
    {
        static void Main()
        {
            opr1 op = new opr1();

            Console.WriteLine("enter 1 to insert");
            Console.WriteLine("enter 2 to delete");
            Console.WriteLine("enter 3 to update");
            Console.WriteLine("enter 4 to show data");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                op.inSP();
                Main();
            }
            else if (a == 2)
            {
                op.delSp();
                Main();
            }
            else if (a == 3)
            {
                op.upSp();
                Main();
            }
            else if (a == 4)
            {
                op.shw();
                Main();
            }
            else Console.WriteLine("Thanku..");
        }
    }
}
