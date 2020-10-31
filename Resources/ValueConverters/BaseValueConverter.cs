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
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
