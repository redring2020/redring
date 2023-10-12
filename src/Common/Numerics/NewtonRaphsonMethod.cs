using System;
using static RedRing.Common.Numerics.CalculationDefine;

namespace RedRing.Common.Numerics
{
    public class NewtonRaphsonMethod
    {
        const int Limit = 1000;
        static double DifferentialEquation(Func<double, double> func, double xd)
        {
            double h = Pow(10.0, -9.0);
            return (func(xd + h) - func(xd)) / h;
        }

        public static double? Calc(Func<double, double> func, double x, double eps = EPS, int limit = Limit)
        {
            if (func == null) throw new ArgumentNullException("func");
            if (eps <= 0) throw new ArgumentOutOfRangeException("eps");
            if (limit <= 0) throw new ArgumentOutOfRangeException("limit");
            try
            {
                double ax;

                for (int i = 0; i < limit; i++)
                {
                    ax = x - func(x) / DifferentialEquation(func, x);
                    if (Abs(ax - x) < eps)
                    {
                        return ax;
                    }
                    x = ax;
                }
            } catch
            {
                throw new Exception();
            }
            return null;
        }
    }
}
