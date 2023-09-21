using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Model
{
    public class TriangleMesh : ObservableObject, I3DModel
    {
        Geometry originalGeometry;

        Geometry geometry;

        public Vector point { get; private  set; }
        public Geometry Geometry
        {
            get
            {
                if (geometry == null)
                {
                    geometry = new Geometry(
                    from newGeometory in originalGeometry.Positions
                    select point + newGeometory,
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
        public TriangleMesh(IEnumerable<Framework.Geometry.Double.Geometry3D.Point> Vertices, IEnumerable<Tuple<int, int, int>> VertexIndices)
        {
            IEnumerable<Vector> vertices = new Vector[] { };
            if (Vertices.Any())
            {
                vertices = Vertices.Select(_ => new Vector(_.X, _.Y, _.Z));
            }

            originalGeometry = new Geometry(vertices, VertexIndices, new Vector[] { });
            point = new Vector(0, 0, 0);
            point.PropertyChanged +=
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
        public TriangleMesh(IEnumerable<Framework.Geometry.Double.Geometry3D.Point> Vertices, IEnumerable<Tuple<int, int, int>> VertexIndices, IEnumerable<Framework.Geometry.Double.Geometry3D.Vector> VertexNormals)
        {
            IEnumerable<Vector> vertices = new Vector[] { };
            if (Vertices.Any())
            {
                vertices = Vertices.Select(_ => new Vector(_.X, _.Y, _.Z));
            }

            IEnumerable<Vector> vertexNormals = new Vector[] { };
            if (VertexNormals.Any())
            {
                vertexNormals = VertexNormals.Select(_ => new Vector(_.X, _.Y, _.Z));
            }

            originalGeometry = new Geometry(vertices, VertexIndices, vertexNormals);
            point = new Vector(0, 0, 0);
            point.PropertyChanged +=
                (sender, e) =>
                {
                    geometry = null;
                };
        }
    }
}
