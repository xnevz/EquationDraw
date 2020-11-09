using Ninject;

namespace EquationDraw
{
    /// <summary>
    /// Expression of a binary operation eg: + - * / power etc...
    /// </summary>
    public class BinaryOperationExpression : Expression
    {

        /// <summary>
        /// Left side of the operation
        /// </summary>
        public Expression Left { get; set; }

        /// <summary>
        /// Right Side of the operation
        /// </summary>
        public Expression Right { get; set; }

        /// <summary>
        /// type of operation
        /// </summary>
        public BinaryOperationType Type { get; set; }

        private IUIProvider uiProvider;

        private void Init()
        {
            // setting the UI provider
            uiProvider = App.DIKernel.Get<IUIProvider>();
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public BinaryOperationExpression(Expression left, Expression right, BinaryOperationType type)
        {
            // initialisation
            Init();

            Left = left;
            Right = right;

            // optimise parenthesis for Division
            if (type == BinaryOperationType.Div)
            {
                if (right is FuncExpression rFunc && rFunc.IsOrdinaryParenthesis())
                    Right = rFunc.Params[0];

                if (left is FuncExpression lFunc && lFunc.IsOrdinaryParenthesis())
                    Left = lFunc.Params[0];
            }

            Type = type;

            // setting the parent of the left & right expressions
            Left.Parent = Right.Parent = this;
        }

        public override Number GetUI()
            => uiProvider.ConstructBinaryOperation(Type, Left.GetUI(), Right.GetUI());

        public override Expression Optimise()
        {
            // optimise left & right
            Right = Right.Optimise();
            Left = Left.Optimise();

            return this;
        }
    }
}
