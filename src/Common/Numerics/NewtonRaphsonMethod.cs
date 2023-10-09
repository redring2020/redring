using System;
using static RedRing.Common.Numerics.CalculationDefine;

namespace RedRing.Common.Numerics
{
    public class NewtonRaphsonMethod
    {
        const int Limit = 1000;

        public static bool Calc(NewtonRaphsonFunc func, double a, out double ans, double eps = EPS, int limit = Limit)
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
                    ah = a - func(a) / DifferentialEquation.Calc(func, a);
                    // 収束条件を満たせばループ終了
                    if (CalculationDefine.Abs(ah - a) < eps)
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
