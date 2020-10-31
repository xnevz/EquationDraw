using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class ExpressionTuple : Expression, IEnumerable<Expression>
    {
        public List<Expression> Expressions { get; set; }

        public ExpressionTuple(List<Expression> expressions)
        {
            Expressions = expressions;
        }

        public IEnumerator<Expression> GetEnumerator()
            => Expressions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Expressions.GetEnumerator();

        public override Number GetUI()
        {
            var op = new GroupOperation()
            {
                Separator = ","
            };

            Expressions.Select(exp => exp.GetUI()).ForEach(exp => op.Operators.Add(exp));

            return op;
        }
    }
}
