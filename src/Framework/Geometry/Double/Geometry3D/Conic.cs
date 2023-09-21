namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 円錐
    /// </summary>
    public struct Conic : IGeometry, ISurface, I3D
    {
        /// <summary>
        /// 配置point
        /// </summary>
        public Axis Position { get; }

        /// <summary>
        /// 半径
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// 片側の角度
        /// </summary>
        public double SemiAngle { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置point</param>
        /// <param name="radius">半径</param>
        /// <param name="semiAngle">片側の角度</param>
        public Conic(Axis position, double radius, double semiAngle)
        {
            Position = position;
            Radius = radius;
            SemiAngle = semiAngle;
        }
    }
}
