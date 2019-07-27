namespace RedRing.Framework.Model.Geometry.Double._3D
{
    /// <summary>
    /// 円
    /// </summary>
    public struct Circle : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 中心, 平面法線, t = 0への方向
        /// </summary>
        public Axis2 BasisSet { get; }

        /// <summary>
        /// 半径
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="basisSet">配置座標</param>
        /// <param name="radius">半径</param>
        public Circle(Axis2 basisSet, double radius)
        {
            BasisSet = basisSet;
            Radius = radius;
        }
    }
}
