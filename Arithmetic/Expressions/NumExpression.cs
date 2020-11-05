using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class NumExpression : Expression
    {
        public double Value { get; set; }

        public NumExpression(double value)
        {
            Value = value;
        }

        public override Number GetUI()
            => new RealNumber { Value = Value };

        public override Expression Optimise()
        {
            return this;
        }
    }
}
