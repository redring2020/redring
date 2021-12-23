using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using RedRing.ViewModel;
using Microsoft.Win32;
using System.IO;

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

            Messenger.Default.Register<FileOpenMessage>(this,
                message =>
            {
                var dialog = new OpenFileDialog { DefaultExt = "全てのファイル (*.*)|*.*" };

                if (dialog.ShowDialog() == true)
                {
                    message.CallBack(dialog.FileName);
                }
            });

            Messenger.Default.Register<FileSaveMessage>(this,
                message =>
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
