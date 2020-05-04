using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Framework.IO
{
    /// <summary>
    /// STLファイルのIO処理を行うクラス
    /// </summary>
    public static partial class STLFile
    {
        /// <summary>
        /// STLアスキーファイの書き出し
        /// TODO：レトロすぎるコードを何とかする。（出力したファイルが読み込めない。）
        /// </summary>
        /// <param name="triangleMeshes"></param>
        /// <param name="filePath"></param>
        public static async Task WriteAsciiAsync(IEnumerable<TriangleMesh> triangleMeshes, string filePath)
        {
            await Task.Run(() =>
            {
                if (File.Exists(filePath) == false)
                {
                    IEnumerable<string> contents = new string[] { };

                    // バージョン
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    AssemblyName asmName = assembly.GetName();
                    Version version = asmName.Version;

                    // ヘッダー
                    contents = contents.Append("solid " + version.Major.ToString() + "." + version.Minor.ToString());

                    int ii = 0;

                    foreach (var triangleMesh in triangleMeshes)
                    {
                        ii = 0;

                        foreach (var vertexIndex in triangleMesh.VertexIndices)
                        {
                            Vector normal = triangleMesh.VertexNormals.ElementAtOrDefault(ii);

                            contents = contents.Append("  facet normal " + normal.X.ToString("e") + " " + normal.Y.ToString("e") + " " + normal.Z.ToString("e"));
                            contents = contents.Append("    outer loop");

                            Point vertex1 = triangleMesh.Vertices.ElementAtOrDefault(vertexIndex.Item1);
                            contents = contents.Append("      vertex " + vertex1.X.ToString("e") + " " + vertex1.Y.ToString("e") + " " + vertex1.Z.ToString("e"));

                            Point vertex2 = triangleMesh.Vertices.ElementAtOrDefault(vertexIndex.Item2);
                            contents = contents.Append("      vertex " + vertex2.X.ToString("e") + " " + vertex2.Y.ToString("e") + " " + vertex2.Z.ToString("e"));

                            Point vertex3 = triangleMesh.Vertices.ElementAtOrDefault(vertexIndex.Item3);
                            contents = contents.Append("      vertex " + vertex3.X.ToString("e") + " " + vertex3.Y.ToString("e") + " " + vertex3.Z.ToString("e"));

                            contents = contents.Append("    endloop");

                            contents = contents.Append("  endfacet");

                            ii++;
                        }
                    }

                    // フッター
                    contents = contents.Append("endsolid ");

                    // ファイル書き込み
                    File.AppendAllLines(filePath, contents);
                }
            });
        }
    }
}
