namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 配置
    /// </summary>
    public struct Axis : IGeometry, IPlacement, I3D
    {
        /// <summary>
        /// 配置point
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// Z軸の方向
        /// </summary>
        public Vector ZAxis { get; }

        /// <summary>
        /// X軸の方向
        /// </summary>
        public Vector RefDirection { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置point</param>
        /// <param name="zAxis">Z軸の方向</param>
        /// <param name="refDirection">X軸の方向</param>
        public Axis(Point location, Vector zAxis, Vector refDirection)
        {
            Location = location;
            ZAxis = zAxis;
            RefDirection = refDirection;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">配置point</param>
        public Axis(Point location)
        {
            Location = location;
            ZAxis = new Vector(0.0, 0.0, 1.0);
            RefDirection = new Vector(1.0, 0.0, 0.0);
        }
    }
}
