using System;
using static RedRing.Common.Numerics.CalculationDefine;

namespace RedRing.Common.Numerics
{
    public class NewtonRaphsonMethod
    {
        public delegate double Func(double x);
        const int Limit = 1000;
        static double DifferentialEquation(Func f, double xd)
        {
            double h = Pow(10.0, -9.0);
            return (f(xd + h) - f(xd)) / h;
        }

        public static bool Calc(Func func, double a, out double ans, double eps = EPS, int limit = Limit)
        {
            if (func == null) throw new ArgumentNullException("func");
            if (eps <= 0) throw new ArgumentOutOfRangeException("eps");
            if (limit <= 0) throw new ArgumentOutOfRangeException("limit");
            try
            {
                ans = 0.0;
                int i = 0;
                double ah = 0.0;

                if (eps <= 0.0) { return false; }

                while (i < limit)
                {
                    i++;
                    ah = a - func(a) / DifferentialEquation(func, a);
                    // 収束条件を満たせばループ終了
                    if (Abs(ah - a) < eps)
                    {
                        ans = ah;
                        break;
                    }
                    a = ah;
                }

                if (limit < i) return false;
                ans = ah;
            } catch
            {
                throw new Exception();
            }

            return true;
        }
    }
}
