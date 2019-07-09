using System.Windows;
using System.Windows.Controls;
using RedRing.Model;

namespace RedRing.Wpf
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
