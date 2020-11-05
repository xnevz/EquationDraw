using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace EquationDraw
{

    /// <summary>
    /// the base for all value converters, this base forces them to be MarkupExtensions by default
    /// </summary>
    public abstract class BaseValueConverter : MarkupExtension, IValueConverter
    {
        public IValueConverter NextConverter { get; set; }

        public virtual object Convert2(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (NextConverter is null)
                return Convert2(value, targetType, parameter, culture);
            else
                return NextConverter.Convert(Convert2(value, targetType, parameter, culture), targetType, parameter, culture);
        }

        public virtual object ConvertBack2(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (NextConverter is null)
                return ConvertBack2(value, targetType, parameter, culture);
            else
                return NextConverter.ConvertBack(ConvertBack2(value, targetType, parameter, culture), targetType, parameter, culture);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;


    }
}
