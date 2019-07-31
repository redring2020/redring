namespace RedRing.Framework.Model.Geometry.Double.Geometry3D
{
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
        /// 制御点の数
        /// </summary>
        public int ControlPointsNum => ControlPoints.Length;

        /// <summary>
        /// 有理であるか
        /// </summary>
        public bool IsRational
        {
            get
            {
                if (Weights == null)
                {
                    return false;
                }
                else
                {
                    return Weights.Length > 0 ? true : false;
                }
            }
        }

        /// <summary>
        /// 制御点
        /// </summary>
        public double[] ControlPoints { get; }

        /// <summary>
        /// 相異なるノット値の数
        /// </summary>
        public int KnotsNum { get => Knots.Length; }

        /// <summary>
        /// 各ノットの多重度
        /// </summary>
        public int[] KnotMultiplicities { get; }

        /// <summary>
        /// 相異なるノット列
        /// </summary>
        public double[] Knots { get; }

        /// <summary>
        /// ウェイト
        /// </summary>
        public double[] Weights { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="degree">次数</param>
        /// <param name="controlPoints">制御点</param>
        /// <param name="knotMultiplicities">各ノットの多重度</param>
        /// <param name="knots">相異なるノット列</param>
        /// <param name="weights">ウェイト</param>
        public NurbsCurve(int degree, double[] controlPoints, int[] knotMultiplicities, double[] knots, double[] weights)
        {
            Degree = degree;
            ControlPoints = controlPoints;
            KnotMultiplicities = knotMultiplicities;
            Knots = knots;
            Weights = weights;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="degree">次数</param>
        /// <param name="controlPoints">制御点</param>
        /// <param name="knotMultiplicities">各ノットの多重度</param>
        /// <param name="knots">相異なるノット列</param>
        public NurbsCurve(int degree, double[] controlPoints, int[] knotMultiplicities, double[] knots)
        {
            Degree = degree;
            ControlPoints = controlPoints;
            KnotMultiplicities = knotMultiplicities;
            Knots = knots;
            Weights = null;
        }

        /// <summary>
        /// コンストラクタ（Bezier曲線）
        /// TODO：必要であればBezier構造体に移動
        /// </summary>
        /// <param name="degree">次数</param>
        /// <param name="segmentNum">セグメント数</param>
        /// <param name="controlPoints">制御点</param>
        public NurbsCurve(int degree, int segmentNum, double[] controlPoints)
        {
            Degree = degree;
            ControlPoints = controlPoints;
            int k = controlPoints.Length - 1;
            int m = (k - degree) / degree;
            int knotsNum = m + 2;
            KnotMultiplicities = new int[knotsNum];
            KnotMultiplicities[0] = degree + 1;
            for (int ii = 1; ii < m; ii++)
            {
                KnotMultiplicities[ii] = degree;
            }
            KnotMultiplicities[KnotMultiplicities.Length - 1] = degree + 1;
            Knots = new double[knotsNum];
            for (int ii = 0; ii < knotsNum; ii++)
            {
                Knots[ii] = ii;
            }
            Weights = null;
        }
    }
}
