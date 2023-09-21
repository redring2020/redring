using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Model
{
    public class Vector : ObservableObject
    {
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private double x = 0;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                SetProperty(ref x, value);
            }
        }
        private double y = 0;
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                SetProperty(ref y, value);
            }
        }
        private double z = 0;
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                SetProperty(ref z, value);
            }
        }

        public static Vector operator+(Vector l, Vector r)
        {
            return new Vector(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
        }

        /// <summary>
        /// Vectorからベクトルに変換する
        /// </summary>
        /// <param name="v">ベクトル</param>
        public static explicit operator Vector(Framework.Geometry.Double.Geometry3D.Vector v)
        {
            return new Vector(v.X, v.Y, v.Z);
        }
    }
}
