﻿using RedRing.Framework.Numerics.LinerAlgebra.Double;

namespace RedRing.Framework.Model.Geometry.Double.Geometry3D
{
    /// <summary>
    /// ベクトル
    /// </summary>
    public struct Vector : IGeometry, IVector, I3D
    {
        /// <summary>
        /// 成分
        /// </summary>
        Vector3D Coord;

        /// <summary>
        /// X座標値
        /// </summary>
        public double X => Coord.X;

        /// <summary>
        /// X座標値
        /// </summary>
        public double Y => Coord.Y;

        /// <summary>
        /// Z座標値
        /// </summary>
        public double Z => Coord.Z;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        public Vector(double x, double y, double z)
        {
            Coord = new Vector3D(x, y, z);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="coord">方向ベクトル成分</param>
        public Vector(Vector3D coord)
        {
            Coord = coord;
        }

        public static Vector GetXVector() =>
            new Vector(coord: Vector3D.GetXAxis());
    }
}