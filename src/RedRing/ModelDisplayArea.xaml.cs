using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using RedRing.Model;

namespace RedRing
{
    /// <summary>
    /// ModelDisplayArea.xamlの相互作用ロジック
    /// </summary>
    public partial class ModelDisplayArea : UserControl
    {
        private static readonly DispatcherTimer dispatcherTimer = new DispatcherTimer { Interval = new TimeSpan(200) };
        readonly DispatcherTimer timer = dispatcherTimer;
        private Matrix3D matrix = Matrix3D.Identity;
        private bool isDrag = false;
        private enum DragType
        {
            None, Rotate, Translate, Scale
        }
        DragType dragType = DragType.None;
        private System.Windows.Point offset;
        const double AngleRatio = 0.5;

        public new Space DataContext
        {
            get
            {
                return base.DataContext as Space;
            }
            set
            {
                base.DataContext = value;
            }
        }

        public ModelDisplayArea()
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

                foreach (var displayElement in DataContext.DisplayModel)
                {
                    group.Children.Add(
                    new GeometryModel3D
                    {
                        Geometry =
                    new MeshGeometry3D
                    {
                        Positions = new Point3DCollection(
                                from position in ((displayElement.Geometry as Model.Geometry)).Positions
                                select new Point3D(position.X, position.Y, position.Z)),
                        TriangleIndices = new Int32Collection(
                                from triangleIndex in ((displayElement.Geometry as Model.Geometry)).TriangleIndices
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

        private void ModelDisplayAreaMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDrag = true;
            dragType = DragType.Rotate;
            offset = e.GetPosition(this);
        }

        // 原点からdeltaまでの符号付き距離を求めます。
        static double GetDistance(System.Windows.Vector start, System.Windows.Vector delta)
        {
            var angle = System.Windows.Vector.AngleBetween(delta, start);
            return start.Length * Math.Sin(angle * Math.PI / 180);
        }

        private void ModelDisplayAreaMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (isDrag == true)
            {
                var delta = e.GetPosition(this) - offset;
                var deltaLength = delta.Length;
                if (deltaLength == 0) return;

                switch (dragType)
                {
                    case DragType.Rotate:
                        var distance = GetDistance((System.Windows.Vector)offset, delta);
                        MatrixTransform.Rotate(new Vector3D(delta.Y, delta.X, distance), AngleRatio * deltaLength);
                        break;
                    case DragType.Translate:
                        MatrixTransform.Translate(new Vector3D(delta.X, delta.Y, 0.0));
                        break;
                    case DragType.Scale:
                        break;
                    default:
                        break;
                }
            }

        }

        private void ModelDisplayAreaMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDrag = false;
            dragType = DragType.None;
        }

        private void ModelDisplayAreaMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isDrag = false;
            dragType = DragType.None;
        }

        private void ModelDisplayAreaMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDrag = true;
            dragType = DragType.Translate;
            offset = e.GetPosition(this);

        }

        private void ModelDisplayAreaMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDrag = false;
            dragType = DragType.None;
        }

        private void ModelDisplayAreaMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta >0)
            {
                MatrixTransform.Scale(1.1);
            } else if (e.Delta < 0)
            {
                MatrixTransform.Scale(1/1.1);
            }
        }
    }

    public static class Media3DUtility
    {
        public static void Rotate(this MatrixTransform3D transform, Vector3D axis, double angle)
        {
            var matrix = transform.Matrix;
            matrix.Rotate(new Quaternion(axis, angle));
            transform.Matrix = matrix;
        }

        // 回転マトリックスのX軸方向を求めます。
        static Vector3D GetXAxis(this MatrixTransform3D transform)
        {
            var axis = new Vector3D(transform.Matrix.M11, transform.Matrix.M21, transform.Matrix.M31);
            axis.Normalize();

            return axis;
        }

        static Vector3D GetYAxis(this MatrixTransform3D transform)
        {
            var axis = new Vector3D(transform.Matrix.M12, transform.Matrix.M22, transform.Matrix.M32);
            axis.Normalize();

            return axis;
        }

        static Vector3D GetZAxis(this MatrixTransform3D transform)
        {
            var axis = new Vector3D(transform.Matrix.M13, transform.Matrix.M23, transform.Matrix.M33);
            axis.Normalize();

            return axis;
        }

        public static void Translate(this MatrixTransform3D transform, Vector3D offset)
        {
            var axisX = GetXAxis(transform);
            var axisY = GetYAxis(transform);
            var axisZ = GetZAxis(transform);

            if (Vector3D.CrossProduct(new Vector3D(1.0, 0.0, 0.0), axisX).Length != 0)
            {
                offset.X *= Vector3D.DotProduct(new Vector3D(1.0, 0.0, 0.0), axisX);
            }

            if (Vector3D.CrossProduct(new Vector3D(0.0, 1.0, 0.0), axisY).Length != 0)
            {
                offset.Y *= Vector3D.DotProduct(new Vector3D(0.0, 1.0, 0.0), axisY);
            }

            if (Vector3D.CrossProduct(new Vector3D(0.0, 0.0, 1.0), axisZ).Length != 0)
            {
                offset.Z *= Vector3D.DotProduct(new Vector3D(0.0, 0.0, 1.0), axisZ);
            }

            var matrix = transform.Matrix;
            matrix.Translate(offset);
            transform.Matrix = matrix;
        }

        public static void Scale(this MatrixTransform3D transform, double scale)
        {
            var matrix = transform.Matrix;
            matrix.Scale(new Vector3D(scale, scale, scale));
            transform.Matrix = matrix;
        }
    }
}
