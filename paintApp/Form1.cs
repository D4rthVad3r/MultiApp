using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace paintApp
{
    public partial class Form1 : Form
    {
        bool isStart = false;
        
        int flag = 1;
        public Image bitmap = new Bitmap(479,313);
        public string filename;
        private bool ispressed = new bool();
        Point p1 = new Point();
        private Color color = Color.Black;
        private int thickness = 1;
        private int thickness1 = 8;

        public Form1()
        {
            InitializeComponent();
            resetBorder();
            pictureBox8.Visible = false;
            this.Hide();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            ispressed = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            if(flag==0)
                p = new Pen(color, thickness1);
            else
                p = new Pen(color, thickness);
            if (ispressed)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    isStart = true;
                    g.DrawLine(p, p1, e.Location);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    p1 = e.Location;
                    var ew = RectangleToScreen(new Rectangle(95, 20, 600, 600));
                    Graphics.FromImage(bitmap).CopyFromScreen(ew.Location, Point.Empty, Size);
                }
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ispressed = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //IsMdiContainer = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resetBorder()
        {
            backRed.Visible = false;
            backBlack.Visible = false;
            backPink.Visible = false;
            backYellow.Visible = false;
            backBlue.Visible = false;
            backGreen.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            thickness = (int)numericUpDown1.Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Red;
            backRed.Visible = true;
            flag = 1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Blue;
            backBlue.Visible = true;
            flag = 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Yellow;
            backYellow.Visible = true;
            flag = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Green;
            backGreen.Visible = true;
            flag = 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Pink;
            backPink.Visible = true;
            flag = 1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            resetBorder();
            color = Color.Black;
            backBlack.Visible = true;
            flag = 1;

        }

        private void backRed_Click(object sender, EventArgs e)
        {
            
        }

        private void clear(PaintEventArgs g)
        {
            g.Graphics.Clear(Color.White);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form1 form = new Form1();
            form.Visible = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PA!NT Application\n© RamVignesh. B");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var opt = new System.Windows.Forms.DialogResult();
            if (isStart)
            {
                opt = MessageBox.Show("Do you want to save the changes you made?","", MessageBoxButtons.YesNoCancel);
                if (opt == DialogResult.Yes)
                {
                    saveFile();
                    this.Close();
                }
                else if (opt == DialogResult.No)
                    this.Close();
                else
                    isStart = true;
            }
            else
                this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           // Graphics g = Graphics.FromImage(bitmap);
            bitmap.Save(@"C:\Users\RamVignesh\Desktop\test.jpg");
           // Process.Start(@"C:\Users\ramvi\Desktop\test.jpg");
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public void saveFile()
        {
            //var ew = RectangleToScreen(new Rectangle(95, 20, 600, 600));
            //Graphics.FromImage(bitmap).CopyFromScreen(ew.Location, Point.Empty, Size);
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "png";
            //sf.ShowDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(sf.FileName);
               // Process.Start(sf.FileName);
                filename = sf.FileName;
                DB("save");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (color != Color.White)
            {
                flag = 0;
                color = Color.White;
            }
            else
            {
                flag = 1;
                color = Color.Black;
                backBlack.Visible = true;
            }
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            thickness1 = (int)numericUpDown2.Value;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void DB(string a)
        {
           
            if (a.Equals("save"))
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\RamVignesh\source\repos\paintApp\paintApp\DB.mdb");
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Table1 (Field2) Values('" + filename + "')", con);
               // cmd.CommandText = "insert into Table1 Values ('" + filename + "')";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //else if (a.Equals("load"))
            //{ 
            //    con.Open();
            //    OleDbCommand cmd = new OleDbCommand();
            //    cmd.CommandText = "select filePath from Table1 Values ('" + filename + "')";
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
        }

        private void loadRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

