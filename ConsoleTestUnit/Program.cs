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

    public class Student : RowBase
    {

        public String Name
        {
            get => this._name;
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.OnNotifyPropertyChanged(nameof(this.Name), value);
                }
            }
        }
        private String _name = String.Empty;
        public static Boolean operator true(Student student)
        {
            return student.Name != String.Empty;
        }
        public static Boolean operator false(Student student)
        {
            return student.Name == String.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //String path = "d:\\";
            //SchemaBuffer.Save(path,
            //    new SchemaXml
            //    {
            //        Name = "schema",
            //        Tables = new TableSchemaXml[]
            //        {
            //                    new  TableSchemaXml
            //                    {
            //                         Key="Test",
            //                          Schema=new TableSchema
            //                          (
            //                               "test",
            //                               2,new String[]{ "name"},new String[]{ "name","age"},"测试表"
            //                          ),
            //                          Columns=new ColumnSchemaXml[]
            //                          {
            //                             new   ColumnSchemaXml
            //                             {
            //                                  Key="Name",
            //                                  Schema=new ColumnSchema
            //                                  (
            //                                       "Name",true,"varchar",10,false,"test","name"
            //                                      )
            //                             },
            //                                 new   ColumnSchemaXml
            //                             {
            //                                  Key="Age",
            //                                  Schema=new ColumnSchema
            //                                  (
            //                                       "Age",true,"int",4,false,"test","age"
            //                                      )
            //                             }
            //                          }
            //                      }
            //           }

            //    });
            //path = "d:\\schema.xml";
            //var deSer = SchemaBuffer.Load(path);
            //Console.WriteLine(deSer.Count());
            //List<Student> query = new List<Student>();
            //Student student = new Student();
            //student.PropertyChanged += (s, p) =>
            //  {
            //      Console.WriteLine(p.PropertyName + "Changed");
            //  };
            // student.Name = "老师";
            // student.NotifyPropertyValue("Name", "学生");
            //Console.WriteLine(student.Name);
            //  Stopwatch watch = new Stopwatch();
            //  watch.Restart();
            //  IMetadataProvider provider = MetadataProvider.ExportMetadataProvider("41668F3A-DE95-4E1D-8213-0BCAAAA912C6");
            //  watch.Stop();

            //Console.WriteLine(watch.ElapsedMilliseconds);
            //  Console.WriteLine(provider.GetHashCode());
            //  watch.Restart();
            //  provider = MetadataProvider.ExportMetadataProvider("41668F3A-DE95-4E1D-8213-0BCAAAA912C6");
            //  watch.Stop();
            //  Console.WriteLine(watch.ElapsedMilliseconds);
            //  Console.WriteLine(provider.GetHashCode());
            using (IMetadataProvider provider = MetadataProvider.ExportMetadataProvider("41668F3A-DE95-4E1D-8213-0BCAAAA912C6"))
            {
                provider.Open("server=192.168.0.108;Port=3306;Uid=root;Pwd=123456;DataBase=handinessOrm;Pooling=true;charset=utf8;");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var tableSchemas = provider.GetTableSchemas();
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
