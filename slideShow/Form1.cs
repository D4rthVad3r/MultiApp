using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slideShow
{
    public partial class Form1 : Form
    {
        List<Bitmap> list = new List<Bitmap>();
        private int count1 = 0;
        int temp=100;
        private int count = 0;
        private int measure=0;
        private string[] a = new string[15];

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void next()
        {
            if (count == 0)
                MessageBox.Show("No images added!");
            else 
            {
                if (count1 >= count)
                {
                    count1 = 0;
                    toolStripProgressBar1.Value = 0;
                }
                pictureBox1.Image = list[count1++];
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                measure = 100 / (count);
                toolStripProgressBar1.Value += measure;
                toolStripTextBox1.Text = "" + (count1);
            }
            
        }

        private void previous()
        {
            //if (count == 0)
            //    MessageBox.Show("No images added!");
            //else
            //{
            //    if (count1 <= 1)
            //    {
            //        count1 = count;
            //        toolStripProgressBar1.Value = 100;
            //    }
            //    pictureBox1.Image = list[count1--];
            //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //    measure = 100 / (count);
            //    temp -= measure;
            //    //if (temp < 0) { 
            //    //    toolStripProgressBar1.Value = 100;
            //    //    temp = 100;
            //    //}
            //    //else
            //    //    toolStripProgressBar1.Value = temp; ;
            //    toolStripTextBox1.Text = "" + (count1);
            //}
            if (count == 0)
                MessageBox.Show("No images added!");
            else
            {
                if (count1 <= 0)
                {
                    count1 = count ;
                    toolStripProgressBar1.Value = 100;
                }
                if(count1<1)
                {
                    count1 = count;
                }
                pictureBox1.Image = list[--count1];
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                measure = 100 / (count);
                if (toolStripProgressBar1.Value < measure)
                    toolStripProgressBar1.Value = 100;
                else
                    toolStripProgressBar1.Value -= measure;
                toolStripTextBox1.Text = "" + (count1+1);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Multiselect = true;
            f.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                //flag = 1;
                foreach (string fn in f.FileNames)
                {
                    list.Add(new Bitmap(fn));
                    a[count++] = fn;
                }
                toolStripLabel2.Text = "/ " + (count) + " ";
                //flag = 0;+9
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            next();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            next();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Next)
                next();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            previous();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            previous();
        }
    }
}
