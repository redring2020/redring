using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.RedRing.Model
{
    /// <summary>
    /// 三角形ポリゴンの形状を現すクラス
    /// </summary>
    public class TriangleFacetsGeometry : GeometryBase
    {
        /// <summary>
        /// 三角形の頂点
        /// </summary>
        public IEnumerable<ベクトル> Vertices { get; private set; }

        /// <summary>
        /// 三角形の頂点インデックス
        /// </summary>
        public IEnumerable<Tuple<int, int, int>> VertexIndices { get; private set; }

        /// <summary>
        /// 三角形の頂点法線ベクトル
        /// </summary>
        public IEnumerable<ベクトル> VertexNormals { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点のインデックス</param>
        public TriangleFacetsGeometry(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices)
        {
            Vertices = vertices;
            VertexIndices = vertexIndices;
            VertexNormals = null;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点のインデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleFacetsGeometry(IEnumerable<ベクトル> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<ベクトル> vertexNormals)
        {
            Vertices = vertices;
            VertexIndices = vertexIndices;
            VertexNormals = vertexNormals;
        }
    }
}
