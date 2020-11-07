using System.Drawing;

namespace Delaunay
{
    public class Triangle
    {
        public Edge A { get; set; }

        public Edge B { get; set; }

        public Edge C { get; set; }

        public Triangle()
        {
        }

        public Triangle(Edge a, Edge b, Edge c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void Draw(Graphics g)
        {
            A.Draw(g);
            B.Draw(g);
            C.Draw(g);
        }
    }
}
