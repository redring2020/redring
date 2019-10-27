using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using RedRing.Framework.Geometry.Double.Geometry3D;
using RedRing.Model;

namespace RedRing.Model
{
    public class TriangleFaces : ObservableObject, I3DModel
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
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        public TriangleFaces(IEnumerable<Vector> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices)
        {
            IEnumerable<ベクトル> 頂点群 = new ベクトル[] { };
            foreach(var vertex in vertices)
            {
                頂点群.Append(new ベクトル(vertex.X, vertex.Y, vertex.Z));

                originalGeometry = new Geometry(頂点群, vertexIndices, new ベクトル[] { });
                位置 = new ベクトル(0, 0, 0);
                位置.PropertyChanged +=
                    (sender, e) =>
                    {
                        geometry = null;
                    };
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleFaces(IEnumerable<Vector> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<Vector> vertexNormals)
        {
            IEnumerable<ベクトル> 頂点群 = new ベクトル[] { };
            foreach(var vertex in vertices)
            {
                頂点群.Append(new ベクトル(vertex.X, vertex.Y, vertex.Z));
            }

            IEnumerable<ベクトル> 頂点法線方向群 = new ベクトル[] { };
            foreach(var vertexNormal in vertexNormals)
            {
                頂点法線方向群.Append(new ベクトル(vertexNormal.X, vertexNormal.Y, vertexNormal.Z));
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
