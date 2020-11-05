using System;
using System.Globalization;
using System.Windows;

namespace EquationDraw
{
    public class VisibilityConverter : BaseValueConverter
    {
        [Flags]
        public enum VisibilitySourceType
        {
            IsText = 1,
            Count = 1 << 1,
            IsNull = 1 << 2,
            Boolean = 1 << 3,
            Invert = 1 << 4,
            Collapse = 1 << 5
        }

        public VisibilitySourceType Type { get; set; }

        public override object Convert2(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // a local optimisation
            bool isFlag(VisibilitySourceType type) => Extensions.IsFlagIn(Type, type);

            var v = value as bool?;

            var nonVisible = isFlag(VisibilitySourceType.Collapse) ? Visibility.Collapsed : Visibility.Hidden;

            if (isFlag(VisibilitySourceType.Count))
                return (((value as int?) ?? 0) > 0) ^ isFlag(VisibilitySourceType.Invert) ? Visibility.Visible : nonVisible;

            else if (isFlag(VisibilitySourceType.IsNull))
                return (value is null) ^ isFlag(VisibilitySourceType.Invert) ? Visibility.Visible : nonVisible;

            else if (isFlag(VisibilitySourceType.IsText))
                return ((value as string)?.Trim() == "") ^ isFlag(VisibilitySourceType.Invert) ? Visibility.Visible : nonVisible;

            if (v is null)
                return nonVisible;

            return v.Value ^ isFlag(VisibilitySourceType.Invert) ? Visibility.Visible : nonVisible;
        }

        public VisibilityConverter(VisibilitySourceType type)
            => Type = type;
    }
}
