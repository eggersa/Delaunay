using System.Drawing;

namespace Delaunay
{
    public class Triangle
    {
        public IndexedEdge A { get; set; }

        public IndexedEdge B { get; set; }

        public IndexedEdge C { get; set; }

        public Triangle()
        {
        }

        public Triangle(IndexedEdge a, IndexedEdge b, IndexedEdge c)
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
