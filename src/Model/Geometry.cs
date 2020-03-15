using System;
using System.Collections.Generic;

namespace RedRing.Model
{
    public class Geometry
    {
        public IEnumerable<ベクトル> Positions { get;private set; }

        public IEnumerable<Tuple<int, int, int>> TriangleIndices { get;private set; }

        public IEnumerable<ベクトル> Normals { get;private set; }

        public Geometry(IEnumerable<ベクトル> positions, IEnumerable<Tuple<int, int, int>> triangleIndices)
            :this(positions, triangleIndices, new ベクトル[] { })
        {
            Positions = positions;
            TriangleIndices = triangleIndices;
        }

        public Geometry(IEnumerable<ベクトル> positions, IEnumerable<Tuple<int, int, int>> triangleIndices, IEnumerable<ベクトル> normals)
        {
            Positions = positions;
            TriangleIndices = triangleIndices;
            Normals = normals;
        }
    }
}
