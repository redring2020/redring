namespace RedRing.Model
{
    public class Point : Vector
    {
        public Point(double x, double y, double z)
            :base(x, y, z)
        {
        }

        public static Point operator +(Point l, Vector r)
        {
            return new Point(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
        }
    }
}
