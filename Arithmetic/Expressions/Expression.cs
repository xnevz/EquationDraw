using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{

    /// <summary>
    /// the base class of all rithmetic expressions
    /// </summary>
    public abstract class Expression
    {
        /// <summary>
        /// Gets the Number object of the Expression
        /// </summary>
        /// <returns></returns>
        public abstract Number GetUI();

        /// <summary>
        /// returns an optimised version of the current expression
        /// </summary>
        /// <returns></returns>
        public abstract Expression Optimise();

        /// <summary>
        /// Parent of the expression
        /// </summary>
        public Expression Parent { get; set; }

        // sets the parent and returns the current Expression
        public Expression SetParent(Expression parent)
        {
            this.Parent = parent;
            return this;
        }
    }
}
