using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Marimo.RedRing.Model.Test
{
    [TestFixture]
    public class TestStlFileIO : AssertionHelper
    {
        [Test]
        public void StlAsciiLoad1()
        {
            TriangleFacets triangleFaces;
            Expect(IO.StlAscii.Load(@"..\..\..\..\..\SampleData\StlAscii\cube-ascii.stl", out triangleFaces));
        }
    }
}
