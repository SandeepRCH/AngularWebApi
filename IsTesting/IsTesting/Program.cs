using System;
namespace IsTesting
{/// <summary>
/// Implements the funtionality of is and as in two different class
/// </summary>
    public class IsAndAsImplementation
    {
        public static Type classType;
        public static void Main(string[] args)
        {
            IsTesting IsObj = new IsTesting();
            AsTesting AsObj = new AsTesting();
            bool isCheck;
            object obj;
            string className;
            obj = AsObj;
            Console.WriteLine("Enter the class name to compare");
            className = Console.ReadLine();
            isCheck = IsObj.TestIs(obj, className);
            Console.WriteLine("is " + isCheck);
            if (isCheck)
            {
                Console.WriteLine("the object before As  " + obj);
                obj = AsObj.TestAs(obj, className);
                Console.WriteLine("the object after As  " + obj);
            }
            Console.ReadLine();
        }
    }
}