namespace DomainLayer
{/// <summary>
/// data from Data layer is Mapped to this layer object
/// </summary>
    public class EmployeeDTO
    {

        public string EmployeeName { get; set; }
        public int IdNumber { get; set; }
        public Address EmpAdress { get; set; }
        
    }
    public class Address
    {
       public string city { get; set; }
        public string location { get; set; }
    }
}