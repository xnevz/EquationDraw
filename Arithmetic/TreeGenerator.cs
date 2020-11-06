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
        public static Expression GenerateTree(string input, bool isOptimise = false)
        {
            var stream = new AntlrInputStream(input);
            var lexer = new GrammarLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new GrammarParser(tokens);
            var visitor = new TreeVisitor();

            visitor.OptimiseExpressionWhenVisiting = isOptimise;

            // if not EOF or there exists errors than return null, don't visit (exceptions would be thrown)
            if (!parser.MatchedEndOfFile || parser.NumberOfSyntaxErrors > 0)
                return null;


            return visitor.VisitRoot(parser.root());
        }
    }
}
