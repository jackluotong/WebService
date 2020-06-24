using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;


namespace InterFaceDemo
{
    public class DBOperation 
    {
        public SqlConnection sqlCon;//connect to database
        private string ConServerStr = "Data Source=MSH-WORK-386;Initial Catalog=Practice;Integrated Security=True";
        //SqlConnection con = new SqlConnection(@"Data Source=服务器名; database=数据zd库名;User id=用户回名;Password=密码");
        //构造函数
        public DBOperation()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = ConServerStr;
                sqlCon.Open();
            }
        }
        //关闭
        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
                sqlCon = null;
            }
        }
        //从数据库获取信息 查询
        public List<int> selectAllCaroInfor(int Phone)
        {
            List<int> list = new List<int>();
            try 
            {
                string sql = "select Password from dbo.PhonePassword where Phone="+Phone;
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list.Add(list[i]);
                    }
                    //list.Add(reader.GetInt32());//list.Add(reader[0].ToString());
                    //list.Add(reader[1]);  
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                list.Add(1231);
            }
            return list;
        }
        //add
        public bool insertCargonInfo(int Phone, int Password)
        {
            try
            {
                string sql = "insert into dbo.PhonePassword(Phone,Password) values ('" + Phone + "'," + Password + ")";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //delete
        public bool deletdCargonInfo(int Phone)
        {
            try
            {
                string sql = "delete from dbo.PhonePassword where Phone =" + Phone;
                SqlCommand cmd = new SqlCommand(sql,sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool insertCargonInfo1(string Name, string Adress)
        {
            try
            { 
                string sql = "insert into dbo.Name(Name,Adress) values ('" + Name + "'," + Adress + ")";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //查找
        public List<string> SerachInfo(string Name)
        {
            List<string> list = new List<string>();
             DataSet ds = new DataSet();
            try
            {
                StringBuilder builder = new StringBuilder();
               
                builder.Append("select * from dbo.Name where Name = '" + Name + "'");

                
                // string sql = "select * from dbo.Name where Name='" + Name + "'";
                //SqlDataAdapter ad = new SqlDataAdapter(sql, ConServerStr);
                //ad.Fill(ds); 
                //return ds;

                //SqlCommand cmd = new SqlCommand(sql, sqlCon);
                //SqlDataReader sqlDr = cmd.ExecuteReader();
                //if (sqlDr.Read())
                //{
                //    //for (int i = 0; i < list.Count; i++)
                //    //{
                //    //    list.Add(list[i]);
                //    //}

                //    list.Add(sqlDr[0].ToString().Trim());
                //    list.Add(sqlDr[1].ToString().Trim());
                //    list.Add(sqlDr[2].ToString().Trim());
                //    list.Add(sqlDr[3].ToString().Trim());
                //}
                //else
                //{
                //    sqlDr.Close();
                //    cmd.Dispose();
                //    list.Add("---");
                //    return list;
                //}
            }
            catch (Exception)
            {
                 
            }
            return list;
            //return ds;
             
        }

       
    }
}