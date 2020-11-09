using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    /// <summary>
    /// An abstract representation of the UI provider
    /// </summary>
    public interface IUIProvider
    {
        BaseBinaryOperation ConstructBinaryOperation(BinaryOperationType type, Number left, Number right);
    }
}
