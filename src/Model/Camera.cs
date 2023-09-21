using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RedRing.Model
{
    public class Camera : ObservableObject
    {
        public Camera()
        {
            point = new Point(5, 5, 5);
            vector = new Vector(-1, -1, -1);

            point.PropertyChanged +=
                (sender, e) =>
            {
                OnPropertyChanged(nameof(point));
            };

            vector.PropertyChanged +=
                (sender, e) =>
            {
                OnPropertyChanged(nameof(vector));
            };
        }

        public Point point { get; set; }
        public Vector vector { get; set; }
    }
}
