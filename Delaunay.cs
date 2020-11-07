using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Delaunay
{
    public class Delaunay
    {
        private readonly List<Point> vertices;
        private readonly List<Triangle> triangles;
        private readonly Triangle initialTriangle;

        public Delaunay(IEnumerable<Point> vertices)
        {
            this.vertices = vertices.ToList();

            // Create initial triangle containing all vertices
            //
            // Another approach https://www.math.colostate.edu/~benoit/Java/math/delaunay/Delaunay.java
            var xMax = vertices.Max(p => p.X);
            var yMax = vertices.Max(p => p.Y);
            var yPadding = 10; // Ensure no point near or on the bottom edge

            var initialVertices = new Point[]
            {
                new Point(xMax * 2, yMax + yPadding),
                new Point(xMax / 2, -yMax),
                new Point(-xMax, yMax + yPadding)
            };

            initialTriangle.A = new Edge(initialVertices, 0, 1);
            initialTriangle.B = new Edge(initialVertices, 1, 2);
            initialTriangle.C = new Edge(initialVertices, 2, 0);
        }

        public bool Triangulate()
        {
            return false;
        }

        public void Draw(Graphics g)
        {
            initialTriangle.Draw(g);
        }
    }
}
