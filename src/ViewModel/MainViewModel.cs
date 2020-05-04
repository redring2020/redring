using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RedRing.Model;
using RedRing.Framework.IO;

namespace RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public 空間 モデル { get; private set; }

    public MainViewModel()
            : base(Messenger.Default)
        {
            モデル = new 空間();

            立方体を追加する = new RelayCommand(() => モデル.モデルを追加する(new 立方体()));

            Inport = new RelayCommand(
                () => {
                    MessengerInstance.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        var triangleMesh = await STLFile.LoadAsync(path);
                        モデル.モデルを追加する(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                    }));
                });

            Export = new RelayCommand(
                () =>
                {
                    MessengerInstance.Send(
                        new FileSaveMessage(
                            async (path, filterIndex) =>
                            {
                                switch(filterIndex)
                                {
                                    case 1:
                                        await STLFile.WriteAsciiAsync(モデル.GetTriangleMeshes(), path);
                                        break;
                                    default:
                                        break;
                                }
                            }));
                });
        }

        public RelayCommand 立方体を追加する { get; private set; }

        public RelayCommand Inport { get; private set; }

        public RelayCommand Export { get; private set; }
    }
}