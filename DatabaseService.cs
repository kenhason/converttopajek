using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConvertToPajek
{
    public class DatabaseService
    {
        public static SqlConnection connection = null;
        public static bool Connect(string conn)
        {
            if (connection != null && connection.State == ConnectionState.Open)
                return true;
            try
            {
                SqlConnection con = new SqlConnection(conn);
                connection = con;
                Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public static void Open()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public static void Close()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        //ToDo function
        //get queryresult
    }
}
