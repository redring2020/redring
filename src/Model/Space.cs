using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Model
{
    public class Space
    {
        public ObservableCollection<I3DModel> DisplayModel { get; private set; }
        public Camera Camera { get;private set; }

        public Space()
        {
            DisplayModel = new ObservableCollection<I3DModel>();
            Camera = new Camera();
        }

        public void AddModel(I3DModel model)
        {
            DisplayModel.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh> GetTriangleMeshes()
        {
            IEnumerable<RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh> triangleMeshes = new RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh[] { };
            foreach (TriangleMesh model in DisplayModel)
            {
                IEnumerable<Framework.Geometry.Double.Geometry3D.Point> vertexes = new Framework.Geometry.Double.Geometry3D.Point[] { };
                if (model.Geometry.Positions.Any())
                {
                    vertexes = model.Geometry.Positions.Select(_ => new Framework.Geometry.Double.Geometry3D.Point(_.X, _.Y, _.Z));
                }

                triangleMeshes = triangleMeshes.Append(new RedRing.Framework.Geometry.Double.Geometry3D.TriangleMesh(vertexes, model.Geometry.TriangleIndices)).ToList();
            }

            return triangleMeshes;
        }
    }
}
