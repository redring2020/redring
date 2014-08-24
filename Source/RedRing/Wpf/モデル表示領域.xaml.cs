using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.Wpf
{
    /// <summary>
    /// モデル表示領域.xaml の相互作用ロジック
    /// </summary>
    public partial class モデル表示領域 : Viewport3D
    {
        DispatcherTimer timer = new DispatcherTimer { Interval = new TimeSpan(200) };

        public new 空間 DataContext
        {
            get
            {
                return base.DataContext as 空間;
            }
            set
            {
                base.DataContext = value;
            }
        }

        public モデル表示領域()
        {
            InitializeComponent();

            timer.Tick +=
                (sender, e) =>
            {
                group.Children.Clear();

                group.Children.Add(
                    new DirectionalLight
                {
                    Color = Colors.White,
                    Direction = new Vector3D(0, -0.5, -0.6)
                });

                if (DataContext == null)
                {
                    return;
                }

                foreach (var 表示要素 in DataContext.表示モデル)
                {
                    group.Children.Add(
                    new GeometryModel3D
                    {
                        Geometry =
                    new MeshGeometry3D
                        {
                            Positions = new Point3DCollection(
                                from position in ((表示要素.Geometry as Model.Geometry)).Positions
                                select new Point3D(position.X, position.Y, position.Z)),
                            TriangleIndices = new Int32Collection(
                                from triangleIndex in ((表示要素.Geometry as Model.Geometry)).TriangleIndices
                                from index in new[] { triangleIndex.Item1, triangleIndex.Item2, triangleIndex.Item3 }
                                select index),
                            Normals = new Vector3DCollection()
                        },
                        Material = new DiffuseMaterial { Brush = new SolidColorBrush(Colors.Pink) }

                    }
                    );
                }
            };
        }

        private void Viewport3D_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
