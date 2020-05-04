using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Model
{
    public class TriangleMesh : ObservableObject, I3DModel
    {
        Geometry originalGeometry;

        Geometry geometry;

        public ベクトル 位置 { get; private  set; }
        public Geometry Geometry
        {
            get
            {
                if (geometry == null)
                {
                    geometry = new Geometry(
                    from newGeometory in originalGeometry.Positions
                    select 位置 + newGeometory,
                    originalGeometry.TriangleIndices);
                }
                return geometry;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertexes">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        public TriangleMesh(IEnumerable<Point> vertexes, IEnumerable<Tuple<int, int, int>> vertexIndices)
        {
            IEnumerable<ベクトル> 頂点群 = new ベクトル[] { };
            if (vertexes.Any())
            {
                頂点群 = vertexes.Select(_ => new ベクトル(_.X, _.Y, _.Z));
            }

            originalGeometry = new Geometry(頂点群, vertexIndices, new ベクトル[] { });
            位置 = new ベクトル(0, 0, 0);
            位置.PropertyChanged +=
                (sender, e) =>
                {
                    geometry = null;
                };
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertexes">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleMesh(IEnumerable<Point> vertexes, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<Vector> vertexNormals)
        {
            IEnumerable<ベクトル> 頂点群 = new ベクトル[] { };
            if (vertexes.Any())
            {
                頂点群 = vertexes.Select(_ => new ベクトル(_.X, _.Y, _.Z));
            }

            IEnumerable<ベクトル> 頂点法線方向群 = new ベクトル[] { };
            if (vertexNormals.Any())
            {
                頂点法線方向群 = vertexNormals.Select(_ => new ベクトル(_.X, _.Y, _.Z));
            }

            originalGeometry = new Geometry(頂点群, vertexIndices, 頂点法線方向群);
            位置 = new ベクトル(0, 0, 0);
            位置.PropertyChanged +=
                (sender, e) =>
                {
                    geometry = null;
                };
        }
    }
}
