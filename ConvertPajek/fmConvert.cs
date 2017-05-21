using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertPajek
{
    public partial class fmConvert : Form
    {
        DatabaseService dbService = new DatabaseService();
        public fmConvert()
        {
            InitializeComponent();
        }


        public bool checkLogin()
        {
            if (tbUsername.Text == "" && tbPassword.Text == "") return false;
            if (tbUsername.Text != "" && tbPassword.Text != "") return true;
            return false; 
        }

        private void btnLoadMdf_Click(object sender, EventArgs e)
        {
            if (checkLogin() == false)
                MessageBox.Show("Please input your Neo4j username and password", "Notification");
            else
            {
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Title = "Open .mdf File";
                oFD.Filter = "MDF files|*.mdf";
                if (oFD.ShowDialog() == DialogResult.OK)
                {
                    string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                        oFD.FileName.ToString() + ";Integrated Security=True;Connect Timeout=30";
                    if (dbService.Connect(conn))
                    {
                        //ToDo: convert
                        dbService.exportArticleToCSV("select * from Article where id between 1 and 50;");
                        MessageBox.Show("Article.csv is writtern successfully", "Notification");
                        dbService.exportArticleCitationToCSV("select * from ArticleCitation where id between 1 and 50;");
                        MessageBox.Show("ArticleCitation.csv is writtern successfully", "Notification");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkLogin() == false)
                MessageBox.Show("Please input your Neo4j username and password", "Notification");
            else
            {
                dbService.setLogin(tbUsername.Text, tbPassword.Text);
                Console.WriteLine("Connecting to Database Services...");
                if (dbService.importCSVToNeo4j(""))
                    MessageBox.Show("Import Successfully");
                else
                    MessageBox.Show("Failed to import");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkLogin() == false)
                MessageBox.Show("Please input your Neo4j username and password", "Notification");
            else
            {
                dbService.setLogin(tbUsername.Text, tbPassword.Text);
                if (dbService.importArticleCitation(""))
                    MessageBox.Show("Import Successfully");
                else
                    MessageBox.Show("Failed to import");
            }
        }

        private void btnLoadArticleFile_Click(object sender, EventArgs e)
        {
            if (checkLogin() == false)
                MessageBox.Show("Please input your Neo4j username and password", "Notification");
            else
            {
                dbService.setLogin(tbUsername.Text, tbPassword.Text);
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Title = "Open .csv File";
                oFD.Filter = "CSV files|*.csv";
                if (oFD.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Importing from .csv file...");
                    if (dbService.importCSVToNeo4j(oFD.FileName.ToString()))
                        MessageBox.Show("Import Successfully");
                    else
                        MessageBox.Show("Failed to import");
                }
            }
        }

        private void btnLoadCitationFile_Click(object sender, EventArgs e)
        {
            if (checkLogin() == false)
                MessageBox.Show("Please input your Neo4j username and password", "Notification");
            else
            {
                dbService.setLogin(tbUsername.Text, tbPassword.Text);
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Title = "Open .csv File";
                oFD.Filter = "CSV files|*.csv";
                if (oFD.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Importing from .csv file...");
                    if (dbService.importArticleCitation(oFD.FileName.ToString()))
                        MessageBox.Show("Import Successfully");
                    else
                        MessageBox.Show("Failed to import");
                }
            }
        }

        private void fmConvert_Load(object sender, EventArgs e)
        {

        }
    }
}
