using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRing.Framework.Model.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 円環面
    /// </summary>
    public struct Torus : IGeometry, ISurface, I3D
    {
        /// <summary>
        /// 配置位置
        /// </summary>
        public Axis Position { get; }

        /// <summary>
        /// 配置位置から円環中心の半径
        /// </summary>
        public double MajorRadius { get; }

        /// <summary>
        /// 円環の半径
        /// </summary>
        public double MinorRadius { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置位置</param>
        /// <param name="majorRadius">配置位置から円環中心の半径</param>
        /// <param name="minorRadius">円環の半径</param>
        public Torus(Axis position, double majorRadius, double minorRadius)
        {
            Position = position;
            MajorRadius = majorRadius;
            MinorRadius = minorRadius;
        }
    }
}
