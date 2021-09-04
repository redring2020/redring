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
                    switch (lowerToken)
                    {
                        case "#":
                            // コメント
                            continue;

                        case "mtllib":
                            // マテリアル情報、今のところ何もしない
                            continue;

                        case "g":
                            // 何もしない
                            continue;

                        case "usemtl":
                            // 何もしない
                            continue;

                        case "v":
                            // 頂点座標値
                            double value1;
                            double value2;
                            double value3;

                            if (double.TryParse(tokens.ElementAt(1), out value1) && double.TryParse(tokens.ElementAt(2), out value2) && double.TryParse(tokens.ElementAt(3), out value3))
                            {
                                vertices.Add(new Point(value1, value2, value3));
                            }
                            break;

                        case "vt":
                            // 頂点テクスチャ番号、今のところ何もしない
                            continue;

                        case "vn":
                            // 頂点法線ベクトル、今のところ何もしない
                            continue;

                        case "f":
                            // 面情報
                            int value4;
                            int value5;
                            int value6;

                            // 頂点番号
                            if (tokens.Count() == 4)
                            {
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(2), out value5) && int.TryParse(tokens.ElementAt(3), out value6))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                }
                            }
                            else if (tokens.Count() == 7)
                            {
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(3), out value5) && int.TryParse(tokens.ElementAt(5), out value6))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                }
                            }
                            else if (tokens.Count() == 10)
                            {
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(4), out value5) && int.TryParse(tokens.ElementAt(7), out value6))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                }
                            }
                            else if (tokens.Count() == 5)
                            {
                                int value7;
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(2), out value5) && int.TryParse(tokens.ElementAt(3), out value6) && int.TryParse(tokens.ElementAt(4), out value7))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value6 - 1, value7 - 1));
                                }
                            }
                            else if (tokens.Count() == 8)
                            {
                                int value7;
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(3), out value5) && int.TryParse(tokens.ElementAt(5), out value6) && int.TryParse(tokens.ElementAt(7), out value7))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value6 - 1, value7 - 1));
                                }
                            }
                            else if (tokens.Count() == 13)
                            {
                                int value7;
                                if (int.TryParse(tokens.ElementAt(1), out value4) && int.TryParse(tokens.ElementAt(4), out value5) && int.TryParse(tokens.ElementAt(7), out value6) && int.TryParse(tokens.ElementAt(10), out value7))
                                {
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value5 - 1, value6 - 1));
                                    vertexIndices.Add(new Tuple<int, int, int>(value4 - 1, value6 - 1, value7 - 1));
                                }
                            }
                            break;
                        default:
                            // 何もしない
                            break;
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
