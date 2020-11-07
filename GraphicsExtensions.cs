using System.Drawing;

namespace Delaunay
{
    public static class GraphicsExtensions
    {
        /// <summary>
        /// Draws a dot centered around the specified location.
        /// </summary>
        /// <param name="g">The graphics context.</param>
        /// <param name="brush">The brush used to fill the dot.</param>
        /// <param name="location">The location that specifies where to draw the dot.</param>
        /// <param name="size">The diameter of the dot.</param>
        public static void FillDot(this Graphics g, Brush brush, Point location, int size = 5)
        {
            var r = size / 2;
            g.FillEllipse(brush, new Rectangle(location.X - r, location.Y - r, size, size));
        }
    }
}
