namespace RedRing.Framework.Model.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 平面
    /// </summary>
    public struct Plane : IGeometry, ISurface, I3D
    {
        /// <summary>
        /// 配置位置
        /// </summary>
        public Axis Position { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置位置</param>
        public Plane(Axis position)
        {
            Position = position;
        }
    }
}