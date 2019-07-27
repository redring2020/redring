namespace RedRing.Framework.Model.Geometry.Double._3D
{
    /// <summary>
    /// 2軸配置
    /// </summary>
    public struct Axis2 : IGeometry, IPlacement, I3D
    {
        /// <summary>
        /// 配置位置
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// Z軸の方向
        /// </summary>
        public Vector Axis { get; }

        /// <summary>
        /// X軸の方向
        /// </summary>
        public Vector RefDirection { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置位置</param>
        /// <param name="axis">Z軸の方向</param>
        /// <param name="refDirection">X軸の方向</param>
        public Axis2(Point location, Vector axis, Vector refDirection)
        {
            Location = location;
            Axis = axis;
            RefDirection = refDirection;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置位置</param>
        public Axis2(Point location)
        {
            Location = location;
            Axis = new Vector(0.0, 0.0, 1.0);
            RefDirection = new Vector(1.0, 0.0, 0.0);
        }
    }
}
