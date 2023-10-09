using System;

namespace RedRing.Common.Numerics {
    public static class CalculationDefine
    {
        public static double Abs(double value) => Math.Abs(value);
        public const double EPS = 1E-8;

        public const double PI = Math.PI;
        public static double Pow(double x, double y) => Math.Pow(x, y);

        public static double Sqrt(double d) => System.Math.Sqrt(d);

        public delegate double NewtonRaphsonFunc(double x);
    }
}