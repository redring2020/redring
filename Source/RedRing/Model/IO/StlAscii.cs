using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.Model.IO
{
    public static class StlAscii
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
        /// <param name="triangleFacets">三角形ポリゴンデータ</param>
        /// <returns>成功したらTrue</returns>
        public static bool Load(string filePath, out TriangleFacets triangleFacets)
        {
            triangleFacets = null;

            StreamReader sr = File.OpenText(filePath);

            try
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

                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Trim().Split(' ');
                    foreach (var token in tokens)
                    {
                        lowerToken = token.ToLower();

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
                                            int lastIndex = vertexIndices.Any() ? vertexIndices.Last().Item3 : -1;
                                            vertexIndices.Add(new Tuple<int, int, int>(lastIndex + 1, lastIndex + 2, lastIndex + 3));
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

                if (vertices.Count >= 3 && vertexIndices.Count % 3 == 0 && vertexIndices.Count >= 3)
                {
                    triangleFacets = new TriangleFacets(vertices, vertexIndices);
                }
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return triangleFacets != null;
        }
    }
}
