using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Framework.Topology
{
    /// <summary>
    /// 頂点
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// 頂点データ
        /// </summary>
        Vector Position;

        /// <summary>
        /// X座標値
        /// </summary>
        public double X => Position.X;

        /// <summary>
        /// Y座標値
        /// </summary>
        public double Y => Position.Y;

        /// <summary>
        /// Z座標値
        /// </summary>
        public double Z => Position.Z;

        /// <summary>
        /// この頂点を始点にもつハーフエッジの１つ
        /// </summary>
        public Halfedge Halfedge { get; internal set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        public Vertex(double x, double y, double z)
        {
            Position = new Vector(x, y, z);
            Halfedge = null;
        }
    }
}
