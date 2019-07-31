using System;

namespace RedRing.Framework.Numerics.LinerAlgebra.Double
{
    /// <summary>
    /// 四元数
    /// </summary>
    struct Quaternion
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
        /// W座標値
        /// </summary>
        public double W { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        /// <param name="w">W座標値</param>
        public Quaternion(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        public Quaternion(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1.0;
        }

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

            if (obj is Quaternion)
            {
                return Equals((Quaternion)obj);
            }

            return false;
        }

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="q">四元数</param>
        /// <returns>等しい場合にはtrue</returns>
        public bool Equals(Quaternion q) =>
            X == q.X && Y == q.Y && Z == q.Z && W == q.W;

        /// <summary>
        /// 値が等しいか判断する
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool Equals(Quaternion left, Quaternion right) =>
            left.Equals(right);

        /// <summary>
        /// ハッシュコードを取得する
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            VectorHashCode<double>.GetHashCode4(X, Y, Z, W);

        /// <summary>
        /// 2つの四元数が等しいか判断する
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>値が等しい場合にはtrue</returns>
        public static bool operator ==(Quaternion left, Quaternion right) =>
            left.Equals(right);

        /// <summary>
        /// 2つの四元数の値が異なるか判断する
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>値が異なる場合にはtrue</returns>
        public static bool operator !=(Quaternion left, Quaternion right) =>
            !left.Equals(right);

        /// <summary>
        /// ゼロ四元数を取得する
        /// </summary>
        /// <returns>ゼロ四元数</returns>
        public static Quaternion GetZero() =>
            new Quaternion(0.0, 0.0, 0.0, 0.0);

        /// <summary>
        /// ゼロ四元数にする
        /// </summary>
        public void Zero()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
            W = 0.0;
        }

        /// <summary>
        /// 正規四元数を取得する
        /// </summary>
        /// <returns>正規四元数</returns>
        public static Quaternion GetIdentity() =>
            new Quaternion(0.0, 0.0, 0.0, 1.0);

        /// <summary>
        /// 四元数の足し算
        /// </summary>
        /// <param name="left"1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>足し算された四元数</returns>
        public static Quaternion operator +(Quaternion left, Quaternion right) =>
            new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        /// <summary>
        /// 四元数の足し算
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>足し算された四元数</returns>
        public static Quaternion Add(Quaternion left, Quaternion right)
        {
            return left + right;
        }

        /// <summary>
        /// 四元数の引き算
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">1番目から引く四元数</param>
        /// <returns>引き算された四元数</returns>
        public static Quaternion operator -(Quaternion left, Quaternion right) =>
            new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        /// <summary>
        /// 四元数の引き算
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">1番目から引く四元数</param>
        /// <returns>引き算された四元数</returns>
        public static Quaternion Subtract(Quaternion left, Quaternion right)
        {
            return left - right;
        }

        /// <summary>
        /// 四元数の掛け算
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            double x = left.W * right.X + left.X * right.W - left.Y * right.Z + left.Z * right.Y;
            double y = left.W * right.Y + left.X * right.Z + left.Y * right.W - left.Z * right.X;
            double z = left.W * right.Z - left.X * right.Y + left.Y * right.X + left.Z * right.W;
            double w = left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z;

            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// 四元数の掛け算
        /// </summary>
        /// <param name="left">1番目の四元数</param>
        /// <param name="right">2番目の四元数</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion Multiply(Quaternion left, Quaternion right)
        {
            return left * right;
        }

        /// <summary>
        /// スカラーと四元数の掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="quaternion">四元数</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion operator *(double scalar, Quaternion quaternion) =>
            new Quaternion(scalar * quaternion.X, scalar * quaternion.Y, scalar * quaternion.Z, scalar * quaternion.W);

        /// <summary>
        /// スカラーと四元数の掛け算
        /// </summary>
        /// <param name="scalar">スカラー</param>
        /// <param name="quaternion">四元数</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion Multiply(double scalar, Quaternion quaternion)
        {
            return scalar * quaternion;
        }

        /// <summary>
        /// 四元数とスカラーの掛け算
        /// </summary>
        /// <param name="quaternion">四元数</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion operator *(Quaternion quaternion, double scalar)
        {
            return scalar * quaternion;
        }

        /// <summary>
        /// 四元数とスカラーの掛け算
        /// </summary>
        /// <param name="quaternion">四元数</param>
        /// <param name="scalar">スカラー</param>
        /// <returns>掛け算された四元数</returns>
        public static Quaternion Multiply(Quaternion quaternion, double scalar)
        {
            return scalar * quaternion;
        }

        /// <summary>
        /// スカラー四元数のスケール
        /// </summary>
        /// <param name="scale">スケールする値</param>
        public void Scale(double scale)
        {
            X *= scale;
            Y *= scale;
            Z *= scale;
            W *= scale;
        }

        /// <summary>
        /// 長さの2乗
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
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
    }
}
