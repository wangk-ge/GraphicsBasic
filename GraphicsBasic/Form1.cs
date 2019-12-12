﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsBasic
{
    public partial class Form1 : Form
    {
        // define the drawing area
        private Rectangle PlotArea;
        //unit defined in world coordinate system
        private float xMin = 0f;
        private float xMax = 20f;
        private float yMin = 0f;
        private float yMax = 20f;

        //define the offset in pixel
        private int offset = 30;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // calculate the location and size of the drawing area
            // within witch we want to draw the graphics:
            Rectangle rect = ClientRectangle;
            PlotArea = new Rectangle(rect.Location, rect.Size);
            PlotArea.Inflate(-offset, -offset);
            // draw ClientRectangle and PlotArea using Pen:
            g.DrawRectangle(Pens.Red, rect);
            g.DrawRectangle(Pens.Black, PlotArea);
            // draw a line from point (3,2) to point (6,7)
            // using a Pen with a width of 3 pixels:
            Pen aPen = new Pen(Color.Green, 3);
            g.DrawLine(aPen, Point2D(new PointF(3, 2)), Point2D(new PointF(6, 7)));
            aPen.Dispose();
            g.Dispose();
        }

        private PointF Point2D(PointF ptf)
        {
            PointF aPoint = new PointF();
            aPoint.X = PlotArea.X + (ptf.X - xMin) *
                PlotArea.Width / (xMax - xMin);
            aPoint.Y = PlotArea.Bottom - (ptf.Y - yMin) *
                PlotArea.Height / (yMax - yMin);
            return aPoint;
        }
    }
}
