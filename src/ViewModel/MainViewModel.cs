using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RedRing.Model;
using RedRing.Framework.IO;

namespace RedRing.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        public Space Model { get; private set; }

    public MainViewModel()
            : base(WeakReferenceMessenger.Default)
        {
            Model = new Space();

            AddCube = new RelayCommand(() => Model.AddModel(new Cube()));

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
                                Model.AddModel(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                                break;
                            case "obj":
                                triangleMesh = await OBJFile.LoadAsync(path);
                                Model.AddModel(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
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
                                        await STLFile.WriteAsciiAsync(Model.GetTriangleMeshes(), path);
                                        break;
                                    case 2:
                                        await STLFile.WriteBinaryAsync(Model.GetTriangleMeshes(), path);
                                        break;
                                    default:
                                        break;
                                }
                            }));
                });
        }

        public RelayCommand AddCube { get; private set; }

        public RelayCommand Inport { get; private set; }

        public RelayCommand Export { get; private set; }
    }
}