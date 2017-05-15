using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConvertPajek
{
    public class DatabaseService
    {
        public static SqlConnection connection = null;
        public bool Connect(string conn)
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
        public void Open()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public void Close()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        //ToDo: get result function
        public string getResult(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    return oReader["AuthorName"].ToString();
                } 
                connection.Close();
            }
            return "";
        }
    }
}
