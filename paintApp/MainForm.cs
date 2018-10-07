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
    public partial class MainForm : Form
    {
        int font;
        Font b = new Font("DEATH CROW", 72, FontStyle.Bold);
        Font a = new Font("THOR Ragnarok", 48, FontStyle.Regular);
        Font c = new Font("HACKED", 72, FontStyle.Regular);
    public MainForm()
        {
            InitializeComponent();
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 y = new Form1();
            y.Show();
            y.MdiParent = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            label1.Font = new Font("THOR Ragnarok", 48, FontStyle.Regular);
            font = 1;
        }

        private void recentPicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show();
            x.MdiParent = this;
        }

        private void delete()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\RamVignesh\source\repos\paintApp\paintApp\DB.mdb");
            
            OleDbDataAdapter da = new OleDbDataAdapter();
//          da.DeleteCommand.Connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\RamVignesh\source\repos\paintApp\paintApp\DB.mdb");
            da.DeleteCommand = new OleDbCommand("Delete from Table1 where ID = (SELECT MAX(ID) FROM Table1)", con);
            con.Open();
            da.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }

        private void deleteRecentPicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (font == 1) { label1.Font = b; font = 2; }
                
            else if (font == 2) { label1.Font = c; font = 3; }
                
            else if (font == 3) { label1.Font = a; font = 1; }
                
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (font == 1) { label1.Font = b; font = 2; }

            else if (font == 2) { label1.Font = c; font = 3; }

            else if (font == 3) { label1.Font = a; font = 1; }
        }

        private void changeBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color co = MainForm.DefaultBackColor;
            if (BackColor == (Color.YellowGreen))
                BackColor = (Color.WhiteSmoke);
            else if (BackColor == (Color.WhiteSmoke))
                BackColor = (Color.Turquoise);
            else if (BackColor == co)
                BackColor = (Color.YellowGreen);
        }

        private void restorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = MainForm.DefaultBackColor;
            label1.Font = a; font = 1;
        }

        private void slideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            slideShow.Form1 obj = new slideShow.Form1();
            obj.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showHideWatermarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(label1.Text.Equals("RamvigneSh"))
                label1.Text = "";
            else if (label1.Text.Equals(""))
                label1.Text = "RamvigneSh";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile.Form1 fo = new profile.Form1();
            fo.Show();
            fo.MdiParent = this;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile.Form3 _3 = new profile.Form3();
            _3.Show();
        }
    }
}
