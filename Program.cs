Console.WriteLine("Enter first number");
double a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter second number");
double b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter Arithmetic operator (+)Addition, (-)Difference, (*)Multiple, (/)Division, (^)Power, (~)Square root");
string arithmeticOperator = Console.ReadLine();
double result = 0;

switch (arithmeticOperator)
{
    case "+":
        result = a + b;
        break;
    case "-":
        result = a - b;
        break;
    case "*":
        result = a * b;
        break;
    case "/":
        result = a / b;
        break;
    case "^":
        result = Math.Pow(a, b);
        break;
    case "~":
        {
            double sqrtA = Math.Sqrt(a);
            double sqrtB = Math.Sqrt(b);
            Console.WriteLine($"Square root of {a}: {sqrtA}");
            Console.WriteLine($"Square root of {b}: {sqrtB}");
            break;
        }

    default:
        Console.WriteLine("Invalid Operator");
        break;
}

Console.WriteLine($"Result: {result}");