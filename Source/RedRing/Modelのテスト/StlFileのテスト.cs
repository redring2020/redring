using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marimo.RedRing.Model.IO;
using NUnit.Framework;

namespace Marimo.RedRing.Model.Test
{
    [TestFixture]
    public class StlFileのテスト : AssertionHelper
    {
        [Test]
        public async Task LoadAsciiAsyncは適切なファイルの読み込み時にポリゴンを返す()
        {
            Expect(await StlFile.LoadAsciiAsync(@"..\..\..\..\..\SampleData\StlAscii\cube-ascii.stl"), Is.Not.Null);

            Expect(await StlFile.LoadAsciiAsync(@"..\..\..\..\..\SampleData\StlAscii\singleFacet-ascii.stl"), Is.Not.Null);
        }

        [Test]
        public async Task LoadBinaryAsyncは適切なファイルの読み込み時にポリゴンを返す()
        {
            Expect(await StlFile.LoadBinaryAsync(@"..\..\..\..\..\SampleData\StlBinary\cube-binary.stl"), Is.Not.Null);
        }
    }
}
