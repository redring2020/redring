using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Model
{
    public class 空間
    {
        public ObservableCollection<I3DModel> 表示モデル { get; private set; }
        public カメラ カメラ { get;private set; }

        public 空間()
        {
            表示モデル = new ObservableCollection<I3DModel>();
            カメラ = new カメラ();
        }

        public void モデルを追加する(I3DModel モデル)
        {
            表示モデル.Add(モデル);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh> GetTriangleMeshes()
        {
            IEnumerable<RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh> triangleMeshes = new RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh[] { };
            foreach (TriangleMesh model in 表示モデル)
            {
                IEnumerable<Point> vertexes = new Point[] { };
                if (model.Geometry.Positions.Any())
                {
                    vertexes = model.Geometry.Positions.Select(_ => new Point(_.X, _.Y, _.Z));
                }

                triangleMeshes = triangleMeshes.Append(new RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh(vertexes, model.Geometry.TriangleIndices)).ToList();
            }

            return triangleMeshes;
        }
    }
}
