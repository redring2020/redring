using System;
using static RedRing.Common.Numerics.CalculationDefine;

namespace RedRing.Common.Numerics
{
    public class NewtonRaphson
    {
        const int Limit = 1000;
        static double DifferentialEquation(Func<double, double> func, double xd)
        {
            double h = Pow(10.0, -9.0);
            return (func(xd + h) - func(xd)) / h;
        }

        public static double FindRoot(Func<double, double> func, double x, double eps = EPS, int limit = Limit)
        {
            if (TryFindRoot(func, x, eps, limit, out var root))
            {
                return root;
            }
            throw new Exception();
        }

        static bool TryFindRoot(Func<double, double> func, double x, double eps, int limit, out double root)
        {
            if (eps <= 0)
            {
                throw new ArgumentOutOfRangeException("eps");
            }

            try
            {
                root = x;
                for (int i = 0; i < limit; i++)
                {
                    root = x - func(x) / DifferentialEquation(func, x);
                    if (Abs(root - x) < eps)
                    {
                        return true;
                    }
                    x = root;
                }
            }
            catch
            {
                throw new Exception();
            }

            return false;
        }
    }
}
