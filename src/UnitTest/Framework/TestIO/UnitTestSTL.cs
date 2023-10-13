using RedRing.Framework.IO;

namespace RedRing.UnitTest.Framework.TestIO
{
    [TestClass]
    public class TestSTLFile : AssertFailedException
    {
        [TestMethod]
        public async Task TestLoadAsciiSTLSingleFacet()
        {
            var singleFacet = await STLFile.LoadAsync(@"..\..\..\..\..\TestData\STLAscii\singleFacet-ascii.stl");
            Assert.IsNotNull(singleFacet);

            Assert.IsNotNull(new[] { Tuple.Create(0, 1, 2) });

            Assert.AreEqual(singleFacet.Vertices.ElementAt(0).X, 0.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(0).Y, 0.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(0).Z, 10.0);

            Assert.AreEqual(singleFacet.Vertices.ElementAt(1).X, 10.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(1).Y, 0.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(1).Z, 10.0);

            Assert.AreEqual(singleFacet.Vertices.ElementAt(2).X, 0.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(2).Y, 10.0);
            Assert.AreEqual(singleFacet.Vertices.ElementAt(2).Z, 10.0);
        }

        [TestMethod]
        public async Task TestBinarySTLCube()
        {
            var cubeFacet = await STLFile.LoadAsync(@"..\..\..\..\..\TestData\STLBinary\cube-Binary.stl");
            Assert.IsNotNull(cubeFacet);
        }
    }
}