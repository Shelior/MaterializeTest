using MaterializeTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        private List<Vertex> vertices;
        private Bitmap field;
        public Form1()
        {
            InitializeComponent();
            field = new Bitmap(mainCanvas.Width, mainCanvas.Height);
            mainCanvas.Image = field;
            vertices = new List<Vertex>();
        }

        private void mainCanvas_Click(object sender, EventArgs e)
        {
            var mouseArgs = e as MouseEventArgs;
            vertices.Add(new Vertex(mouseArgs.X, mainCanvas.Height - mouseArgs.Y));
            RedrawPolygon();
        }

        private void RedrawPolygon()
        {
            var g = mainCanvas.CreateGraphics();
            g.Clear(Color.White);

            if (vertices.Count < 2) return;

            Pen myPen = new Pen(Color.Black);
            myPen.Width = 1;
            g.DrawPolygon(myPen, vertices.Select(v => new Point((int)v.X, mainCanvas.Height - (int)v.Y)).ToArray());
        }

        private void triangulateBtn_Click(object sender, EventArgs e)
        {
            Polygon poly = new Polygon(vertices);

            var tris = poly.Triangulate();
            DrawResult(tris);
        }

        private void DrawResult(List<Triangle> tris)
        {
            var g = mainCanvas.CreateGraphics();
            g.Clear(Color.White);

            Pen myPen = new Pen(Color.Black);
            myPen.Width = 1;

            var preapredVertices = vertices.Select(v => new Point((int)v.X, mainCanvas.Height - (int)v.Y)).ToList();
            foreach (var tri in tris)
            {
                g.DrawPolygon(myPen, new Point[] { preapredVertices[tri.A], preapredVertices[tri.B], preapredVertices[tri.C] });
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            RedrawPolygon();
        }
    }
}
