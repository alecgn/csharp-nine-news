using System;

namespace NativeSizedIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing native sized integers, a new type from C# 9.");
            var numberA = ShowMessageAndGetNumber("\nType a number A and press [Enter]: ");
            var numberB = ShowMessageAndGetNumber("\nType a number B and press [Enter]: ");
            Console.WriteLine($"\nThe result of operation [{nameof(MathematicalOperation.Sum)}] is: [{CalculateResult(MathematicalOperation.Sum, numberA, numberB)}]");
            Console.WriteLine($"The result of operation [{nameof(MathematicalOperation.Subtract)}] is: [{CalculateResult(MathematicalOperation.Subtract, numberA, numberB)}]");
            Console.WriteLine($"The result of operation [{nameof(MathematicalOperation.Multiply)}] is: [{CalculateResult(MathematicalOperation.Multiply, numberA, numberB)}]");
            Console.WriteLine($"The result of operation [{nameof(MathematicalOperation.Divide)}] is: [{CalculateResult(MathematicalOperation.Divide, numberA, numberB)}]");
        }

        private static nint ShowMessageAndGetNumber(string message)
        {
            Console.Write(message);
            string userInput;
            nint number;

            while (!nint.TryParse((userInput = Console.ReadLine()), out number))
            {
                Console.Write($"Input [{userInput}] invalid, try again: ");
            }

            return number;
        }

        private enum MathematicalOperation { Sum, Subtract, Multiply, Divide };

        private static nint CalculateResult(MathematicalOperation mathematicalOperation, nint numberA, nint numberB) =>
            mathematicalOperation switch
            {
                MathematicalOperation.Sum => Sum(numberA, numberB),
                MathematicalOperation.Subtract => Subtract(numberA, numberB),
                MathematicalOperation.Multiply => Multiply(numberA, numberB),
                MathematicalOperation.Divide => Divide(numberA, numberB),
                _ => throw new NotImplementedException(),
            };

        private static nint Sum(nint numberA, nint numberB) => numberA + numberB;

        private static nint Subtract(nint numberA, nint numberB) => numberA - numberB;

        private static nint Multiply(nint numberA, nint numberB) => numberA * numberB;

        private static nint Divide(nint numberA, nint numberB) => numberA / numberB;
    }
}
