using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using RedRing.ViewModel;
using Microsoft.Win32;

namespace RedRing.Wpf
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
                var dialog = new OpenFileDialog { DefaultExt = "*.*" };

                if (dialog.ShowDialog() == true)
                {
                    message.CallBack(dialog.FileName);
                }
            });
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
