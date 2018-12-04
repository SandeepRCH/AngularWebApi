using System;
using DataLayer;
using Repo;
namespace BuissinessLayers
{/// <summary>
 /// Class to map source object to destination object
 /// </summary>
    public class BuisinessLayer
    {
        public void Mapper<SourceType>(SourceType EmpDTO)
        {
            SourceType sourceObj = EmpDTO;
            EmployeeData destinationObj = new EmployeeData();
            Repositary repository = new Repositary();
            repository.Map<SourceType, EmployeeData>(sourceObj, destinationObj);
            foreach (var v in destinationObj.GetType().GetProperties())
            {
                Console.WriteLine(v.GetValue(destinationObj));
            }
            Console.WriteLine(destinationObj.EmpAdress.city);
            Console.WriteLine(destinationObj.EmpAdress.location);
        }
    }
}