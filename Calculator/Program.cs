using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new Calculator();
        while (!endApp)
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\t0 - Addition");
            Console.WriteLine("\t1 - Substraction");
            Console.WriteLine("\t2 - Multiplication");
            Console.WriteLine("\t3 - Division");
            Console.WriteLine("\t4 - Exponentiation");
            Console.WriteLine("\t5 - SquareRoot");
            Console.WriteLine("\t6 - Exponent10");
            Console.WriteLine("\t7 - Sin");
            Console.WriteLine("\t8 - Cos");
            Console.WriteLine("\t9 - Tan");
            Console.WriteLine("\th - View operations history");
            Console.WriteLine("\tq - Exit");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            int cleanOp = -1;
            while ((op.ToLower() != "q" && op.ToLower() != "h") && (!int.TryParse(op, out cleanOp) || cleanOp < 0 || cleanOp > 9))
            {
                Console.Write("This is not valid input. Please enter a valid option: ");
                op = Console.ReadLine();
            }

            if (op.ToLower() == "q")
                break;

            if(op.ToLower() == "h")
            {
                ShowOperationsHistory(calculator.GetOperations());

                Console.WriteLine("------------------------\n");
                Console.WriteLine("\td - Delete history");
                Console.WriteLine("\tany key - Back to main menu");
                Console.WriteLine("\n");

                op = Console.ReadLine();
                if (op.ToLower() == "d")
                {
                    calculator.DeleteHistory();
                    Console.WriteLine("--- History deleted ---\n");
                }
                continue;
            }

            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            double cleanNum2 = double.NaN;
            // Operators 0 to 4 are binary so they need a second number. 5 to 9 are unary
            if (cleanOp < 5)
            {
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }
            }

            try
            {
                result = calculator.DoOperation(cleanNum1, cleanNum2, cleanOp);

                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else
                {
                    Console.WriteLine("Your result: {0:0.##}\n", result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Press 'q' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "q") endApp = true;

            Console.WriteLine("\n");
        }

        calculator.Finish();
        return;
    }

    private static void ShowOperationsHistory(List<Operation> previousOperations)
    {
        Console.WriteLine("------------------------\n");
        Console.WriteLine("Operations history");
        Console.WriteLine($"{previousOperations.Count} operations saved\n");
        foreach (Operation operation in previousOperations)
        {
            switch(operation.@operator)
            {
                case Operator.Addition:
                    Console.WriteLine($"\t{operation.number1} + {operation.number2} = {operation.result}");
                    break;
                case Operator.Substraction:
                    Console.WriteLine($"\t{operation.number1} - {operation.number2} = {operation.result}");
                    break;
                case Operator.Multiplication:
                    Console.WriteLine($"\t{operation.number1} * {operation.number2} = {operation.result}");
                    break;
                case Operator.Division:
                    Console.WriteLine($"\t{operation.number1} / {operation.number2} = {operation.result}");
                    break;
                case Operator.Exponentiation:
                    Console.WriteLine($"\t{operation.number1} ^ {operation.number2} = {operation.result}");
                    break;
                case Operator.SquareRoot:
                    Console.WriteLine($"\t√ {operation.number1} = {operation.result}");
                    break;
                case Operator.Exponent10:
                    Console.WriteLine($"\t10 ^ {operation.number1} = {operation.result}");
                    break;
                case Operator.Sin:
                    Console.WriteLine($"\tsin {operation.number1} = {operation.result}");
                    break;
                case Operator.Cos:
                    Console.WriteLine($"\tcos {operation.number1} = {operation.result}");
                    break;
                case Operator.Tan:
                    Console.WriteLine($"\ttan {operation.number1} = {operation.result}");
                    break;
                default:
                    break;
            }
        Console.WriteLine();
        }
    }
}