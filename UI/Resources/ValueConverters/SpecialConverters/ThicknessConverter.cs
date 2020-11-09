using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationDraw
{
    public class ThicknessConverter : BaseValueConverter
    {

        [Flags]
        public enum ThicknessSide
        {
            Left = 1, Top = 1 << 1, Right = 1 << 2, Bottom = 1 << 3
        }

        public ThicknessSide Side { get; set; }

        public override object Convert2(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = value as double?;

            if (d is null) return null;
            if (Side == ThicknessSide.Top)
                return new Thickness(0, d.Value, 0, 0);
            else
                throw new NotImplementedException("not implemented");

        }
    }
}
