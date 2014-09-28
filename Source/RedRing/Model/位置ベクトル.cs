using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.RedRing.Model
{
    public class 位置ベクトル : ベクトル
    {
        public 位置ベクトル(double x, double y, double z)
            :base(x, y, z)
        {
        }

        public static 位置ベクトル operator +(位置ベクトル l, ベクトル r)
        {
            return new 位置ベクトル(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
        }
    }
}
