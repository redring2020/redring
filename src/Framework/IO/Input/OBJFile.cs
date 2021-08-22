using RedRing.Framework.Geometry.Double.Geometry3D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RedRing.Framework.IO
{
    public static partial class OBJFile
    {
        /// <summary>
        /// OBJファイルの読み込み
        /// todo:頂点共有の処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>成功したら三角形ファセット群のデータを返し、失敗したらnullを返す</returns>
        public static async Task<TriangleMesh> LoadAsync(string filePath)
        {
            // テキストファイルを開く
            using(var sr = File.OpenText(filePath))
            {
                string line;
                var vertices = new List<Point>();
                var vertexIndices = new List<Tuple<int, int, int>>();
                string lowerToken;

                // 1行ずつ読み込む
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    // スペース区切りのトークンに分ける
                    IEnumerable<string> tokens = line.Trim().Split(' ', '/');

                    // トークンを小文字に変更する
                        lowerToken = tokens.First().ToLower();

                    // トークンに対して然るべき処理を行う。
                    // それなりに厳密に書式を見ていくことにする
                    if (lowerToken == "#")
                    {
                        // コメント
                        continue;
                    }
                    else if (lowerToken == "mtllib")
                    {
                        // マテリアル情報、今のところ何もしない
                        continue;
                    }
                    else if (lowerToken == "g")
                    {
                        // 何もしない
                        continue;
                    }
                    else if (lowerToken == "usemtl")
                    {
                        // 何もしない
                        continue;
                    }
                    else if (lowerToken == "v")
                    {
                        // 頂点座標値
                        double value = double.NaN;
                        double value1 = double.NaN;
                        double value2 = double.NaN;

                        if (double.TryParse(tokens.ElementAt(1), out value) && double.TryParse(tokens.ElementAt(2), out value1) && double.TryParse(tokens.ElementAt(3), out value2))
                        {
                            vertices.Add(new Point(value, value1, value2));
                        }
                    }
                    else if (lowerToken == "vt")
                    {
                        // 頂点テクスチャ番号、今のところ何もしない
                        continue;
                    }
                    else if (lowerToken == "vn")
                    {
                        // 頂点法線ベクトル、今のところ何もしない
                        continue;
                    }
                    else if (lowerToken == "f")
                    {
                        // 面情報
                        int value;
                        int value1;
                        int value2;

                        // 頂点番号
                        if (int.TryParse(tokens.ElementAt(1), out value) && int.TryParse(tokens.ElementAt(2), out value1) && int.TryParse(tokens.ElementAt(3), out value2))
                        {
                            vertexIndices.Add(new Tuple<int, int, int>(value - 1, value1 - 1, value2 - 1));
                        }
                    }
                    else if (lowerToken == string.Empty)
                    {
                        // 何もしない
                    }
                    else
                    {
                        throw new Exception("無効な書式です。");
                    }
                }

                if (vertices.Count >= 3 && vertexIndices.Count > 0)
                {
                    return new TriangleMesh(vertices, vertexIndices);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
