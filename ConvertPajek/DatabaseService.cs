using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
        
        //ToDo: write file function
        public string getResult(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                string title = "Title|Summary|Venue|TitleDateNumber|NumberRealOfCitation|AuthorAndCoAuthor|Link";
                File.AppendAllText(@"result.csv",  title + Environment.NewLine);

                while (oReader.Read())
                {
                    //replace \n
                    string tmp = oReader["AuthorAndCoAuthor"].ToString().Replace('\n', ',');
                    tmp = tmp.Substring(0, tmp.Length - 2);


                    /*  Write to file with format 
                     *  Title#Summary#Venue#TitleDateNumber#NumberRealOfCitation#AuthorAndCoAuthor#Link
                     */
                    //string text = oReader["Title"].ToString() + "|" +
                    //              oReader["Summary"].ToString() + "|" +
                    //              oReader["Venue"].ToString() + "|" +
                    //              oReader["TitleDateNumber"].ToString() + "|" +
                    //              oReader["NumberRealOfCitation"].ToString() + "|" +
                    //              oReader["AuthorAndCoAuthor"].ToString() + "|" +
                    //              oReader["Link"].ToString();
                    string csv = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                                  oReader["Title"].ToString().Replace('\n', ' '),
                                  oReader["Summary"].ToString().Replace('\n', ' '),
                                  oReader["Venue"].ToString().Replace('\n', ' '),
                                  oReader["TitleDateNumber"].ToString().Replace('\n', ' '),
                                  oReader["NumberRealOfCitation"].ToString().Replace('\n', ' '),
                                  tmp,
                                  oReader["Link"].ToString().Replace('\n', ' '));
                    File.AppendAllText(@"result.csv", csv + Environment.NewLine);
                }
                connection.Close();
            }
            return "Write file was done.";
        }
    }
}
