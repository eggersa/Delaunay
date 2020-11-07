using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Delaunay
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void PicDrawing_Paint(object sender, PaintEventArgs e)
        {
            // Create some random points within a bounded area
            //
            var bounds = new Rectangle((Width - 200) / 2, (Height - 100) / 2, 200, 100);
            var rnd = new Random();
            var vertices = new List<Point>();
            
            for (int i = 0; i < 20; i++)
            {
                var p = new Point(rnd.Next(bounds.Width), rnd.Next(bounds.Height));
                vertices.Add(p);
            }

            var delaunay = new Delaunay(vertices);
            
            // Configure the graphics contexte
            //
            var g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            g.TranslateTransform(bounds.X, bounds.Y);

            // Begin to measure time
            var sw = new Stopwatch();
            sw.Start();
            
            // Draw the delaunay triangulation
            delaunay.Draw(g);
            
            // End measure time
            sw.Stop();
            lblFrameTime.Text = $"Delaunay took {sw.ElapsedMilliseconds} ms";
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.Space)
            {
                picDrawing.Invalidate();
            }
        }
    }
}
