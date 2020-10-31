using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace EquationDraw
{
    public class AncestorPropertyExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
            => new Binding
            {
                RelativeSource = (new RelativeSource(RelativeSourceMode.FindAncestor)
                { AncestorType = AncestorType })
            }.ProvideValue(serviceProvider);


        public PropertyPath Path { get; set; }

        public Type AncestorType { get; set; }

        public AncestorPropertyExtension(PropertyPath path, Type AncestorType)
        {
            this.AncestorType = AncestorType;
        }
    }
}
