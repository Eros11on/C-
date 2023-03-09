using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class DAO
    {
        public static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mydatabasw;Integrated Security=True";
        public static int Login(string Username, string Password)
        {
            try
            {
                string sqlQuery1 = "select * from [UserLogin] where username='" + Username + "'";
                string sqlQuery2 = "select * from [UserLogin] where username='" + Username + "'and password ='" + Password + "'";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine(Username);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    Console.WriteLine("不存在该用户，请重新输入！");
                    reader.Close();
                    conn.Close();
                    return 2;
                }
                else
                {
                    reader.Close();
                    cmd.CommandText = sqlQuery2;
                    reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("用户名或密码输入有误，请重新输入！");
                        reader.Close();
                        conn.Close();
                        return 3;
                    }
                    else
                    {
                        Console.WriteLine("成功登录！");
                        conn.Close();
                        return 1;
                       }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }
        }
        public static DataSet viewAccount(string Username)
        {
            SqlConnection con = new SqlConnection(conStr);
            string sqlQuery = "select * from [Account] WHERE username = '" + Username + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Account");
            con.Close();
            return ds;
        }
        public static int Change(string Username, string Password)
        {
            try
            {
                string sqlQuery1 = "select * from [UserLogin] where username='" + Username + "'and password ='" + Password + "'";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("密码错误，请重新输入！");
                    reader.Close();
                    conn.Close();
                    return 2;
                }
                else
                {
                    Console.WriteLine("密码正确，请输入新密码！");
                    reader.Close();
                    conn.Close(); return 1;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }

        }
        public static int Change2(string Username, string Password)
        {
            try
            {
                string sqlQuery1 = "update [UserLogin] set password='" + Password + "'where username ='" + Username + "'";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                int e = cmd.ExecuteNonQuery();
                if (e == 0)
                {
                    Console.WriteLine("修改错误！");
                    con.Close();
                    return 2;
                }

                else
                {
                    Console.WriteLine("修改成功！");
                    con.Close();
                    return 1;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }

        }
        public static Boolean Deposit(int account, float money)
        {
            try
            {
                string sqlQuery1 = "update [Account] set Balance=Balance+'" + money + "'where AccountID ='" + account + "'";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                int e = cmd.ExecuteNonQuery();
                if (e == 0)
                {
                    Console.WriteLine("存款失败！");
                    con.Close();
                    return false;
                }

                else
                {
                    Console.WriteLine("存款成功！");
                    con.Close(); return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean Withdraw(int account, float money)
        {
            try
            {
                string sqlQuery1 = "update [Account] set Balance=Balance-'" + money + "'where AccountID ='" + account + "'";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                int e = cmd.ExecuteNonQuery();
                if (e == 0)
                {
                    Console.WriteLine("取款失败！");
                    con.Close();
                    return false;
                }

                else
                {
                    Console.WriteLine("取款成功！");
                    con.Close(); return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean Transfer(string account, string account1, float money)
        {
            try
            {
                string sqlQuery1 = "update [Account] set Balance=Balance-'" + money + "'where AccountID ='" + account + "'";
                string sqlQuery2 = "update [Account] set Balance=Balance+'" + money + "'where AccountID ='" + account1 + "'";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                SqlCommand cmd1 = new SqlCommand(sqlQuery2, con);
                int e = cmd.ExecuteNonQuery();
                int e1 = cmd1.ExecuteNonQuery();
                if (e == 0 || e1 == 0)
                {
                    Console.WriteLine("转账失败！");
                    con.Close();
                    return false;
                }

                else
                {
                    Console.WriteLine("转账成功！");
                    con.Close(); return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean Addaccount(Account a)
        {
            try
            {
                string sqlQuery1 = "insert into [Account] (AccountID,AccountBank,AccountType,Balance,username,Limit) values ('" + a.Accid + "',N'" + a.Accbank + "',N'" + a.Acctype + "',0,'" + a.Username + "',0)";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                int e = cmd.ExecuteNonQuery();
                if (e == 0)
                {
                    Console.WriteLine("新账户添加失败！");
                    con.Close();
                    return false;
                }

                else
                {
                    Console.WriteLine("新账户添加成功！");
                    con.Close(); return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean Logout(Account a)
        {
            try
            {
                string sqlQuery1 = "delete from [Account] where AccountID ='" + a.Accid + "'";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                con.Open();
                int e = Convert.ToInt32(cmd.ExecuteNonQuery());
                if( e > 0)
                {
                    Console.WriteLine("账户注销成功！");
                    con.Close();
                    return false;
                }
                else
                {
                    Console.WriteLine("账户注销失败！");
                    con.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
        public static Boolean Register(string id, string pw)
        {
            try
            {
                string sqlQuery1 = "insert into [UserLogin] (username,password) values ('" + id + "','" + pw + "')";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery1, con);
                int e = cmd.ExecuteNonQuery();
                if (e == 0)
                {
                    Console.WriteLine("注册失败！");
                    con.Close();
                    return false;
                }

                else
                {
                    Console.WriteLine("注册成功！");
                    con.Close(); return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }
        }
    }
}
