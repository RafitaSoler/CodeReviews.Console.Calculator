namespace CalculatorLibrary
{
    public enum Operator
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        Exponentiation,
        SquareRoot,
        Exponent10,
        Sin,
        Cos,
        Tan
    }

    public record struct Operation(Operator @operator, double number1, double number2, double result);

    public class Calculator
    {
        List<Operation> previousOperations = new();
        Logger logger = new();

        public double DoOperation(double num1, double num2, int op)
        {
            double result = double.NaN;
            Operator @operator = (Operator)op;
            switch (@operator)
            {
                case Operator.Addition:
                    result = num1 + num2;
                    break;
                case Operator.Substraction:
                    result = num1 - num2;
                    break;
                case Operator.Multiplication:
                    result = num1 * num2;
                    break;
                case Operator.Division:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                case Operator.Exponentiation:
                    result = Math.Pow(num1, num2);
                    break;
                case Operator.SquareRoot:
                    result = Math.Sqrt(num1);
                    break;
                case Operator.Exponent10:
                    result = Math.Pow(10, num1);
                    break;
                case Operator.Sin:
                    result = Math.Sin(num1);
                    break;
                case Operator.Cos:
                    result = Math.Cos(num1);
                    break;
                case Operator.Tan:
                    result = Math.Tan(num1);
                    break;
                default:
                    break;
            }
            previousOperations.Add(new Operation(@operator, num1, num2, result));
            return result;
        }

        public void Finish()
        {
            logger.Log(previousOperations);
        }

        public List<Operation> GetOperations()
        {
            return previousOperations;
        }

        public void DeleteHistory()
        {
            previousOperations.Clear();
        }
    }
}
