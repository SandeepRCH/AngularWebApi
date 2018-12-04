using System;
namespace EqualsTesting
{/// <summary>
/// checks for eequals with one object and two objects and
/// reference equals
/// </summary>
    public class EqualsTest
    {
        public bool Equals(object secondObj)
        {
            Console.WriteLine("Equals1 Execution");
            object firstObj = this;
            if (firstObj == secondObj)
            {
                return true;
            }
            else
            {
                return ReferenceEquals(firstObj, secondObj);
            }

        }
        public bool Equals(object firstObj, object secondObj)
        {
            Console.WriteLine("Equals2 executed");
            if (firstObj == null && secondObj == null)
            {
                return false;
            }
            return firstObj.Equals(secondObj);
        }
        public bool ReferenceEquals(object firstObj, object secondObj)
        {
            Console.WriteLine("reference equals executed");
            if (firstObj is ValueType || secondObj is ValueType)
            {
                return false;
            }
            if (firstObj == null && secondObj == null)
            {
                return true;
            }
            else if ((firstObj == null && secondObj != null) || (firstObj != null && secondObj == null))
            {
                return false;
            }
            else if (firstObj.GetHashCode() == secondObj.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}