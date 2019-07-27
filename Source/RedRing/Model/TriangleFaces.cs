using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

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
        public TriangleFaces(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices)
            : this(vertices, vertexIndices, new ベクトル[] { }) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleFaces(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<ベクトル> vertexNormals)
        {
            originalGeometry = new Geometry(vertices, vertexIndices, vertexNormals);
            位置 = new ベクトル(0, 0, 0);
            位置.PropertyChanged +=
                (sender, e) =>
                {
                    geometry = null;
                };
        }
    }
}
