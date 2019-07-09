using System.Collections.ObjectModel;

namespace RedRing.Model
{
    public class 空間
    {
        public ObservableCollection<I3DModel> 表示モデル { get; private set; }
        public カメラ カメラ { get;private set; }

        public 空間()
        {
            表示モデル = new ObservableCollection<I3DModel>();
            カメラ = new カメラ();
        }

        public void モデルを追加する(I3DModel モデル)
        {
            表示モデル.Add(モデル);
        }
    }
}
