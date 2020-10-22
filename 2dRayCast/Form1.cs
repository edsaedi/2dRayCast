using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dRayCast
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap canvas;
        Random rand = new Random(26);
        List<Line> barriers = new List<Line>();

        //Finds the mouse coordinates relative to the picturebox.
        Point mouse => pictureBox1.PointToClient(Cursor.Position);

        public Form1()
        {
            InitializeComponent();
        }

        //This is the drawline function.
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            gfx.DrawLine(Pens.White, x1, y1, x2, y2);

        }

        public void DrawLine(Line line)
        {
            gfx.DrawLine(Pens.White, line.x1, line.y1, line.x2, line.y2);
        }

        public void BarrierCreator(int barrierCount)
        {
            for (int i = 0; i < barrierCount; i++)
            {
                int x1 = rand.Next(0, canvas.Width);
                int x2 = rand.Next(0, canvas.Width);
                int y1 = rand.Next(0, canvas.Height);
                int y2 = rand.Next(0, canvas.Height);

                Line line = new Line(x1, x2, y1, y2);
                DrawLine(line);
                barriers.Add(line);
                //Draw all of my lines
                //Make sure that you have all the information
            }
        }

        //Put all the loaded graphics here, (i.e.) put the barriers here.
        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            gfx = Graphics.FromImage(canvas);

        }

        //This is the logic created for the lamp drawing.
        public void Lamp(Point mouse, int angleDifference)
        {
            for (int i = 0; i < 2 * Math.PI; i += angleDifference)
            {
                //I need to find a way to draw all of the different lines.
                // On top of that I need to find a way to determine its final coordinates.
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.Black);

            BarrierCreator(5);

            pictureBox1.Image = canvas;

        }
    }
}
