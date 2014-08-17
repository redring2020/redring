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
        public ObservableCollection<立方体> 表示モデル { get; private set; }

        public 空間()
        {
            表示モデル = new ObservableCollection<立方体>();
        }

        public void 立方体を追加する()
        {
            表示モデル.Add(new 立方体 { });
        }
    }
}
