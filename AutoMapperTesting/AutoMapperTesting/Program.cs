using BuissinessLayers;
using System;
using DomainLayer;
namespace AutoMapperTesting
{/// <summary>
/// sends data via data layer sends it to buissiness layer
/// and maps to domain layer
/// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            BuisinessLayer BL = new BuisinessLayer();
            var EmpDTO = new EmployeeDTO() { EmployeeName = "sandeep", IdNumber = 14003114, EmpAdress = new Address() { location = "Uppal", city = "Hyderabad" } };
            BL.Mapper<EmployeeDTO>(EmpDTO);
            Console.ReadKey();
        }
    }
}