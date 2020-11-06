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
            { BinaryOperationType.Sub, Tuple.Create("M0,0 L1,0", "-") },
            { BinaryOperationType.Mult, Tuple.Create("M0,0 L1,1 M1,0 L0,1", "*") },
            { BinaryOperationType.Pow, Tuple.Create("M0,1 0.5,0 1,1", "^") },
            { BinaryOperationType.Div, Tuple.Create(string.Empty, "/") }
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

        /// <summary>
        /// Operators grouped by priority
        /// </summary>
        public static BinaryOperationType[][] BinaryOperationTypeGroups =
            new BinaryOperationType[][]
            {
                new []{ BinaryOperationType.Add, BinaryOperationType.Sub },
                new []{ BinaryOperationType.Mult, BinaryOperationType.Div },
                new []{ BinaryOperationType.Pow },
            };

        public static bool CanRemoveParenthesisdWhenPreceededWith(this BinaryOperationType childOpType, BinaryOperationType parentOpType)
        {
            // init group level holders
            int childOpLevel = 0, parentOpLevel = 0;

            // loop over group
            for (int i = 0; i < BinaryOperationTypeGroups.Length; i++)
            {
                // if the group contains the child type ...
                if (BinaryOperationTypeGroups[i].Contains(childOpType))
                    // set the index value of the child
                    childOpLevel = i;

                // if the group contains the parent ...
                if (BinaryOperationTypeGroups[i].Contains(parentOpType))
                    // set the index value of the parent
                    parentOpLevel = i;
            }

            // if the childtype is greater than the parent level than parenthesis can be removed 
            if (childOpLevel > parentOpLevel)
                return true;

            // if types are the same, for now the parent has to be different than the Minus (-) operation
            else if (childOpLevel == parentOpLevel)
                return parentOpType != BinaryOperationType.Sub;

            // if parent level is greater than parenthesis are mandatory
            else return false;
        }
    }
}
