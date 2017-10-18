using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Orm;
namespace Handiness.Orm.Test
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        public String Id { get; set; }
        [Column("name")]
        public String Name { get; set; }
        [Column("age")]
        public Int32 Age { get; set; }
        [Column("student_no")]
        public String StudentNo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DbProvider dbProvider = new SQLiteDbProvider("SQLiteDbProvider", @"Data Source=.\test.db;UTF8Encoding=True;");
            Table<Student> table = new Table<Student>(dbProvider);
            table.Insert(new Student
            {
                Id = Guid.NewGuid().ToString("N"),
                Age = 20,
                Name = "WLJ",
                StudentNo = "0202140216",
            }).ExecuteNonQuery();

            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            List<Student> studentList=table.Select().ExecuteReader().ToList();
            studentList.ForEach(
                (t)=>
                {
                    Console.WriteLine();
                    Console.WriteLine($"name:{t.Name}");
                    Console.WriteLine($"name:{t.Id}");
                    Console.WriteLine();
                }
                );

            Console.ForegroundColor = currentForeColor;
        }
    }
}
