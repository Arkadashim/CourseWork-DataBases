using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class dbutils
    {
        /* */

        // string connstring = "Server=" + host + ";Database=" + db
        //     + ";port=" + port + ";UId=" + username + ";pwd=" + password + ";";


        public static MySqlConnection GetConnect()
        {
            string host = "localhost";
            //int port = 3306;
            string db = "coursework";
            string username = "root";
            string password = "2D$58e81";


            string connstring = $"Server = {host}; Database = {db}; Uid = {username}; Pwd = {password}";
            MySqlConnection conn = new MySqlConnection(connstring);
            return conn;
        }
    }
}
