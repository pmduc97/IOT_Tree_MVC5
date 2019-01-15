using System.Collections.Generic;
using System.Data.SqlClient;

namespace IOT_Tree_MVC5.Models
{
    public class DatabaseFunction
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        public List<DatabaseItem> getAllDatabase(LoginData loginData)
        {
            int result = connectSQL.Connect(loginData, "master");
            if(result != 1)
            {
                return null;
            }
            List<DatabaseItem> listDatabaseItem = new List<DatabaseItem>();
            string sqlQuery = "SELECT name FROM sysdatabases ORDER BY name";
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                listDatabaseItem.Add(new DatabaseItem(r["name"].ToString()));
            }
            r.Close();
            connectSQL.connect.Close();
            return listDatabaseItem;
        }

        public int checkRepeatDatabase(LoginData loginData,string databaseName)
        {
            connectSQL.Connect(loginData, "master");
            int i = 0;
            string sqlQuery = "SELECT name FROM sysdatabases WHERE name = @databaseName";
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            cmd.Parameters.Add(new SqlParameter("databaseName", databaseName));
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                i = 1;
            }
            r.Close();
            connectSQL.connect.Close();
            return i;
        }

        public string createDatabase(LoginData loginData,string databaseName)
        {
            if(checkRepeatDatabase(loginData,databaseName) == 1)
            {
                return "Đã tồn tại database : " + databaseName;
            }
            connectSQL.Connect(loginData, "master");
            string sqlQuery = "CREATE DATABASE " + databaseName;
            SqlCommand cmd = new SqlCommand(sqlQuery, connectSQL.connect);
            int i = cmd.ExecuteNonQuery();
            connectSQL.connect.Close();
            if(i == -1)
            {
                return "Tạo database <" + databaseName + "> thành công";
            }
            return "Có lỗi trong quá trình tạo. Vui lòng thử lại";
        }

    }
}