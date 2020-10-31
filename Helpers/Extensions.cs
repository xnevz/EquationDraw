using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public static class Extensions
    {
        private static List<string> operators = new List<string> { "^", "*", "/", "\\", "+", "-" };

        public static BinaryOperationType ParseBinaryOperationType(string input)
            => (BinaryOperationType)operators.IndexOf(input.Trim());

        public static string GetOperatorSymbol(this BinaryOperationType type)
            => operators[(int)type];


        public static void ForEach<T>(this IEnumerable<T> list, Action<T> act)
        {
            foreach (var item in list)
            {
                act?.Invoke(item);
            }
        }
    }
}
