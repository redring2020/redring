using System;

namespace RedRing.Common.Numerics.LinerAlgebra.Double
{
    /// <summary>
    /// 3次元座標
    /// </summary>
    [Serializable]
    public struct Point3D
    {
        /// <summary>
        /// X座標値
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y座標値
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Z座標値
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// ポイントからベクトルに変換する
        /// </summary>
        /// <param name="p">ポイント</param>
        public static explicit operator Vector3D(Point3D p) =>
            new Vector3D(p.X, p.Y, p.Z);

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                return true;
            }

            if (obj is Point3D)
            {
                return Equals((Point3D)obj);
            }

            return false;
        }

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="p">ポイント</param>
        /// <returns>等しい場合にはtrue</returns>
        public bool Equals(Point3D p) =>
            X == p.X && Y == p.Y && Z == p.Z;

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="p1">ポイント</param>
        /// <param name="p2">ポイント</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool Equals(Point3D p1, Point3D p2) =>
            p1.Equals(p2);

        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode() =>
            VectorHashCode<double>.GetHashCode3D(X, Y, Z);

        /// <summary>
        /// 2つのポイントの値が等しいか判断する
        /// </summary>
        /// <param name="p1">ポイント</param>
        /// <param name="p2">ポイント</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool operator ==(Point3D p1, Point3D p2) =>
            p1.Equals(p2);

        /// <summary>
        /// 2つのポイントの値が異なるか判断する
        /// </summary>
        /// <param name="p1">ポイント</param>
        /// <param name="p2">ポイント</param>
        /// <returns>値が異なる場合にはtrue</returns>
        public static bool operator !=(Point3D p1, Point3D p2) =>
            !p1.Equals(p2);

        /// <summary>
        /// ポイントにベクトルを加算する
        /// </summary>
        /// <param name="p">ポイント</param>
        /// <param name="v">ベクトル</param>
        /// <returns>加算されたベクトル</returns>
        public static Point3D Add(Point3D p, Vector3D v) =>
            new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

        /// <summary>
        /// ポイントを指定量移動する
        /// </summary>
        /// <param name="offsetX">X移動値</param>
        /// <param name="offsetY">Y移動値</param>
        /// <param name="offsetZ">Z移動値</param>
        public void Offset(double offsetX, double offsetY, double offsetZ)
        {
            X += offsetX;
            Y += offsetY;
            Z += offsetZ;
        }

        /// <summary>
        /// ポイント同士の減算
        /// </summary>
        /// <param name="p1">ポイント</param>
        /// <param name="p2">ポイント</param>
        /// <returns>減算されたポイント</returns>
        public static Point3D Subtract(Point3D p1, Point3D p2) =>
            new Point3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

        /// <summary>
        /// ポイントとベクトルの減算
        /// </summary>
        /// <param name="p">ポイント</param>
        /// <param name="v">ベクトル</param>
        /// <returns>減算されたベクトル</returns>
        public static Point3D Subtract(Point3D p, Vector3D v) =>
            new Point3D(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
    }
}
