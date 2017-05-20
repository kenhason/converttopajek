﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Neo4jClient;

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
        
        public void exportArticleToCSV(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                string title = "Title|Summary|Venue|TitleDateNumber|NumberRealOfCitation|AuthorAndCoAuthor|Link";
                File.AppendAllText(@"Article.csv",  title + Environment.NewLine);

                while (oReader.Read())
                {
                    //replace endline by comma
                    string tmp = oReader["AuthorAndCoAuthor"].ToString().Replace('\n', ',');
                    tmp = tmp.Substring(0, tmp.Length - 2);

                    string csv = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                                  oReader["Title"].ToString().Replace('\n', ' '),
                                  oReader["Summary"].ToString().Replace('\n', ' '),
                                  oReader["Venue"].ToString().Replace('\n', ' '),
                                  oReader["TitleDateNumber"].ToString().Replace('\n', ' '),
                                  oReader["NumberRealOfCitation"].ToString().Replace('\n', ' '),
                                  tmp,
                                  oReader["Link"].ToString().Replace('\n', ' '));
                    File.AppendAllText(@"Article.csv", csv + Environment.NewLine);
                }
                connection.Close();
            }
        }

        public void exportArticleCitationToCSV(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                string title = "ArticleId|CitationId|Link|DateCrawler|IsVerified|IsDeleted|CreateDate|LastUpdate|Description";
                File.AppendAllText(@"ArticleCitation.csv", title + Environment.NewLine);

                while (oReader.Read())
                { 
                    string csv = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                  oReader["ArticleId"].ToString().Replace('\n', ' '),
                                  oReader["CitationId"].ToString().Replace('\n', ' '),
                                  oReader["Link"].ToString().Replace('\n', ' '),
                                  oReader["DateCrawler"].ToString().Replace('\n', ' '),
                                  oReader["IsVerified"].ToString().Replace('\n', ' '),
                                  oReader["IsDeleted"].ToString().Replace('\n', ' '),
                                  oReader["CreateDate"].ToString().Replace('\n', ' '),
                                  oReader["LastUpdate"].ToString().Replace('\n', ' '),
                                  oReader["Description"].ToString().Replace('\n', ' '));
                    File.AppendAllText(@"ArticleCitation.csv", csv + Environment.NewLine);
                }
                connection.Close();
            }
        }

        /**
        * https://dzone.com/articles/neo4j-30-with-a-net-driver-neo4jclient 
        * https://github.com/Readify/Neo4jClient/issues/71
        */
        public bool importCSVToNeo4j()
        {
            Console.WriteLine("Connecting to Neo4j...");
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "neo4j");
            client.Connect();
            ClearDb(client);
            client.Cypher
                .LoadCsv(new Uri("file:C:/Users/KEN/Documents/converttopajek/ConvertPajek/bin/Release/Article.csv"), "row", withHeaders: true, fieldTerminator: "|")
                .Create("(:Article {title: row.Title, summary: row.Summary, venue: row.Venue, titleDateNumber: row.TitleDateNumber, numberRealOfCitation: row.NumberRealOfCitation, authorAndCoAuthor: row.AuthorAndCoAuthor, link: row.Link})")
                .ExecuteWithoutResults();

            //TODO: load ArticleCitation.csv file to Neo4j

            return true;
        }

        private void ClearDb(IGraphClient client)
        {
            client.Cypher
                .Match("(n)")
                .DetachDelete("n")
                .ExecuteWithoutResults();
        }
    }
}
