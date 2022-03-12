using System;

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
                return X * X + Y * Y + Z * Z;
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
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
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

            if (obj is Vector3D d)
            {
                return Equals(d);
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
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool Equals(Vector3D left, Vector3D right) =>
            left.Equals(right);

        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode() =>
            VectorHashCode<double>.GetHashCode3(X, Y, Z);

        /// <summary>
        /// 2つのベクトルの値が等しいか判断する
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool operator ==(Vector3D left, Vector3D right) =>
            left.Equals(right);

        /// <summary>
        /// 2つのベクトルの値が異なるか判断する
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>値が異なる場合にはtrue</returns>
        public static bool operator !=(Vector3D left, Vector3D right) =>
            !left.Equals(right);

        /// <summary>
        /// 単項マイナス
        /// </summary>
        /// <param name="vector3D">ベクトル</param>
        /// <returns>マイナスベクトル</returns>
        public static Vector3D operator -(Vector3D vector3D) =>
            new Vector3D(-vector3D.X, -vector3D.Y, -vector3D.Z);

        /// <summary>
        /// ベクトルの足し算
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>足し算されたベクトル</returns>
        public static Vector3D operator +(Vector3D left, Vector3D right) =>
            new Vector3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <summary>
        /// ベクトルの足し算
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>足し算されたベクトル</returns>
        public static Vector3D Add(Vector3D left, Vector3D right)
        {
            return left + right;
        }

        /// <summary>
        /// ベクトルの引き算
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>引き算されたベクトル</returns>
        public static Vector3D operator -(Vector3D left, Vector3D right) =>
            new Vector3D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// ベクトルの引き算
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">1番目から引くベクトル</param>
        /// <returns>引き算されたベクトル</returns>
        public static Vector3D Subtract(Vector3D left, Vector3D right)
        {
            return left - right;
        }

        /// <summary>
        /// スカラーとベクトルの掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="vector3D">ベクトル</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D operator *(double scalar, Vector3D vector3D)
        {
            return scalar * vector3D;
        }

        /// <summary>
        /// スカラーとベクトルの掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="vector3D">ベクトル</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D Multiply(double scalar, Vector3D vector3D) =>
            new Vector3D(scalar * vector3D.X, scalar * vector3D.Y, scalar * vector3D.Z);

        /// <summary>
        /// ベクトルとスカラーの掛け算
        /// </summary>
        /// <param name="vector3D">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>掛け算されたベクトル</returns>
        public static Vector3D Multiply(Vector3D vector3D, double scalar) =>
            Multiply(vector3D, scalar);

        /// <summary>
        /// ベクトルとスカラーの割り算
        /// </summary>
        /// <param name="vector">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>割り算されたベクトル</returns>
        public static Vector3D operator /(Vector3D vector3D, double scalar) =>
            new Vector3D(vector3D.X / scalar, vector3D.Y / scalar, vector3D.Z / scalar);

        /// <summary>
        /// ベクトルとスカラーの割り算
        /// </summary>
        /// <param name="vector3d">ベクトル</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>割り算されたベクトル</returns>
        public static Vector3D Divide(Vector3D vector3d, double scalar)
        {
            return vector3d / scalar;
        }

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
        public void Normalize()
        {
            this /= Length;
        }

        /// <summary>
        /// ベクトルの内積を計算する
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>内積</returns>
        public static double DotProduct(Vector3D left, Vector3D right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        /// <summary>
        /// ベクトルの外積を計算する
        /// </summary>
        /// <param name="left">1番目のベクトル</param>
        /// <param name="right">2番目のベクトル</param>
        /// <returns>外積されたベクトル</returns>
        public static Vector3D CrossProduct(Vector3D left, Vector3D right) =>
            new Vector3D(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);

        /// <summary>
        /// X軸平行ベクトルの取得
        /// </summary>
        /// <returns>X軸平行ベクトル</returns>
        public static Vector3D GetXAxis() =>
            new Vector3D(1.0, 0.0, 0.0);

        /// <summary>
        /// Y軸平行ベクトルの取得
        /// </summary>
        /// <returns>Y軸平行ベクトル</returns>
        public static Vector3D GetYAxis() =>
            new Vector3D(0.0, 1.0, 0.0);

        /// <summary>
        /// Z軸平行ベクトルの取得
        /// </summary>
        /// <returns>Z軸平行ベクトル</returns>
        public static Vector3D GetZAxis() =>
            new Vector3D(0.0, 0.0, 1.0);

        /// <summary>
        /// ゼロベクトルの取得
        /// </summary>
        /// <returns>ゼロベクトル</returns>
        public static Vector3D GetZeroVector() =>
            new Vector3D(0.0, 0.0, 0.0);

    }
}
