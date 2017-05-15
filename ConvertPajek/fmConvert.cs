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
                    MessageBox.Show(dbService.getResult("select * from Author where id between 1 and 10;"), "Notification");

                }
            }      

        }
    }
}
