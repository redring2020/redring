using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marimo.RedRing.Model
{
    public class 空間
    {
        public ObservableCollection<I3DModel> 表示モデル { get; private set; }

        public 空間()
        {
            表示モデル = new ObservableCollection<I3DModel>();
        }

        public void モデルを追加する(I3DModel モデル)
        {
            表示モデル.Add(モデル);
        }
    }
}
