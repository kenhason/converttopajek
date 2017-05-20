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

        private void btnLoadMdf_Click(object sender, EventArgs e)
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
                    dbService.exportArticleToCSV("select * from Article where id between 1 and 10000;");
                    MessageBox.Show("Article.csv is writtern successfully", "Notification");
                    dbService.exportArticleCitationToCSV("select * from ArticleCitation where id between 1 and 60000;");
                    MessageBox.Show("ArticleCitation.csv is writtern successfully", "Notification");
                }
            }      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connectig to Database Services...");
            if (dbService.importCSVToNeo4j())
                MessageBox.Show("Import Successfully");
            else
                MessageBox.Show("Failed to import");
        }
    }
}
