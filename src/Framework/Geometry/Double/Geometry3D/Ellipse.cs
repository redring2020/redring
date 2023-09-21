namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 楕円
    /// </summary>
    public struct Ellipse : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 配置point
        /// </summary>
        public Axis Position { get; }

        /// <summary>
        /// X軸方向半径
        /// </summary>
        public double R1 { get; }

        /// <summary>
        /// Y軸方向半径
        /// </summary>
        public double R2 { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置point</param>
        /// <param name="r1">X軸方向半径</param>
        /// <param name="r2">Y軸方向半径</param>
        public Ellipse(Axis position, double r1, double r2)
        {
            Position = position;
            R1 = r1;
            R2 = r2;
        }
    }
}
