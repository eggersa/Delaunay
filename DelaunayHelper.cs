using System.Drawing;

namespace Delaunay
{
    public static class DelaunayHelper
    {
        /// <summary>
        /// Checks if the point d is inside the circle defined by the three points a, b and c.
        /// </summary>
        /// <param name="a">The point a on the circle.</param>
        /// <param name="b">The point b on the circle.</param>
        /// <param name="c">The point c on the circle.</param>
        /// <param name="d">The point to check.</param>
        /// <returns>True if the point is inside the circle; otherwise false.</returns>
        /// <remarks>https://math.stackexchange.com/questions/1579756/check-if-a-point-lies-in-a-circle-defined-by-three-other-points</remarks>
        public static bool InCircle(Point a, Point b, Point c, Point d)
        {
            // Ensure points are in ccw order
            OrderCCW(ref a, ref b, ref c);

            // https://stackoverflow.com/questions/39984709/how-can-i-check-wether-a-point-is-inside-the-circumcircle-of-3-points
            int ax_ = a.X - d.X;
            int ay_ = a.Y - d.Y;
            int bx_ = b.X - d.X;
            int by_ = b.Y - d.Y;
            int cx_ = c.X - d.Y;
            int cy_ = c.Y - d.Y;

            return (
                (ax_ * ax_ + ay_ * ay_) * (bx_ * cy_ - cx_ * by_) -
                (bx_ * bx_ + by_ * by_) * (ax_ * cy_ - cx_ * ay_) +
                (cx_ * cx_ + cy_ * cy_) * (ax_ * by_ - bx_ * ay_)
            ) > 0;
        }

        /// <summary>
        /// Orders the given points in counter-clockwise order.
        /// </summary>
        /// <param name="a">A reference to point a.</param>
        /// <param name="b">A reference to point b.</param>
        /// <param name="c">A reference to point c.</param>
        public static void OrderCCW(ref Point a, ref Point b, ref Point c)
        {
            // Order points by x descending e.g. a will be the right most point.
            if (a.X < b.X) Swap(ref a, ref b);
            if (a.X < c.X) Swap(ref b, ref c);
            if (b.X < c.X) Swap(ref b, ref c);

            // Checks if sin b-a-c is positiv or negativ using the perp product of ac and ab.
            // Might have been simpler by comparing slopes, but seems that divison is much more expensive than multiplication.
            if ((b.X - a.X) * (a.Y - c.Y) + (b.Y - a.Y) * (c.X - a.X) < 0) Swap(ref b, ref c);
        }

        /// <summary>
        /// Swaps the two given points.
        /// </summary>
        /// <param name="a">Point a.</param>
        /// <param name="b">Point b.</param>
        public static void Swap(ref Point a, ref Point b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        // returns 1 if b is right of a, 0 if points are colinear and -1 if b is left of a
        public static int Orientation(Point a, Point b, Point r)
        {
            // https://mathworld.wolfram.com/PerpDotProduct.html

            // ra = a - r = a.x - r.x; a.y - r.y
            // rb = b - r = b.x - r.x; b.y - r.y
            // perp = r.y - a.y; a.x - r.x
            // perp . rb = (r.y - a.y) * (b.x - r.x) + (a.x - r.x) * (b.y - r.y)

            var result = (r.Y - a.Y) * (b.X - r.X) +
                         (a.X - r.X) * (b.Y - r.Y);

            return result < 0 ? -1 : (result == 0 ? 0 : 1);
        }

        public static Point Intersection(Point l1, Point l2, Point l3, Point l4)
        {
            // https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
            return new Point(
                ((l1.X * l2.Y - l1.Y * l2.X) * (l3.X - l4.X) - (l1.X - l2.X) * (l3.X * l4.Y - l3.Y * l4.X)) /
                ((l1.X - l2.X) * (l3.Y - l4.Y) - (l1.Y - l2.Y) * (l3.X - l4.X)),
                ((l1.X * l2.Y - l1.Y * l2.X) * (l3.Y - l4.Y) - (l1.Y - l2.Y) * (l3.X * l4.Y - l3.Y * l4.X)) /
                ((l1.X - l2.X) * (l3.Y - l4.Y) - (l1.Y - l2.Y) * (l3.X - l4.X))
            );
        }
    }
}
