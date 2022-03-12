using System;

namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    public struct AABB : IGeometry, IBox, I3D
    {
        public Vector Min { get; }

        public Vector Max { get; }

        public double Width => Max.X - Min.X;

        public double Depth => Max.Y - Min.Y;

        public double Height => Max.Z - Min.Z;

        public AABB(Vector min, Vector max)
        {
            Min = min; Max = max;
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
