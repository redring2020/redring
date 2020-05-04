using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRing.Framework.Attribute
{
    /// <summary>
    /// マテリアル情報
    /// </summary>
    public struct Material
    {
        /// <summary>
        /// アンビエントカラー
        /// </summary>
        public Tuple<float, float, float> Ambient { get; set; }

        /// <summary>
        /// ディフューズカラー
        /// </summary>
        public Tuple<float, float, float> Diffuse { get; set; }

        /// <summary>
        /// スペキュラーカラー
        /// </summary>
        public Tuple<float, float, float> Specular { get; set; }
        /// <summary>
        /// テクスチャー名
        /// </summary>
        public string Texture { get; set; }
    }
}
