using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RedRing.Framework.Geometry.Double.Geometry3D;

namespace RedRing.Framework.IO
{
    /// <summary>
    /// STLファイルのIO処理を行うクラス
    /// </summary>
    public partial class STLFile
    {
        /// <summary>
        /// テキスト(ASCII)形式でのSTLファイル書き込み
        /// </summary>
        /// <param name="triangleMeshes">三角形メッシュ</param>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        public static async Task WriteAsciiAsync(IEnumerable<TriangleMesh> triangleMeshes, string filePath)
        {
            // filePath が入っていない場合はエラーとする
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            // ファセットデータが無い場合はエラー
            if (triangleMeshes == null)
                throw new ArgumentNullException(nameof(triangleMeshes));

            try
            {
                // 上書きの書き込みモードでファイルを開く
                using (var writer = new StreamWriter(filePath, false, Encoding.ASCII))
                {
                    await Task.Run(() =>
                    {
                        var assembly = Assembly.GetExecutingAssembly();
                        var name = assembly.GetName().Name.Split('.').FirstOrDefault();

                        // ヘッダ書き込み
                        string header = name +' ' + assembly.GetName().Version;
                        writer.WriteLine("solid " + header);

                        // 全ファセットデータ書き込み
                        foreach (var triangleMesh in triangleMeshes)
                        {
                            int i = 0;
                            foreach (var vertexIndces in triangleMesh.VertexIndices)
                            {
                                writer.WriteLine("  facet normal " + ToText(triangleMesh.VertexNormals.ElementAtOrDefault(i).X, triangleMesh.VertexNormals.ElementAtOrDefault(i).Y, triangleMesh.VertexNormals.ElementAtOrDefault(i).Z));
                                writer.WriteLine("    outer loop");
                                writer.WriteLine("      vertex " + ToText(triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item1).X, triangleMesh.Vertices.ElementAt(vertexIndces.Item1).Y, triangleMesh.Vertices.ElementAt(vertexIndces.Item1).Z));
                                writer.WriteLine("      vertex " + ToText(triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item2).X, triangleMesh.Vertices.ElementAt(vertexIndces.Item2).Y, triangleMesh.Vertices.ElementAt(vertexIndces.Item2).Z));
                                writer.WriteLine("      vertex " + ToText(triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item3).X, triangleMesh.Vertices.ElementAt(vertexIndces.Item3).Y, triangleMesh.Vertices.ElementAt(vertexIndces.Item3).Z));
                                writer.WriteLine("    endloop");
                                writer.WriteLine("  endfacet");

                                i++;
                            }

                            // フッタ書き込み
                            string footer = string.Empty;
                            writer.WriteLine("endsolid " + footer);

                            // 頂点データをテキストに変換
                            string ToText(double x, double y, double z)
                            {
                                return
                                x.ToString("e") + " " +
                                y.ToString("e") + " " +
                                z.ToString("e");
                            }
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// バイナリ(Binary)形式でのSTLファイル書き込み
        /// </summary>
        /// <param name="triangleMeshes">三角形メッシュ</param>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        public static async Task WriteBinaryAsync(IEnumerable<TriangleMesh> triangleMeshes, string filePath)
        {
            // filePath が入っていない場合はエラーとする
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            // ファセットデータが無い場合はエラー
            if (triangleMeshes == null)
                throw new ArgumentNullException(nameof(triangleMeshes));

            try
            {
                // 上書きモードでファイルを開く
                using (var stream = File.Open(filePath, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.Unicode))
                    {
                        await Task.Run(() =>
                        {
                            byte[] header = new byte[80];

                            // ヘッダ書き込み
                            writer.Write(header);

                            // ファセットの枚数書き込み
                            uint size = 0;

                            foreach (var triangleMesh in triangleMeshes)
                            {
                                size += (uint)triangleMesh.VertexIndices.Count();
                            }

                            writer.Write(size);

                            // 全ファセット書き込み
                            ushort buff = 0;

                            // 全ファセットデータ書き込み
                            foreach (var triangleMesh in triangleMeshes)
                            {
                                int i = 0;

                                foreach (var vertexIndces in triangleMesh.VertexIndices)
                                {

                                    writer.Write((float)triangleMesh.VertexNormals.ElementAtOrDefault(i).X);
                                    writer.Write((float)triangleMesh.VertexNormals.ElementAtOrDefault(i).Y);
                                    writer.Write((float)triangleMesh.VertexNormals.ElementAtOrDefault(i).Z);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item1).X);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item1).Y);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item1).Z);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item2).X);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item2).Y);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item2).Z);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item3).X);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item3).Y);
                                    writer.Write((float)triangleMesh.Vertices.ElementAtOrDefault(vertexIndces.Item3).Z);

                                    writer.Write(buff);

                                    i++;
                                }
                            }
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
