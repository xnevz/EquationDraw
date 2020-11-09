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
    public class MyMultiValueConverter : BaseMultiValueConverter
    {
        public enum ConversionType
        {
            /// <summary>
            /// chooses the maximum value of the given ones
            /// </summary>
            Max
        }

        public bool IsReturnGridLength { get; set; }

        public ConversionType Type { get; set; }

        public override object Convert2(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            switch (Type)
            {
                case ConversionType.Max:
                    var m =  values.All(v => v is double) ? values.Select(v => v as double?).Max() : null;
                    return IsReturnGridLength ? (object)new GridLength(m.Value) : m;
                default:
                    return null;
            }
        }
    }
}
