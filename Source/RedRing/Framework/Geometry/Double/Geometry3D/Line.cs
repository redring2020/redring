namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 無限直線
    /// </summary>
    public struct Line : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 基準点
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public Vector Dir { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">基準点</param>
        /// <param name="dir">方向</param>
        public Line(Point location, Vector dir)
        {
            Location = location;
            Dir = dir;
        }
    }
}
