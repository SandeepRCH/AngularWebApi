namespace DataLayer
{/// <summary>
/// data is sent via object of this class 
/// To map with Domain Layer
/// </summary>
    public class EmployeeData
    {
        public string EmployeeName { get; set; }
        public int IdNumber { get; set; }
        public  Address EmpAdress { get; set; }

    }
    public class Address
    {
        public string city { get; set; }
        public string location { get; set; }
        
    }
}