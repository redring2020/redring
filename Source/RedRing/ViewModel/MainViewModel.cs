using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public 空間 モデル { get;private set; }

        public MainViewModel()
        {
            モデル = new 空間();

            立方体を追加する = new RelayCommand(() => モデル.モデルを追加する(new 立方体()));
        }

        public RelayCommand 立方体を追加する { get;private set; }
    }
}