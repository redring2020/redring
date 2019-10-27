using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using RedRing.Model;

namespace RedRing.Wpf
{
    class ToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.GetType() == typeof(ベクトル))
            {
                var ベクトル = value as ベクトル;
                return new Vector3D(ベクトル.X, ベクトル.Y, ベクトル.Z);
            }
            if (value.GetType() == typeof(位置ベクトル))
            {
                var ベクトル = value as 位置ベクトル;
                return new Point3D(ベクトル.X, ベクトル.Y, ベクトル.Z);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
