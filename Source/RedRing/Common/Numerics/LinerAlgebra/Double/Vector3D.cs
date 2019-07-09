using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRing.Common.Numerics.LinerAlgebra.Double
{
    /// <summary>
    /// 3次元ベクトル
    /// </summary>
    [Serializable]
    public struct Vector3D
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
        /// 長さの2乗
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);
            }
        }

        /// <summary>
        /// 長さ
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(LengthSquared);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// ベクトルからポイントに変換する
        /// </summary>
        /// <param name="v">ベクトル</param>
        public static explicit operator Point3D(Vector3D v) =>
            new Point3D(v.X, v.Y, v.Z);

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

            if (obj is Vector3D)
            {
                return Equals((Vector3D)obj);
            }

            return false;
        }

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <returns>等しい場合にはtrue</returns>
        public bool Equals(Vector3D v) =>
            X == v.X && Y == v.Y && Z == v.Z;

        /// <summary>
        /// 2つのベクトルが等しいか判断する
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool Equals(Vector3D v1, Vector3D v2) =>
            v1.Equals(v2);

        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode() =>
            VectorHashCode<double>.GetHashCode3D(X, Y, Z);

        /// <summary>
        /// 2つのベクトルの値が等しいか判断する
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool operator ==(Vector3D v1, Vector3D v2) =>
            v1.Equals(v2);

        /// <summary>
        /// 2つのベクトルの値が異なるか判断する
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>値が異なる場合にはtrue</returns>
        public static bool operator !=(Vector3D v1, Vector3D v2) =>
            !v1.Equals(v2);

        /// <summary>
        /// 単項マイナス
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <returns>マイナスベクトル</returns>
        public static Vector3D operator -(Vector3D v) =>
            new Vector3D(-v.X, -v.Y, -v.Z);

        /// <summary>
        /// ベクトルの足し算
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>足し算されたベクトル</returns>
        public static Vector3D Add(Vector3D v1, Vector3D v2) =>
            new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// ベクトルの足し算
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>足し算されたベクトル</returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2) =>
            Add(v1, v2);

        /// <summary>
        /// ベクトルの引き算
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>引き算されたベクトル</returns>
        public static Vector3D Subtract(Vector3D v1, Vector3D v2) =>
            new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        /// <summary>
        /// ベクトルの引き算
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>引き算されたベクトル</returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2) =>
            Subtract(v1, v2);

        /// <summary>
        /// スカラーとベクトルの掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="v">ベクトル</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D Multiply(double scalar, Vector3D v) =>
            new Vector3D(scalar * v.X, scalar * v.Y, scalar * v.Z);

        /// <summary>
        /// ベクトルとスカラーの掛け算
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D Multiply(Vector3D v, double scalar) =>
            Multiply(scalar, v);

        /// <summary>
        /// スカラーとベクトルの掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="v">ベクトル</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D operator *(double scalar, Vector3D v) =>
            Multiply(scalar, v);

        /// <summary>
        /// ベクトルとスカラーの割り算
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>割り算されたベクトル</returns>
        public static Vector3D Divide(Vector3D v, double scalar) =>
            new Vector3D(v.X / scalar, v.Y / scalar, v.Z / scalar);

        /// <summary>
        /// ベクトルとスカラーの割り算
        /// </summary>
        /// <param name="v">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>割り算されたベクトル</returns>
        public static Vector3D operator /(Vector3D v, double scalar) =>
            Divide(v, scalar);

        /// <summary>
        /// ベクトルを反転する
        /// </summary>
        public void Nagate()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        /// <summary>
        /// ベクトルを正規化する
        /// </summary>
        public void Normalize() =>
            this /= Length;

        /// <summary>
        /// ベクトルの内積を計算する
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>内積</returns>
        public static double DotProduct(Vector3D v1, Vector3D v2) =>
            v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        /// <summary>
        /// ベクトルの外積を計算する
        /// </summary>
        /// <param name="v1">ベクトル</param>
        /// <param name="v2">ベクトル</param>
        /// <returns>外積されたベクトル</returns>
        public static Vector3D CrossProduct(Vector3D v1, Vector3D v2) =>
            new Vector3D(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
    }
}
