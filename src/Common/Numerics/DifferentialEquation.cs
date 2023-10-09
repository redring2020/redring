using static RedRing.Common.Numerics.CalculationDefine;

namespace RedRing.Common.Numerics
{
    internal class DifferentialEquation
    {
        internal static double Calc(NewtonRaphsonFunc f, double xd)
        {
            double h = Pow(10.0, -9.0);
            return (f(xd + h) - f(xd)) / h;
        }
    }
}
