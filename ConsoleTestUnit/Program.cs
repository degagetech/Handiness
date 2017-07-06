using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Handiness;
using System.Diagnostics;
using Handiness.Metadata;
namespace ConsoleTestUnit
{
    class Student
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> query = new List<Student>();
   
            using (IMetadataProvider provider = MetadataProvider.GetMetadataProvider("#M1"))
            {
                var temp =MetadataProvider.GetMetadataProviders();
                Console.WriteLine(temp.GetType().Namespace);
                provider.Open("server=192.168.0.108;Port=3306;Uid=root;Pwd=123456;DataBase=handinessOrm;Pooling=true;charset=utf8;");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                IList<ColumnSchema> schemas = provider.GetColumnSchemas("personal");
                watch.Stop();
                Console.WriteLine("1:" + watch.ElapsedMilliseconds);
                watch.Restart();
                IList<ColumnSchema> schemas1 = provider.GetColumnSchemas("happy");
                watch.Stop();
                Console.WriteLine("2:" + watch.ElapsedMilliseconds);
                Int32 i = 0;
            }

        }
    }
}
