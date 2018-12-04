using System;
namespace IsTesting
{
    class IsTesting : IsAndAsImplementation
    {/// <summary>
     /// implements the functionality of is
     /// </summary>
     /// <param name="obj"></param>
     /// <param name="className"></param>
     /// <returns></returns>
        public bool TestIs(object obj, string className)
        {
            string objClass;
            Type typeClass = obj.GetType();
            objClass = Convert.ToString(typeClass);
            string[] nameStrings = objClass.Split('.');
            bool Check;
            if (nameStrings[1] == className)
            {
                classType = typeClass;
                Check = true;
            }
            else
            {
                nameStrings = (Convert.ToString(typeClass.BaseType)).Split('.');
                if (nameStrings[1] == className)
                {
                    classType = typeClass.BaseType;
                    Check = true;
                }
                else
                {
                    Check = false;
                }
            }
            return Check;
        }
    }
}
