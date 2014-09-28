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
using Marimo.RedRing.Model;

namespace Marimo.RedRing.Wpf
{
    /// <summary>
    /// ベクトル表示.xaml の相互作用ロジック
    /// </summary>
    public partial class ベクトル表示 : UserControl
    {
        public ベクトル表示()
        {
            InitializeComponent();
        }

        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                "Header",
                typeof(string),
                typeof(ベクトル表示)
            );

        public string Header
        {
            get
            {
                return GetValue(HeaderProperty) as string;
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }
        public static DependencyProperty SourceProperty =
            DependencyProperty.Register(
                "Source",
                typeof(ベクトル),
                typeof(ベクトル表示)
            );

        public ベクトル Source
        {
            get
            {
                return GetValue(SourceProperty) as ベクトル;
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }
    }
}
