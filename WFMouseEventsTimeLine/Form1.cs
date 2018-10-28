using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;


namespace WFMouseEventsTimeLine
{


    public partial class Form1 : Form
    {
        bool bVisualize = false;
        List<Point> points;
        int iCounter = 0; 


        public Form1()
        {
            InitializeComponent();
            points = new List<Point>();
           
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.ToString() == "q")
            {
                if (bVisualize)
                {
                    bVisualize = false;
                    iCounter = 0;

                }
                else
                {
                    bVisualize = true;
                    dataGridView1.DataSource = null;
                    points.Clear();
                }
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(bVisualize)
            {
                Point point=new Point();
                  
                point .Id = iCounter; iCounter++;
                point.dtTime = DateTime.Now.Millisecond;
                point.X = (int) e.X;
                point.Y = (int) e.Y;

                points.Add(point);

                textBox1.Text = point.Id.ToString()+" "+point.dtTime.ToString()+" "+ point.X.ToString()+" "+point.Y.ToString();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = points;
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"c:\Temp\MyTest.txt";

            var serializer = new XmlSerializer(typeof(List<Point>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, points);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
              dataGridView1.DataSource = points;   
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

    public struct Point
    {
        public int Id {get; set;}
        public int dtTime { get; set;}
        public int X { get; set; }
        public int Y { get; set; }
    }
}
                        