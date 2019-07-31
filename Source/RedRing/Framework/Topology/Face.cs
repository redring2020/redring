namespace RedRing.Framework.Topology
{
    /// <summary>
    /// 面
    /// </summary>
    public class Face
    {
        /// <summary>
        /// ハーフエッジ
        /// </summary>
        public Halfedge Halfedge { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="halfedge">ハーフエッジ</param>
        public Face(Halfedge halfedge)
        {
            Halfedge = halfedge;
        }
    }
}
