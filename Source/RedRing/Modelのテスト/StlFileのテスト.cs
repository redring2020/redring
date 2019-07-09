using System;
using System.Linq;
using System.Threading.Tasks;
using RedRing.Model.IO;
using NUnit.Framework;

namespace RedRing.Model.Test
{
    [TestFixture]
    public class StlFileのテスト : AssertionHelper
    {
        [Test]
        public async Task LoadAsyncはアスキーSTLのポリゴンを読み込むことができる()
        {
            var singleFacet = await StlFile.LoadAsync(@"..\..\TestData\StlAscii\singleFacet-ascii.stl");

            Expect(singleFacet.Geometry.TriangleIndices, Is.EquivalentTo(new[] { Tuple.Create(0, 1, 2) }));

            Expect(singleFacet.Geometry.Positions.ElementAt(0).X, Is.EqualTo(0.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(0).Y, Is.EqualTo(0.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(0).Z, Is.EqualTo(10.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(1).X, Is.EqualTo(10.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(1).Y, Is.EqualTo(0.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(1).Z, Is.EqualTo(10.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(2).X, Is.EqualTo(0.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(2).Y, Is.EqualTo(10.0));
            Expect(singleFacet.Geometry.Positions.ElementAt(2).Z, Is.EqualTo(10.0));

        }

        [Test]
        public async Task LoadAsyncはバイナリSTLの適切なファイルの読み込み時にポリゴンを返す()
        {
            Expect(await StlFile.LoadAsync(@"..\..\TestData\StlBinary\cube-binary.stl"), Is.Not.Null);
        }
    }
}
