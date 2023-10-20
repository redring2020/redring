using static RedRing.Common.Numerics.CalculationDefine;
using RedRing.Common.Numerics;

namespace RedRing.UnitTest.Common.TestNumerics
{
    [TestClass]
    public class UnitTestNewtonRaphshon
    {
        [TestMethod]
        public void TestNewtonRaphshonMethod()
        {
            Func<double, double> func = (double x) => (Pow(x, 2.0) - 1.0);

            var ans1 = NewtonRaphson.FindRoot(func, 2.0);
            Assert.AreEqual(ans1, 1.0);

            var ans2 = NewtonRaphson.FindRoot(func, -2.0);
            Assert.AreEqual(ans2, -1.0);
        }
    }
}