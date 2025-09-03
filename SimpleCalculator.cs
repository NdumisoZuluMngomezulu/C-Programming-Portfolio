    using System;

    namespace SimpleCalculator
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool endApp = false;

                Console.WriteLine("Console Calculator in C#\r");
                Console.WriteLine("------------------------\n");

                while (!endApp)
                {
                    string numInput1 = "";
                    string numInput2 = "";
                    double result = 0;

                    // Get the first number
                    Console.Write("Enter the first number: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter a numeric value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Get the operator
                    Console.Write("Choose an operator (+, -, *, /): ");
                    string op = Console.ReadLine();

                    // Get the second number
                    Console.Write("Enter the second number: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter a numeric value: ");
                        numInput2 = Console.ReadLine();
                    }

                    try
                    {
                        result = Calculate(cleanNum1, cleanNum2, op);
                        Console.WriteLine($"Your result: {cleanNum1} {op} {cleanNum2} = {result}\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                    }

                    Console.WriteLine("Press 'n' and Enter to close the app, or any other key and Enter to continue.");
                    if (Console.ReadLine() == "n")
                    {
                        endApp = true;
                    }
                    Console.WriteLine("\n");
                }
                return;
            }

            public static double Calculate(double num1, double num2, string op)
            {
                double result = double.NaN; // Default value is "not-a-number" if an error occurs.

                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Cannot divide by zero.");
                        }
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
    }
