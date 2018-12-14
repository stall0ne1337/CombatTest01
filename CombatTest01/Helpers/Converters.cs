using CombatTest01.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CombatTest01.Helpers
{
    public class OrientationToRotateAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EntityOrientation)
            {
                switch ((EntityOrientation)value)
                {
                    case EntityOrientation.Right:
                        return 0;

                    case EntityOrientation.DownRight:
                        return 45;

                    case EntityOrientation.Down:
                        return 90;

                    case EntityOrientation.DownLeft:
                        return 135;

                    case EntityOrientation.Left:
                        return 180;

                    case EntityOrientation.UpLeft:
                        return 225;

                    case EntityOrientation.Up:
                        return 270;

                    case EntityOrientation.UpRight:
                        return 315;
                }
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
