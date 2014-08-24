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
    public class StlAsciiのテスト : AssertionHelper
    {
        [Test]
        public async Task Loadは適切なファイルの読み込み時にポリゴンを返す()
        {
            Expect(await StlAscii.LoadAsync(@"..\..\..\..\..\SampleData\StlAscii\cube-ascii.stl"), Is.Not.Null);
        }
    }
}
