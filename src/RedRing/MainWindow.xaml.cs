using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Messaging;
using RedRing.ViewModel;
using Microsoft.Win32;

namespace RedRing
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            WeakReferenceMessenger.Default.Register<FileOpenMessage>(this,
                (_, message) =>
                {
                    var dialog = new OpenFileDialog { DefaultExt = "全てのファイル (*.*)|*.*" };

                if (dialog.ShowDialog() == true)
                {
                    message.CallBack(dialog.FileName);
                }
            });

            WeakReferenceMessenger.Default.Register<FileSaveMessage>(this,
                (_, message) =>
                {
                    var dialog = new SaveFileDialog { DefaultExt = "STLアスキーファイル(*.stl) | *.stl", Filter = "STLアスキーファイル (*.stl)|*.stl|STLバイナリファイル (*.stl)|*.stl" };

                    if (dialog.ShowDialog() == true)
                    {
                        message.CallBack(dialog.FileName, dialog.FilterIndex);
                    }
                });
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
