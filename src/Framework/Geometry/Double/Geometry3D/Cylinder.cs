namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 円柱
    /// </summary>
    public struct Cylinder : IGeometry, ISurface, I3D
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
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置point</param>
        /// <param name="radius">半径</param>
        public Cylinder(Axis position, double radius)
        {
            Position = position;
            Radius = radius;
        }
    }
}
