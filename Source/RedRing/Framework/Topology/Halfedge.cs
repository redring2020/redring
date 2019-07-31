namespace RedRing.Framework.Topology
{
    /// <summary>
    /// ハーフエッジ
    /// </summary>
    public class Halfedge
    {
        /// <summary>
        /// 始点
        /// </summary>
        public Vertex SVertex { get; }

        /// <summary>
        /// 稜線を挟んで反対側のハーフエッジ
        /// </summary>
        public Halfedge Pair { get; }

        /// <summary>
        /// 次のハーフエッジ
        /// </summary>
        public Halfedge Next { get; }

        /// <summary>
        /// 前のハーフエッジ
        /// </summary>
        public Halfedge Prev { get; }

        /// <summary>
        /// このハーフエッジを含む面
        /// </summary>
        public Face Face { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sVertex">始点となる頂点</param>
        public Halfedge(Vertex sVertex)
        {
            SVertex = sVertex;
            if (sVertex == null)
            {
                SVertex.Halfedge = this;
            }
        }
    }
}
