using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{

    /// <summary>
    /// The base class of all rithmetic expressions
    /// </summary>
    public abstract class Expression
    {
        /// <summary>
        /// Gets the UI representation of this Expression
        /// </summary>
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

        /// <summary>
        /// Sets the parent and returns the current Expression allowing for further modifications
        /// </summary>
        public Expression SetParent(Expression parent)
        {
            this.Parent = parent;
            return this;
        }
    }
}
