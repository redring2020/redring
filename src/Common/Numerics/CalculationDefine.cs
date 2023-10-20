using System;

namespace RedRing.Common.Numerics {
    public static class CalculationDefine
    {
        public static double Abs(double value) => Math.Abs(value);
        internal const double EPS = 1e-8;

        public const double PI = Math.PI;
        public static double Pow(double x, double y) => Math.Pow(x, y);

        public static double Sqrt(double d) => Math.Sqrt(d);
    }
}