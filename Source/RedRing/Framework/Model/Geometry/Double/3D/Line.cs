namespace RedRing.Framework.Model.Geometry.Double._3D
{
    /// <summary>
    /// 無限直線
    /// </summary>
    public struct Line : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 基準点
        /// </summary>
        public Vector Location { get; }

        /// <summary>
        /// 方向
        /// </summary>
        public Vector Dir { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="location">基準点</param>
        /// <param name="dir">方向</param>
        public Line(Vector location, Vector dir)
        {
            Location = location;
            Dir = dir;
        }
    }
}
