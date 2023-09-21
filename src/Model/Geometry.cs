using System;
using System.Collections.Generic;

namespace RedRing.Model
{
    public class Geometry
    {
        public IEnumerable<Vector> Positions { get;private set; }

        public IEnumerable<Tuple<int, int, int>> TriangleIndices { get;private set; }

        public IEnumerable<Vector> Normals { get;private set; }

        public Geometry(IEnumerable<Vector> positions, IEnumerable<Tuple<int, int, int>> triangleIndices)
            :this(positions, triangleIndices, new Vector[] { })
        {
            Positions = positions;
            TriangleIndices = triangleIndices;
        }

        public Geometry(IEnumerable<Vector> positions, IEnumerable<Tuple<int, int, int>> triangleIndices, IEnumerable<Vector> normals)
        {
            Positions = positions;
            TriangleIndices = triangleIndices;
            Normals = normals;
        }
    }
}
