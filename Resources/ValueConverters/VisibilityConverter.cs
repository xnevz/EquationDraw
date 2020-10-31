using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EquationDraw
{
    public class VisibilityConverter : BaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as bool?;

            var pars = (parameter as string ?? "").Split(',').Select(s => s.Trim());

            var nonVisible = pars.Contains("collapsed") ? Visibility.Collapsed : Visibility.Hidden;

            if (pars.Contains("count"))
                return (((value as int?) ?? 0) > 0) ^ pars.Contains("invert") ? Visibility.Visible : nonVisible;
            else
            if (pars.Contains("isNull"))
                return (value is null) ^ pars.Contains("invert") ? Visibility.Visible : nonVisible;
            if (v is null)
                return nonVisible;

            return v.Value ^ pars.Contains("invert") ? Visibility.Visible : nonVisible;
        }
    }
}
