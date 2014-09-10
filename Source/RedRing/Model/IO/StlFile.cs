using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.Model.IO
{
    /// <summary>
    /// STLファイルのIO処理を行うクラス
    /// </summary>
    public static class StlFile
    {
        /// <summary>
        /// 値読み込み時の種類
        /// </summary>
        enum ValueType
        {
            /// <summary>
            /// 未設定
            /// </summary>
            None,

            /// <summary>
            /// 法線方向
            /// </summary>
            Normal,

            /// <summary>
            /// 頂点座標
            /// </summary>
            Vertex,
        }

        /// <summary>
        /// STLアスキーファイルの読み込み
        /// todo:頂点共有の処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>成功したら三角形ファセット群のデータを返し、失敗したらnullを返す</returns>
        public static async Task<TriangleFaces> LoadAsciiAsync(string filePath)
        {
            // テキストファイルを開く
            using(var sr = File.OpenText(filePath))
            {
                string line;
                bool commentFlg = false;
                var vertices = new List<ベクトル>();
                var vertexIndices = new List<Tuple<int, int, int>>();
                string lowerToken;
                ValueType valueType = ValueType.None;
                int valueCount = 0;
                double value1 = double.NaN;
                double value2 = double.NaN;
                double value;
                int lastIndex;

                // 1行ずつ読み込む
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    // スペース区切りのトークンに分ける
                    string[] tokens = line.Trim().Split(' ');
                    foreach (var token in tokens)
                    {
                        // トークンを小文字に変更する
                        lowerToken = token.ToLower();

                        // トークンに対して然るべき処理を行う。
                        // それなりに厳密に書式を見ていくことにする
                        if (lowerToken == "solid")
                        {
                            commentFlg = true;
                        }
                        else if (lowerToken == "facet")
                        {
                            commentFlg = false;
                        }
                        else if (lowerToken == "normal")
                        {
                            valueType = ValueType.Normal;
                            valueCount = 0;
                        }
                        else if (lowerToken == "outer")
                        {
                            // 何もしない
                        }
                        else if (lowerToken == "loop")
                        {
                            // 何もしない
                        }
                        else if (lowerToken == "vertex")
                        {
                            valueType = ValueType.Vertex;
                            valueCount = 0;
                        }
                        else if (double.TryParse(token, out value))
                        {
                            switch (valueType)
                            {
                                case ValueType.Normal:
                                    // 何もしない
                                    break;
                                case ValueType.Vertex:
                                    switch (valueCount)
                                    {
                                        case 0:
                                            value1 = value;
                                            valueCount++;
                                            break;
                                        case 1:
                                            value2 = value;
                                            valueCount++;
                                            break;
                                        case 2:
                                            vertices.Add(new ベクトル(value1, value2, value));

                                            if (vertices.Count % 3 == 0)
                                            {
                                                lastIndex = vertexIndices.Any() ? vertexIndices.Last().Item3 : -1;
                                                vertexIndices.Add(Tuple.Create(lastIndex + 1, lastIndex + 2, lastIndex + 3));
                                            }
                                            break;
                                        default:
                                            throw new Exception("無効な値です。");
                                    }
                                    break;
                                default:
                                    throw new Exception("無効な数値です。");
                            }
                        }
                        else if (lowerToken == "endloop")
                        {
                            // 何もしない
                        }
                        else if (lowerToken == "endfacet")
                        {
                            // 何もしない
                        }
                        else if (lowerToken == "endsolid")
                        {
                            // 何もしない
                        }
                        else if (lowerToken == string.Empty)
                        {
                            // 何もしない
                        }
                        else if (commentFlg)
                        {
                            // 何もしない
                        }
                        else
                        {
                            throw new Exception("無効な書式です。");
                        }
                    }
                }

                if (vertices.Count >= 3 && vertexIndices.Count > 0)
                {
                    return new TriangleFaces(vertices, vertexIndices);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// ファセットを表す構造体
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct Facet
        {
            /// <summary>
            /// 法線方向
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] Normal;

            /// <summary>
            /// 1番目の頂点
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] Vertex1;

            /// <summary>
            /// 2番目の頂点
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] Vertex2;

            /// <summary>
            /// 3番目の頂点
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] Vertex3;

            /// <summary>
            /// 未使用領域
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused;
        }

        /// <summary>
        /// STLバイナリファイルの読み込み
        /// todo:頂点共有の処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>成功したら三角形ファセット群のデータを返し、失敗したらnullを返す</returns>
        public static async Task<TriangleFaces> LoadBinaryAsync(string filePath)
        {
            // ファイルを開く
            using (var br = new BinaryReader(File.OpenRead(filePath)))
            {
                return await Task.Run(() =>
                {
                    // コメント部を読み込む
                    var comment = new byte[80];
                    comment = br.ReadBytes(80);

                    // 三角形の枚数を読み込む
                    var facetCount = br.ReadUInt32();

                    var size = Marshal.SizeOf(typeof(Facet));
                    var ptr = IntPtr.Zero;

                    var vertices = new List<ベクトル>();
                    var vertexIndices = new List<Tuple<int, int, int>>();
                    int lastIndex;

                    try
                    {
                        ptr = Marshal.AllocHGlobal(size);
                        for (int ii = 0; ii < facetCount; ii++)
                        {
                            // ファセットデータを読み込む
                            Marshal.Copy(br.ReadBytes(size), 0, ptr, size);
                            var facet = (Facet)Marshal.PtrToStructure(ptr, typeof(Facet));

                            // 頂点を追加する
                            vertices.Add(new ベクトル(facet.Vertex1[0], facet.Vertex1[1], facet.Vertex1[2]));
                            vertices.Add(new ベクトル(facet.Vertex2[0], facet.Vertex2[1], facet.Vertex2[2]));
                            vertices.Add(new ベクトル(facet.Vertex3[0], facet.Vertex3[1], facet.Vertex3[2]));

                            // 頂点インデックスを追加する
                            lastIndex = vertexIndices.Any() ? vertexIndices.Last().Item3 : -1;
                            vertexIndices.Add(Tuple.Create(lastIndex + 1, lastIndex + 2, lastIndex + 3));
                        }
                    }
                    finally
                    {
                        if (ptr != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(ptr);
                        }
                    }

                    if (vertices.Count >= 3 && vertexIndices.Count > 0)
                    {
                        return new TriangleFaces(vertices, vertexIndices);
                    }
                    else
                    {
                        return null;
                    }
                });
            }
        }
    }
}
