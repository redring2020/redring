using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Marimo.RedRing.Model;
using Marimo.RedRing.Model.IO;

namespace Marimo.RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public 空間 モデル { get;private set; }

        public MainViewModel()
            :base(Messenger.Default)
        {
            モデル = new 空間();

            立方体を追加する = new RelayCommand(() => モデル.モデルを追加する(new 立方体()));

            Stlファイルを読み込む = new RelayCommand(
                () => {
                    MessengerInstance.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        モデル.モデルを追加する(await StlFile.LoadAsync(path));
                    }));
                });
        }

        public RelayCommand 立方体を追加する { get;private set; }

        public RelayCommand Stlファイルを読み込む { get;private set; }
    }
}