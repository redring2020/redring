namespace RedRing.Framework.Model.Geometry.Double._3D
{
    public enum NurbsCurveForm
    {
        /// <summary>
        /// カーブの形状が計算されていない。
        /// </summary>
        Unset,
        /// <summary>
        /// カーブの形状が特別ではない。
        /// </summary>
        Arbitrary,
        /// <summary>
        /// カーブが区分線形ではない。
        /// </summary>
        Polyline,
        /// <summary>
        /// カーブが円弧に一致しない。
        /// </summary>
        Circular,
        /// <summary>
        /// カーブが楕円弧に一致しない。
        /// </summary>
        Elliptic,
        /// <summary>
        /// カーブが放物線弧に一致しない。
        /// </summary>
        Parabolic,
        /// <summary>
        /// カーブが双曲線弧に一致しない。
        /// </summary>
        Hyperbolic,
    }

    /// <summary>
    /// NURBS曲線
    /// </summary>
    public struct NurbsCurve : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 次数 = 階数 - 1
        /// </summary>
        public int Degree { get; }

        /// <summary>
        /// 頂点の数
        /// </summary>
        public int VertexNum { get; }

        /// <summary>
        /// 各頂点の次元
        /// </summary>
        public int VertexDim { get; }

        /// <summary>
        /// 有理であるか
        /// </summary>
        public bool IsRational { get; }

        /// <summary>
        /// 頂点
        /// </summary>
        public double[] Vertex { get; }

        /// <summary>
        /// 曲線の形状
        /// </summary>
        public NurbsCurveForm Form { get; }

        /// <summary>
        /// 重複しないノット値の数
        /// </summary>
        public int KnotsNum { get; }

        /// <summary>
        /// 各ノットの多重度
        /// </summary>
        public int[] KnotMult { get; }

        /// <summary>
        /// 重複しないノットの数
        /// </summary>
        public double[] Knot { get; }
    }
}
