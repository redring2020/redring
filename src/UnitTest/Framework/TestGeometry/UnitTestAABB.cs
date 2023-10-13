using RedRing.Framework.IO;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.UnitTest.Framework.TestGeometry
{
    [TestClass]
    public class UnitTestAABB : AssertFailedException
    {
        [TestMethod]
        public void TestAABB()
        {
            var cubeFacet = STLFile.LoadAsync(@"..\..\..\..\..\TestData\STLBinary\cube-Binary.stl");
            Assert.IsNotNull(cubeFacet);

            var cubeAABB = new AABB(cubeFacet.Result);
            Assert.AreEqual(cubeAABB.Min.X, 0.0);
            Assert.AreEqual(cubeAABB.Min.Y, 0.0);
            Assert.AreEqual(cubeAABB.Min.Z, 0.0);
            Assert.AreEqual(cubeAABB.Max.X, 10.0);
            Assert.AreEqual(cubeAABB.Max.Y, 10.0);
            Assert.AreEqual(cubeAABB.Max.Z, 10.0);
        }
    }
}