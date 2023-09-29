using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using RedRing.Model;

namespace RedRing
{
    class ToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.GetType() == typeof(Vector))
            {
                var v = value as Vector;
                return new Vector3D(v.X, v.Y, v.Z);
            }
            if (value.GetType() == typeof(Point))
            {
                var p = value as Point;
                return new Point3D(p.X, p.Y, p.Z);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
