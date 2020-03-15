using System;
using System.Linq;

namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 折れ線
    /// </summary>
    public struct Polyline : IGeometry, ICurve, I3D
    {
        /// <summary>
        /// 通過点
        /// </summary>
        public Point[] Points { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="points">通過点</param>
        public Polyline(Point[] points)
        {
            if (points.Count() < 2)
            {
                throw new ArgumentOutOfRangeException("2点以上必要です。");
            }

            Points = points;
        }
    }
}
