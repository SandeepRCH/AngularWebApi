using System;
namespace EqualsTesting
{/// <summary>
/// stores any two values in the two objects declared 
/// and sends them to equals test class
/// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string firstStr = "hello";
            string secondStr = "hello";
            EqualsTest Test = new EqualsTest();
            int firstInt = 10;
            int secondInt = 10;
            object objFirst = new EqualsTest();
            object objSecond;
            objFirst = firstInt;
            objSecond = secondInt;
            Console.WriteLine(Test.Equals(objSecond));
            Console.WriteLine(Test.Equals(objFirst, objSecond));
            Console.WriteLine(Test.ReferenceEquals(objFirst, objSecond));
            Console.ReadLine();
        }
    }
}