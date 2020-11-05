using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EquationDraw
{
    public static class Extensions
    {
        /// <summary>
        /// binary operation data
        /// </summary>
        private static Dictionary<BinaryOperationType, Tuple<string, string>> BinaryOperationData
            = new Dictionary<BinaryOperationType, Tuple<string, string>>
        {
            { BinaryOperationType.Add, Tuple.Create("M0.5,0 M0.5,0 L0.5,1 M0,0.5 L1,0.5", "+") },
            { BinaryOperationType.Sub, Tuple.Create("M0.5,0 M0.5,0 L0.5,1 M0,0.5 L1,0.5", "-") },
            { BinaryOperationType.Mult, Tuple.Create("M0.5,0 M0.5,0 L0.5,1 M0,0.5 L1,0.5", "*") },
            { BinaryOperationType.Pow, Tuple.Create("M0.5,0 M0.5,0 L0.5,1 M0,0.5 L1,0.5", "^") },
            { BinaryOperationType.FloorDiv, Tuple.Create("M0.5,0 M0.5,0 L0.5,1 M0,0.5 L1,0.5", "\\") },
        };

        /// <summary>
        /// parses the given input into a <see cref="BinaryOperationType"/>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static BinaryOperationType ParseBinaryOperationType(string input)
            => BinaryOperationData.Where(data => data.Value.Item2 == input.Trim()).FirstOrDefault().Key;

        /// <summary>
        /// Gets the symbol of the given OPerator type
        /// </summary>
        public static string GetStringOperatorSymbol(this BinaryOperationType type)
            => BinaryOperationData[type].Item2;

        /// <summary>
        /// a foreach loop shortcut
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> act)
        {
            foreach (var item in list)
                act?.Invoke(item);
        }

        /// <summary>
        /// Checks whether the given flag belongs to the list of enums
        /// </summary>
        public static bool IsFlagIn(object flagList, object flag)
            => ((int)flagList & (int)flag) == (int)flag;

        /// <summary>
        /// Gets the symbol of the binary operation type
        /// </summary>
        /// <param name="type">type of the operation</param>
        public static OperatorControl GetOperatorSymbol(this BinaryOperationType type)
            => new OperatorControl { SymbolData = Geometry.Parse(BinaryOperationData[type].Item1) };
    }
}
