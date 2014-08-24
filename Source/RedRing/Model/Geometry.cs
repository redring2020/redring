using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.RedRing.Model
{
    public class Geometry
    {

        public Geometry(IEnumerable<ベクトル> positions, IEnumerable<Tuple<int, int, int>> triangleIndices)
        {
            Positions = positions;
            TriangleIndices = triangleIndices;
        }

        public IEnumerable<ベクトル> Positions { get;private set; }

        public IEnumerable<Tuple<int, int, int>> TriangleIndices { get;private set; }
    }
}
