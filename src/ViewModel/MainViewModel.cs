using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RedRing.Model;
using RedRing.Framework.IO;

namespace RedRing.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        public 空間 モデル { get; private set; }

    public MainViewModel()
            : base(WeakReferenceMessenger.Default)
        {
            モデル = new 空間();

            立方体を追加する = new RelayCommand(() => モデル.モデルを追加する(new 立方体()));

            Inport = new RelayCommand(
                () => {
                    Messenger.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        var lowerPath = path.ToLower();
                        var token = lowerPath.Split('.');
                        switch (token.GetValue(token.Length - 1))
                        {
                            case "stl":
                                var triangleMesh = await STLFile.LoadAsync(path);
                                モデル.モデルを追加する(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                                break;
                            case "obj":
                                triangleMesh = await OBJFile.LoadAsync(path);
                                モデル.モデルを追加する(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                                break;
                        }
                    }));
                });

            Export = new RelayCommand(
                () =>
                {
                    Messenger.Send(
                        new FileSaveMessage(
                            async (path, filterIndex) =>
                            {
                                switch(filterIndex)
                                {
                                    case 1:
                                        await STLFile.WriteAsciiAsync(モデル.GetTriangleMeshes(), path);
                                        break;
                                    case 2:
                                        await STLFile.WriteBinaryAsync(モデル.GetTriangleMeshes(), path);
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