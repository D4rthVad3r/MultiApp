using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paintApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\RamVignesh\source\repos\paintApp\paintApp\DB.mdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Table1 WHERE ID = (SELECT MAX(ID) FROM Table1)",con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                Image img = Image.FromFile(dr.GetString(1).ToString());
                con.Close();
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
