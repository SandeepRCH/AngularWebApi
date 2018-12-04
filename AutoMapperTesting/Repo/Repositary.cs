using System;
using System.Reflection;

namespace Repo
{
    public class Repositary
    {
        public void Map<SourceType, DestinationType>(SourceType sourceObj, DestinationType destinationObj)
        {
            PropertyInfo[] sourceProperties = sourceObj.GetType().GetProperties();
            PropertyInfo[] destinationProperties = destinationObj.GetType().GetProperties();
            int index = 0;
            object sourceVal;
            foreach (var sourceProp in sourceProperties)
            {
                if (sourceProp.PropertyType == destinationProperties[index].PropertyType)
                {
                    sourceVal = sourceProp.GetValue(sourceObj);
                    var destinationProp = destinationObj.GetType().GetProperty(sourceProp.Name);
                    destinationProp.SetValue(destinationObj, sourceVal);
                    index++;
                }
                else
                {
                    Type T1 = sourceProp.PropertyType;
                    Type T2 = destinationProperties[index].PropertyType;
                    object source = sourceProp.GetValue(sourceObj);
                    object Destination = Activator.CreateInstance(T2);
                    Map(source, Destination);
                    destinationProperties[index].SetValue(destinationObj, Destination);
                }
            }
        }
    }
}
