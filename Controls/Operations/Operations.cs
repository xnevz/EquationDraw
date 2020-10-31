namespace EquationDraw
{
    public class PlusOperation : GroupOperation
    {
        public PlusOperation()
        {
            Separator = " + ";
        }
    }
    public class MinusOperation : GroupOperation
    {
        public MinusOperation()
        {
            Separator = " - ";
        }
    }

    public class MultiplicationOperation : GroupOperation
    {
        public MultiplicationOperation()
        {
            Separator = " ⨯ ";
        }
    }

}
