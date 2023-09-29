using System;
using System.Linq;

namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    public struct AABB : IGeometry, IBox, I3D
    {
        public Point Min { get; }

        public Point Max { get; }

        public readonly double Width => Max.X - Min.X;

        public readonly double Depth => Max.Y - Min.Y;

        public readonly double Height => Max.Z - Min.Z;

        public AABB(Point min, Point max)
        {
            Min = min; Max = max;
        }

        public AABB(TriangleMesh triangleMesh)
        {
            Min = new Point(triangleMesh.Vertices.Min(p => p.X), triangleMesh.Vertices.Min(p => p.Y), triangleMesh.Vertices.Min(p => p.Z));
            Max = new Point(triangleMesh.Vertices.Max(p => p.X), triangleMesh.Vertices.Max(p => p.Y), triangleMesh.Vertices.Max(p => p.Z));

            if (Min.X > Max.X || Min.Y > Max.Y || Min.Z > Max.Z)
            {
                throw new MissingFieldException();
            }
        }

        public static bool IsIntersect(AABB box1, AABB box2) => (box1, box2) switch
        {
            var (l, r) when l.Min.X > r.Max.X => false,
            var (l, r) when l.Max.X < r.Min.X => false,
            var (l, r) when l.Min.Y > r.Max.Y => false,
            var (l, r) when l.Max.Y < r.Min.Y => false,
            var (l, r) when l.Min.Z > r.Max.Z => false,
            var (l, r) when l.Max.Z < r.Min.Z => false,
            var (_, _) => true
        };
    }
}
