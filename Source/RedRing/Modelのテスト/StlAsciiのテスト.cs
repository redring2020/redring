using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Marimo.RedRing.Model.Test
{
    [TestFixture]
    public class StlAsciiのテスト : AssertionHelper
    {
        [Test]
        public void Loadは適切なファイルの読み込み時にtrueを返す()
        {
            TriangleFacets triangleFaces;
            Expect(IO.StlAscii.Load(@"..\..\..\..\..\SampleData\StlAscii\cube-ascii.stl", out triangleFaces));
        }
    }
}
