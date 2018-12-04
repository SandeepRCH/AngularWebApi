using System;
namespace Floatingadd
{
    class Program
    {
        /// <summary>
        /// Reads two float values converts them to binary,adds the two binary Numbers 
        /// sand Converts the result to float again
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            double firstNumber, secondNumber, result, binarySum,binaryFirst,binarySecond;
            Console.WriteLine("Enter the two numbers to be added: ");
            firstNumber = Convert.ToDouble(Console.ReadLine());
            secondNumber = Convert.ToDouble(Console.ReadLine());
            FloatTobinary fTob = new FloatTobinary();
            binaryFirst = fTob.Conversion(firstNumber);
            binarySecond = fTob.Conversion(secondNumber);
            Addition add = new Addition();
            binarySum = add.Add(binaryFirst, binarySecond);
            BinaryToFloat BTof = new BinaryToFloat();
            result = BTof.ReverseConversion(binarySum);
            Console.WriteLine("the sum of Numbers is  " + result);
            Console.ReadLine();
        }
    }
}
