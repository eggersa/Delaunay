using System.Collections.Generic;
using System.Drawing;

namespace Delaunay
{
    public class Edge
    {
        private readonly IList<Point> vertices;

        public int Index1 { get; set; }

        public int Index2 { get; set; }

        public Edge(IList<Point> vertices)
        {
            this.vertices = vertices;
        }

        public Edge(IList<Point> vertices, int index1, int index2) 
            : this(vertices)
        {
            Index1 = index1;
            Index2 = index2;
        }

        public Point GetPoint1()
        {
            return vertices[Index1];
        }

        public Point GetPoint2()
        {
            return vertices[Index2];
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(Pens.Black, GetPoint1(), GetPoint2());
        }
    }
}
