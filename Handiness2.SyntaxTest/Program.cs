using System;
using System.Linq.Expressions;
namespace Handiness2.SyntaxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student { Name = "WLJ", Age = 23 };
            var obj = new { student.Name, student.Age };

            Select<Student>(t => new { student.Name, student.Age });
            Select<Student, Article>((t,t1)=>new { t.Name,t1.Title});
            Console.Read();
        }
        static void Select<T>(Expression<Func<T, Object>> select)
        {
            var exp = select.Body;
        }
        static void Select<T, T2>(Expression<Func<T, T2,Object>> select)
        {
            var exp = select.Body;
        }
    }
    public class Student
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }
    public class Article
    {
        public String Title { get; set; }
        public Int32 Length { get; set; }
    }
}
