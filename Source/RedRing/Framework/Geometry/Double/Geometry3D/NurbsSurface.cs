namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// NURBS曲面
    /// </summary>
    public struct NurbsSurface
    {
        /// <summary>
        /// U方向次数
        /// </summary>
        public int UDegree { get; }

        /// <summary>
        /// V方向次数
        /// </summary>
        public int VDegree { get; }

        /// <summary>
        /// 制御点
        /// </summary>
        public double[] ControlPoints { get; }

        /// <summary>
        /// U方向縮退
        /// </summary>
        public bool UClosed { get; }

        /// <summary>
        /// V方向縮退
        /// </summary>
        public bool VClosed { get; }

        /// <summary>
        /// U方向ノット多重度
        /// </summary>
        public double[] UMultiplicities { get; }

        /// <summary>
        /// V方向ノット多重度
        /// </summary>
        public double[] VMultiplicities { get; }

        /// <summary>
        /// U方向ノット列
        /// </summary>
        public double[] UKnots { get; }

        /// <summary>
        /// V方向ノット列
        /// </summary>
        public double[] VKnots { get; }

        /// <summary>
        /// ウェイト
        /// </summary>
        public double[] Weights { get; }
    }
}
