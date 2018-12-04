namespace IsTesting
{
    class AsTesting : IsAndAsImplementation
    {/// <summary>
    /// tests the is funtionality and if it returns true then
    /// implements as
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="className"></param>
    /// <returns></returns>
        public object TestAs(object obj, string className)
        {
            IsTesting IsObj = new IsTesting();
            bool IsResult = IsObj.TestIs(obj, className);
            if (IsResult)
            {
                obj = classType;
                return obj;
            }
            else
            {
                return null;
            }
        }
    }
}