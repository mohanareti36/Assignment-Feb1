using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLAssignmt
{
    class oper
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader cr = null;
        public int inpar()
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
                cmd = new SqlCommand("insert into emp values(@ename,@sal,@deptid)", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Float).Value = sal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
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

            }
        }
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
        public int delpar()
        {
            try
            {
                Console.WriteLine("enter the emp id u want to delete");
                var id = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("delete from emp where empid=@eid", cn);
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = id;
                cn.Open();
                int d = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted from table");
                shw();
                return d;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int updpar()
        {
            try
            {
                Console.WriteLine("enter the emp id u want to update");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the name to update");
                var nam = Console.ReadLine();
                Console.WriteLine("enter emp sal");
                var sal = Single.Parse(Console.ReadLine());
                Console.WriteLine("enter dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=LAPTOP-83VT7HJE;Initial Catalog=Mohanzensar;Integrated Security=True");
                cmd = new SqlCommand("update emp set empname=@ename,sal=@sal,deptno=@did where empid=@eid", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = nam;
                cmd.Parameters.Add("@sal", SqlDbType.Decimal).Value = sal;
                cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = id;

                cn.Open();
                int u = cmd.ExecuteNonQuery();
                Console.WriteLine("one row updates from table");
                shw();
                return u;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
    }
    class Sqlwithpara
    {
        static void Main()
        {


            oper op = new oper();

            Console.WriteLine("enter 1 to insert");
            Console.WriteLine("enter 2 to delete");
            Console.WriteLine("enter 3 to update");
            Console.WriteLine("e nter 4 to show data");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                op.inpar();
                Main();
            }
            else if (a == 2)
            {
                op.delpar();
                Main();
            }
            else if (a == 3)
            {
                op.updpar();
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
