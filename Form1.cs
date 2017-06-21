using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDT
{
    public partial class Form1 : Form
    {
        int dangchon;
        int[] dachon;
        int[] length;
        int[] truoc;
        Image image;
        int n;
        Color red = new Color();
        Point[] A = new Point[9];
        int[,] matrix;
        String path;
        public Form1()
        {
            InitializeComponent();
            red = Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            ButtonTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("OK CLear");
            pictureBox1.Image = null;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "O:\\DOTHI\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string fileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                n = int.Parse(textBox1.Lines.Length.ToString());
                //   m = int.Parse(textBox1.Lines.Length.ToString());
                matrix = new int[n, n];
                inputMatrixFromFile();
                if (checkMatrixAv())
                {
                    label4.ForeColor = Color.BlueViolet;
                    label5.ForeColor = Color.BlueViolet;
                    label5.Text = "✓";
                    label4.Text = "✓";

                    if (checkMatrix2())
                    {
                        label1.Text = "Đồ thị vô hướng";

                    }
                    else
                    {
                        label1.Text = "Đồ thị có hướng";
                    }

                    DrawGraph();
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label5.Text = "✕";
                    label4.Text = "✕";
                    MessageBox.Show("Ma trận Sai!!!!"); label1.Text = "Đồ thị sai"; Graphics g = pictureBox1.CreateGraphics(); g.Clear(Color.Teal);
                }
                numericUpDown1.Value = 0;
                path = openFileDialog1.FileName;


            }















            //   -----------------
            //string t2 = "";
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        t2 += matrix[i, j].ToString() + " ";
            //    }
            //    t2 += Environment.NewLine;
            //}
            //textBox2.Text = t2;
            //    ----------------------






        }


        bool checkMatrix2()
        {
            if (checkMatrixAv())
            {
                int dem = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] == matrix[j, i]) dem++;
                        Console.WriteLine("[" + i + "," + j + "]: " + matrix[i, j] + "  --[" + j + "," + i + "]: " + matrix[j, i]);
                        Console.WriteLine("DEM: " + dem);
                    }


                }
                if (dem == (n * n))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        bool checkMatrixAv()
        {
            int dem = 0;
            for (int i = 0; i < n; i++)
            {

                if (matrix[i, i] == 0) dem++;

            }
            if (dem == n)
                return true;
            else
                return false;
        }
        void inputMatrixFromFile()
        {
            for (int i = 0; i < n; i++)
            {

                string a = removeCharInString(textBox1.Lines[i], ' ');
                for (int j = 0; j < a.Length; j++)
                {

                    matrix[i, j] = int.Parse(a[j].ToString());
                }
            }
        }



        string removeCharInString(string a, char x)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != x)
                {
                    s += a[i];
                }
            }
            return s;
        }
        void DrawGraph()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Teal);

            if (checkMatrix2())
            {
                // n = 9;
                switch (n)
                {
                    case 1:
                        {
                            MessageBox.Show("Lỗi đồ thị");
                        }
                        break;
                    case 2:
                        {

                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 20), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - pictureBox1.Height / 8 - 20), ref A[1]);
                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 20), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - pictureBox1.Height / 8 - 20), ref A[1]);
                        }
                        break;
                    case 3:
                        {

                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);

                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                        }
                        break;
                    case 4:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                        }
                        break;
                    case 5:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 90), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 150), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3), ref A[4]);
                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 90), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 150), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3), ref A[4]);
                        }
                        break;
                    case 6:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[5]);

                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[5]);

                        }
                        break;
                    case 7:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 + 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 120), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 180), pictureBox1.Height / 3 - 10), ref A[6]);

                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 + 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 120), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 180), pictureBox1.Height / 3 - 10), ref A[6]);


                        }
                        break;

                    case 8:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[7]);

                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[7]);



                        }
                        break;
                    case 9:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 100), pictureBox1.Height / 10 + 40), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height / 3 + 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height / 3 + 30), ref A[7]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "8", new Size(15, 15), new Point((pictureBox1.Width / 2 - 160), pictureBox1.Height / 10 + 40), ref A[8]);
                            DrawOK();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 100), pictureBox1.Height / 10 + 40), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height / 3 + 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height / 3 + 30), ref A[7]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "8", new Size(15, 15), new Point((pictureBox1.Width / 2 - 160), pictureBox1.Height / 10 + 40), ref A[8]);

                        }
                        break;
                }
            }

            else
            {
                switch (n)
                {
                    case 2:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 20), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - pictureBox1.Height / 8 - 20), ref A[1]);
                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 20), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - pictureBox1.Height / 8 - 20), ref A[1]);
                        }
                        break;


                    case 3:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                        }
                        break;



                    case 4:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                        }
                        break;

                    case 5:
                        {

                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 90), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 150), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3), ref A[4]);
                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 90), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 150), pictureBox1.Height - pictureBox1.Height / 3 + 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3), ref A[4]);
                        }
                        break;

                    case 6:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[5]);

                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[5]);

                        }
                        break;
                    case 7:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 + 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 120), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 180), pictureBox1.Height / 3 - 10), ref A[6]);

                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 + 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 120), pictureBox1.Height / 3 - 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 30), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 180), pictureBox1.Height / 3 - 10), ref A[6]);


                        }
                        break;

                    case 8:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[7]);

                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height / 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height / 10), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height / 3 - 10), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 40), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 100), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3 - 20), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height / 3 - 10), ref A[7]);



                        }
                        break;
                    case 9:
                        {
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 100), pictureBox1.Height / 10 + 40), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height / 3 + 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height / 3 + 30), ref A[7]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "8", new Size(15, 15), new Point((pictureBox1.Width / 2 - 160), pictureBox1.Height / 10 + 40), ref A[8]);
                            DrawOKCH();
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "0", new Size(15, 15), new Point((pictureBox1.Width / 2 - 30), pictureBox1.Height / 10 - 10), ref A[0]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "1", new Size(15, 15), new Point((pictureBox1.Width / 2 + 100), pictureBox1.Height / 10 + 40), ref A[1]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "2", new Size(15, 15), new Point((pictureBox1.Width / 2 + 170), pictureBox1.Height / 3 + 30), ref A[2]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "3", new Size(15, 15), new Point((pictureBox1.Width / 2 + 140), pictureBox1.Height - pictureBox1.Height / 3), ref A[3]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "4", new Size(15, 15), new Point((pictureBox1.Width / 2 + 50), pictureBox1.Height - 70), ref A[4]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "5", new Size(15, 15), new Point((pictureBox1.Width / 2 - 110), pictureBox1.Height - 70), ref A[5]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "6", new Size(15, 15), new Point((pictureBox1.Width / 2 - 200), pictureBox1.Height - pictureBox1.Height / 3), ref A[6]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "7", new Size(15, 15), new Point((pictureBox1.Width / 2 - 230), pictureBox1.Height / 3 + 30), ref A[7]);
                            DrawPoint.DrawP.Draw1Point(pictureBox1, "8", new Size(15, 15), new Point((pictureBox1.Width / 2 - 160), pictureBox1.Height / 10 + 40), ref A[8]);

                        }
                        break;
                }





            }


        }






        void DrawOK()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == matrix[j, i] && matrix[i, j] >= 1)
                    {
                        DrawPoint.DrawP.DrawLine(pictureBox1, A[i], A[j]);
                    }

                }


            }
        }
        int check = 0;
        void DrawOKCH()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {

                        DrawPoint.DrawP.DrawVector(pictureBox1, A[i], A[j], n);
                    }

                }


            }
        }
        bool f = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (f)
            {
                textBox1.ReadOnly = true;
                button1.Text = "Sửa";
                f = false;
                Console.WriteLine("Click----" + f);
                n = int.Parse(textBox1.Lines.Length.ToString());
                matrix = new int[n, n];
                inputMatrixFromFile();
                if (checkMatrixAv())
                {
                    label4.ForeColor = Color.BlueViolet;
                    label5.ForeColor = Color.BlueViolet;
                    label5.Text = "✓";
                    label4.Text = "✓";

                    if (checkMatrix2())
                    {
                        label1.Text = "Đồ thị vô hướng";

                    }
                    else
                    {
                        label1.Text = "Đồ thị có hướng";
                    }
                    DrawGraph();
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label5.Text = "✕";
                    label4.Text = "✕";
                    MessageBox.Show("Ma trận Sai!!!!"); label1.Text = "Đồ thị sai"; Graphics g = pictureBox1.CreateGraphics(); g.Clear(Color.Teal);

                }


            }

            else
            {
                textBox1.ReadOnly = false;
                button1.Text = "Lưu";
                f = true;


                //------------







            }

            numericUpDown1.Value = 0;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string s = "";
            if (radioButton1.Checked)
            {
                if (checkMatrix2())
                {
                    visited = new int[n];
                    q = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        visited[i] = 0;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        q[i] = 0;
                    }

                    bfs(int.Parse(numericUpDown1.Value.ToString()), ref s);



                }

                else
                {
                    visited = new int[n];
                    q = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        visited[i] = 0;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        q[i] = 0;
                    }
                    bfs(int.Parse(numericUpDown1.Value.ToString()), ref s);


                }

                listBox1.Items.Add("BFS[" + int.Parse(numericUpDown1.Value.ToString()) + "]: " + s.Remove(s.Length - 4, 3));
            }

            else
            {
                if (checkMatrix2())
                {
                    visited = new int[n];
                    int i, j;
                    for (i = 0; i < n; i++)
                        visited[i] = 0;

                    dfs(int.Parse(numericUpDown1.Value.ToString()));
                    if (sdfs == "")
                    {
                        listBox1.Items.Add("DFS[" + int.Parse(numericUpDown1.Value.ToString()) + "]: Không có DFS");
                    }
                    else
                    {
                        listBox1.Items.Add("DFS[" + int.Parse(numericUpDown1.Value.ToString()) + "]: " + sdfs.Remove(sdfs.Length - 3, 3));
                    }


                }

                else
                {
                    int i, j;
                    visited = new int[n];

                    for (i = 0; i < n; i++)
                        visited[i] = 0;

                    dfs(int.Parse(numericUpDown1.Value.ToString()));
                    if (sdfs == "")
                    {
                        listBox1.Items.Add("DFS[" + int.Parse(numericUpDown1.Value.ToString()) + "]: Không có DFS");
                    }
                    else
                    {
                        listBox1.Items.Add("DFS[" + int.Parse(numericUpDown1.Value.ToString()) + "]: " + sdfs.Remove(sdfs.Length - 3, 3));
                    }

                }


            }


            sdfs = "";
            front = 0;
            rear = 0;
        }


        int front = 0;
        int rear = 0;
        int[] visited, q;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > n - 1) numericUpDown1.Value = n - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        void bfs(int v, ref string s)
        {
            visited[v] = 1;
            q[rear] = v;
            rear++;
            while (rear != front)
            {
                int u = q[front];
                s += u + "-->";
                front++;
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == 0 && matrix[u, i] > 0)
                    {
                        q[rear] = i;
                        rear++;
                        visited[i] = 1;
                    }
                }
                s += "\n";


            }
        }
        string sdfs = "";

        void dfs(int i)
        {
            int j;
            sdfs += i + "-->";
            visited[i] = 1;
            for (j = 0; j < n; j++)
                if (visited[j] != 1 && matrix[i, j] == 1)
                    dfs(j);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        //Kiem tra dang chon thuat toan nao
        private void ButtonTest()
        {
            if (rad_Pr.Checked == true)
            {
                label7.Text = "Điểm bắt đầu";
                label6.Text = "Số lượng đỉnh";
            }
            else
                if (rad_dij.Checked == true)
            {
                label7.Text = "Điểm bắt đầu";
                label6.Text = "Điểm kết thúc";
            }
        }
        //Nhan nut xu lý Dijtra/ Prim
        private void button5_Click_1(object sender, EventArgs e)
        {
            int batdau = int.Parse(numericUpDown2.Value.ToString());
            int ketthuc = int.Parse(numericUpDown3.Value.ToString());
            int soluongdinh = int.Parse(numericUpDown3.Value.ToString());
            //Xu ly thuat toan Dijtra
            if (rad_dij.Checked == true)
            {
                if (batdau > 0 && ketthuc > 0 && batdau != ketthuc)
                    Dijtra(batdau, ketthuc);
                else

                    MessageBox.Show("Vui lòng nhập lại");
            }
            //Xu ly thuat toan prim
            if (rad_Pr.Checked == true)
            {
                if (int.Parse(numericUpDown3.Value.ToString()) > 0)
                    Prim(soluongdinh);
                else

                    MessageBox.Show("Vui lòng nhập số lượng đỉnh");
            }
        }

        //Xu ly Dijtra
        public void Dijtra(int start, int finish)
        {
            dachon = new int[n];
            length = new int[n];
            truoc = new int[n];

            dangchon = start;
            for (int i = 0; i < n; i++)
            {
                dachon[i] = 0;
                length[i] = Int32.MaxValue;
                truoc[i] = -1;
            }
            length[start] = 0;

            while (true)
            {
                dangchon = -1;
                int min = Int32.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (dachon[i] == 0 && length[i] < min)
                    {
                        min = length[i];
                        dangchon = i;
                    }
                }
                if (dangchon == -1)
                    break;
                dachon[dangchon] = 1;
                XuLy(dangchon);
            }
            String batdau = numericUpDown2.Value.ToString();
            String Ketthuc = numericUpDown3.Value.ToString();
            int x = finish;
            string s = x.ToString();
            while (true)
            {
                x = truoc[x];
                if (x == -1)
                    break;
                s = x.ToString() + "-->" + s;
            }
            listBox1.Items.Add("Dijkstra[" + batdau + "," + Ketthuc + "]: " + s);

        }
        public void XuLy(int dangchon)
        {
            for (int i = 0; i < n; i++)
            {
                if (dachon[i] == 0)
                {
                    if (matrix[dangchon, i] + length[dangchon] < length[i] && matrix[dangchon, i] != 0)
                    {
                        length[i] = matrix[dangchon, i] + length[dangchon];
                        truoc[i] = dangchon;
                    }
                }
            }
        }

        //Xy Ly prim
        private int MinKey(int[] key, bool[] set, int verticesCount)
        {
            int min = int.MaxValue, minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (set[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        public void Prim(int verticesCount)
        {
            int[] parent = new int[verticesCount];
            int[] key = new int[verticesCount];
            bool[] mstSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinKey(key, mstSet, verticesCount);
                mstSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (Convert.ToBoolean(matrix[u, v]) && mstSet[v] == false && matrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = matrix[u, v];
                    }
                }
            }
            Print(parent, matrix, verticesCount);
        }

        private void rad_dij_CheckedChanged(object sender, EventArgs e)
        {
            ButtonTest();
        }

        private void rad_Pr_CheckedChanged(object sender, EventArgs e)
        {
            ButtonTest();
        }

        private void Print(int[] parent, int[,] graph, int verticesCount)
        {
            String ketqua = "";
            String temp = numericUpDown3.Value.ToString();
            for (int i = 1; i < verticesCount; ++i)
            {
                ketqua += parent[i] + "-" + i + ", ";
            }
            listBox1.Items.Add("Prim[" + temp + "]= " + ketqua);
        }
    }
}
