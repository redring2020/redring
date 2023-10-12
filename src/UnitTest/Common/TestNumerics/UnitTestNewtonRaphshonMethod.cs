using static RedRing.Common.Numerics.CalculationDefine;
using RedRing.Common.Numerics;

namespace Numerics
{
    [TestClass]
    public class UnitTestNewtonRaphshonMethod
    {
        [TestMethod]
        public void TestNewtonRaphshonMethod()
        {
            Func<double, double> func = (double x) => (Pow(x, 2.0) - 1.0);

            var ans1 = NewtonRaphsonMethod.Calc(func, 2.0);
            Assert.IsNotNull(ans1);
            Assert.AreEqual(ans1, 1.0);

            var ans2 = NewtonRaphsonMethod.Calc(func, -2.0);
            Assert.IsNotNull(ans2);
            Assert.AreEqual(ans2, -1.0);
        }
    }
}