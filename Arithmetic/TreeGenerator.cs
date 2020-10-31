using Antlr4.Runtime;

namespace EquationDraw
{
    public static class TreeGenerator
    {
        /// <summary>
        /// generates an arithmetic tree from the given input, returns null if the string is invalid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Expression GenerateTree(string input)
        {
            var stream = new AntlrInputStream(input);
            var lexer = new GrammarLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new GrammarParser(tokens);
            var visitor = new TreeVisitor();

            var result = visitor.Visit(parser.root());

            return parser.MatchedEndOfFile ? result : null;
        }
    }
}
