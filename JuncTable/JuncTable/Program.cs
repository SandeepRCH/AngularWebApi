namespace JuncTable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SandeepDBEntities db=new SandeepDBEntities())
            {
                Courses cou = new Courses();
                cou.CourseId = 5200;
                Employee emp = new Employee();
                emp.EmployeeId = 545;
                emp.Name = "sandeep";
                db.Courses.Add(cou);
                cou.Employee.Add(emp);
                db.SaveChanges();
            }
        }
    }
}