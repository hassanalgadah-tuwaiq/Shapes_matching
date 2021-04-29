using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp2
{


    public partial class Form1 : Form
    {
        bool ismovebottom = false;
        bool ismovetop = false;
        bool ismatch = false;

        Pen pen = new Pen(Brushes.White,3);
        Pen penblue = new Pen(Color.Blue);
        Pen penred = new Pen(Color.Red);
        SolidBrush penbluefill = new SolidBrush(Color.Blue);
        SolidBrush penredfill = new SolidBrush(Color.Red);
        GraphicsPath GPbottom = new GraphicsPath();
        GraphicsPath GPtop = new GraphicsPath();


        // initial postions 
        int xbot = 150;
        int ybot = 150;
        int xtop = 350;
        int ytop = 150;
        int width = 50;
        int higth = 50;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GPbottom.Reset();
            GPtop.Reset();
            Graphics g = e.Graphics;

            RectangleF[] bottom = { new Rectangle(xbot, ybot, width, higth), new Rectangle(xbot, ybot+50, width, higth), new Rectangle(xbot+50, ybot+50, width, higth), new Rectangle(xbot+100, ybot+50, width, higth), new Rectangle(xbot+100, ybot, width, higth) };
            RectangleF[] top = { new Rectangle(xtop, ytop, width, higth), new Rectangle(xtop+50, ytop, width, higth), new Rectangle(xtop+100, ytop, width, higth), new Rectangle(xtop+50, ytop+50, width, higth) };
            GPbottom.AddRectangles(bottom);
            GPtop.AddRectangles(top);
            if (ismatch)
            {
                g.FillPath(penbluefill, GPtop);
                g.FillPath(penredfill, GPbottom);
            }
            else
            {
                g.DrawPath(penblue, GPtop);
                g.DrawPath(penred, GPbottom);
            }
        }



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismovebottom)
            {
                xbot = e.X;
                ybot = e.Y;
                Invalidate();
            }
            else if (ismovetop)
            {
                xtop = e.X;
                ytop = e.Y;
                Invalidate();
            }


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ismatch) ismatch = false;
            if (GPbottom.GetBounds().Contains(e.Location))
            {
                ismovebottom = true;
            }
            else if (GPtop.GetBounds().Contains(e.Location))
            {
                ismovetop = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ismovebottom || ismovetop)
            {
                if((ytop + 100 > ybot &&  ytop +100 < ybot+50) && (xtop+50 >= xbot+40 && xtop+100 <=xbot+120))
                {
                    ytop = ybot - 50;
                    xtop = xbot ;
                    ismatch = true;
                }
                Invalidate();
            }

            ismovetop = false;
            ismovebottom = false;
        }


    }
}
