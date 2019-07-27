using RedRing.Framework.Model.Geometry;

namespace RedRing.Framework.Model.Geometry.Double._3D
{
    /// <summary>
    /// 1軸配置
    /// </summary>
    public struct Axis1Placement : IGeometry, IPlacement, I3D
    {
        /// <summary>
        /// 配置位置
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// 軸方向
        /// </summary>
        public Vector Axis { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置位置</param>
        /// <param name="axis">軸方向</param>
        public Axis1Placement(Point location, Vector axis)
        {
            Location = location;
            Axis = axis;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置位置</param>
        public Axis1Placement(Point location)
        {
            Location = location;
            Axis = new Vector(0.0, 0.0, 1.0);
        }
    }
}
