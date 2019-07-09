namespace RedRing.Common.Numerics.LinerAlgebra
{
    /// <summary>
    /// ベクトル計算のためのハッシュコード
    /// </summary>
    internal static class VectorHashCode<T>
    {
        /// <summary>
        /// ハッシュ計算の為の値
        /// </summary>
        internal const int HashVal1 = 17;

        /// <summary>
        /// ハッシュ計算の為の値
        /// </summary>
        internal const int HashVal2 = 31;

        /// <summary>
        /// 3Dベクトルのハッシュコードを取得する
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <param name="y">Y座標値</param>
        /// <param name="z">Z座標値</param>
        /// <returns>ハッシュコード</returns>
        internal static int GetHashCode3D(T x, T y, T z) => ((HashVal1 * HashVal2 + x.GetHashCode()) * HashVal2 + y.GetHashCode()) * HashVal2 + z.GetHashCode();
    }
}
