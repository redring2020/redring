using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 球面
    /// </summary>
    public struct Sphere : IGeometry, ISurface, I3D
    {
        /// <summary>
        /// 配置位置
        /// </summary>
        public Axis Position { get; }

        /// <summary>
        /// 半径
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">配置位置</param>
        /// <param name="radius">半径</param>
        public Sphere(Axis position, double radius)
        {
            Position = position;
            Radius = radius;
        }
    }
}
