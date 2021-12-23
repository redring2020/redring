using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRing.Framework.Geometry.Double.Geometry3D
{
    /// <summary>
    /// 三角形メッシュ
    /// </summary>
    public class TriangleMesh : IGeometry, ISurface, I3D
    {
        /// <summary>
        /// 頂点群
        /// </summary>
        public IEnumerable<Point> Vertices { get; set; }

        /// <summary>
        /// 頂点インデックス
        /// </summary>
        public IEnumerable<Tuple<int, int, int>> VertexIndices { get; set; }

        /// <summary>
        /// 頂点の法線方向
        /// </summary>
        public IEnumerable<Vector> VertexNormals { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点インデックス</param>
        /// <param name="vertexNormals">頂点の法線方向</param>
        public TriangleMesh(IEnumerable<Point> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices, IEnumerable<Vector> vertexNormals)
        {
            Vertices = vertices;
            VertexIndices = vertexIndices;
            VertexNormals = vertexNormals;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vertices">頂点群</param>
        /// <param name="vertexIndices">頂点の法線方向</param>
        public TriangleMesh(IEnumerable<Point> vertices, IEnumerable<Tuple<int, int, int>> vertexIndices)
        {
            Vertices = vertices;
            VertexIndices = vertexIndices;
            VertexNormals = Enumerable.Repeat(new Vector(), vertexIndices.Count());
        }
    }
}
