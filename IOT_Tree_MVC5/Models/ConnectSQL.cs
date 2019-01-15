using System;
using System.Data.SqlClient;

namespace IOT_Tree_MVC5.Models
{
    public class ConnectSQL
    {
        public SqlConnection connect;

        /// <summary>
        /// Login SQL with Database root
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        public string Login(LoginData loginData)
        {
            //Initial Catalog={2};
            string sqlQuery = string.Format(@"Data Source={0},{1};Persist Security Info=True;User ID={2};Password={3};Connect Timeout=5;", loginData.Server, loginData.Port, loginData.Username, loginData.Password);
            try{
                try
                {
                    connect = new SqlConnection(sqlQuery);
                }
                catch(Exception)
                {
                    //Exception ex
                    //return ex.Message;
                    return "Lỗi. Dữ liệu truyền vào không được chứa kí tự " + " ' hoặc " + '"';
                }
                connect.Open();
                connect.Close();
                return "OK";
            }
            catch(SqlException ex)
            {
                if(ex.Number == 18456)
                {
                    return "Username hoặc Password không đúng";
                }
                if(ex.Number == 1225)
                {
                    return "Port không đúng";
                }
                if(ex.Number == 11001 || ex.Number == 11003)
                {
                    return "Server không đúng";
                }
                if(ex.Number == 87)
                {
                    return "Server hoặc Port không hợp lệ";
                }
                return ex.Message;
            }
        }

        /// <summary>
        /// Login SQL with Database databaseName
        /// </summary>
        /// <param name="loginData"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public int Connect(LoginData loginData,string databaseName)
        {
            string sqlQuery = string.Format(@"Data Source={0},{1};Persist Security Info=True;User ID={2};Password={3};Initial Catalog={4};Connect Timeout=5;", loginData.Server, loginData.Port, loginData.Username, loginData.Password,databaseName);
            try
            {
                try
                {
                    connect = new SqlConnection(sqlQuery);
                }
                catch (Exception)
                {
                    return -101;
                }
                connect.Open();
                return 1;
            }
            catch (SqlException)
            {
                //4060 : không có databaseName trong đường kết nối này
                return 0;
            }
        }
    }
}