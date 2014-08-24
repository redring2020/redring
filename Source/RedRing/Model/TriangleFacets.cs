using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Marimo.RedRing.Model
{
    public class TriangleFacets : ObservableObject, I3DModel
    {
        Geometry geometry;

        public Geometry Geometry
        {
            get { return geometry; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        public TriangleFacets(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices)
        {
            geometry = new Geometry(vertices, vertexIndices);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleFacets(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<ベクトル> vertexNormals)
        {
            geometry = new Geometry(vertices, vertexIndices, vertexNormals);
        }
    }
}
