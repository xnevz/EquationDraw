using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class UnknownExpression : Expression
    {
        public override Number GetUI()
            => new RealNumber { Value = 0 };
    }
}
