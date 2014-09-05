using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Marimo.RedRing.ViewModel;
using Microsoft.Win32;

namespace Marimo.RedRing.Wpf
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
    }
}
