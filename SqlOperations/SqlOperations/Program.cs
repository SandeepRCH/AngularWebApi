using System;
namespace SqlOperations
{
    /// <summary>
    /// sql operations on database using a dataset
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter table name");
            string tableName = Console.ReadLine();
            int repeat = 1;
            while (repeat == 1)
            {
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Select");
                Console.WriteLine("3.update");
                Console.WriteLine("4.Delete");
                int choice = Convert.ToInt32(Console.ReadLine());
                DbOperations db = new DbOperations();
                switch (choice)
                {
                    case 1:
                        db.InsertToDb(tableName);
                        break;
                    case 2:
                        db.SelectFromDb(tableName);
                        break;
                    case 3:
                        db.UpdateDb(tableName);
                        break;
                    case 4:
                        db.DeleteFromDb(tableName);
                        break;
                    default:
                        Console.WriteLine("invalid selection");
                        break;
                }
                Console.WriteLine("1:Repeat  0:Stop");
                repeat = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}