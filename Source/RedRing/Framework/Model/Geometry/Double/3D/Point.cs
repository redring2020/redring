using RedRing.Framework.Model.Numerics.LinerAlgebra.Double;

namespace RedRing.Framework.Model.Geometry.Double._3D
{
    /// <summary>
    /// 座標点
    /// </summary>
    public struct Point : IGeometry, IPoint, I3D
    {
        /// <summary>
        /// デカルト位置
        /// </summary>
        Point3D Position;

        /// <summary>
        /// X座標値
        /// </summary>
        public double X { get { return Position.X; } }

        /// <summary>
        /// Y座標値
        /// </summary>
        public double Y { get { return Position.Y; } }

        /// <summary>
        /// Z座標値
        /// </summary>
        public double Z { get { return Position.Z; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        public Point(double x, double y, double z)
        {
            Position = new Point3D(x, y, z);
        }
    }
}
