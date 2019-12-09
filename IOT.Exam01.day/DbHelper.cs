using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
namespace IOT.Exam01.day
{
  public   class DbHelper<T> where T:new()
    {
        public List<T> select(string sql)
        {
            using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = hao; Integrated Security = True"))//连接数据库
            {
                conn.Open();//打开数据库
                SqlCommand cmd = new SqlCommand("select yong.*,bu.BName from yong join bu on yong.Bid=bu.Id", conn);//命令数据库
                SqlDataReader sdr = cmd.ExecuteReader();//数据流
                DataTable dt = new DataTable();//表
                List<T> list = new List<T>();//集合
                Type t = typeof(T);//类型
                while (sdr.Read())//循环
                {
                    object id = t.GetProperties();
                    foreach (PropertyInfo item in dt.Rows)
                    {
                      
                    }
                    list.Add((id)T);  
                }
                conn.Close();//关闭
                return list;//返回
            }           
        }
        public string GetSelect(T t)//显示反射
        {
            Type type = typeof(T);
            string name = type.Name;
            string file =string.Join(",", type.GetProperties().Select(s => s.GetValue(t)));
            string sql = $"select ({file}) from {name} order by {name} desc";
            return sql;
        }
        public List<T> show(T t)//显示
        {
            string sql = GetSelect(t);
            return select(sql);
        }
    }
}
