using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Handiness;
using System.Diagnostics;
using Handiness.Metadata;
using Handiness.CodeBuild;
using Handiness.Services;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.IO;
namespace ConsoleTestUnit
{
    #region 实体类样例
    //public class Student : RowBase
    //{
    //    private String _name;
    //    private Int32 _age;
    //    public String Name
    //    {
    //        get => this._name;
    //        set
    //        {
    //            if (this._name.Equals(value))
    //            {
    //                this._name = value;
    //                this.OnNotifyPropertyChanged(nameof(this.Name), value);
    //            }
    //        }
    //    }
    //    public Int32 Age
    //    {
    //        get => this._age;
    //        set
    //        {
    //            if (this._age.Equals(value))
    //            {
    //                this._age = value;
    //                this.OnNotifyPropertyChanged(nameof(this.Age), value);
    //            }
    //        }
    //    }
    //    protected override void SetPropertyValue(String propertyName, Object newValue)
    //    {
    //        switch (propertyName)
    //        {
    //            case nameof(this.Name):
    //                {
    //                    this.Name = (String)newValue;
    //                }
    //                return;
    //            case nameof(this.Age):
    //                {
    //                    this.Age = (Int32)newValue;
    //                }
    //                return;
    //            default: break;
    //        }
    //    }
    //}
    //public class A
    //{
    //    [MethodImpl]
    //    public virtual void Testc()
    //    {
    //        Console.WriteLine("A");
    //    }
    //}
    //public class B : A
    //{
    //    public override void Testc()
    //    {
    //        Console.WriteLine("B");
    //    }
    //}
    #endregion
    class Program
    {
        static void TimerCallBack(Object state)
        {
            Console.WriteLine("GC");
            GC.Collect();
        }
        #region
        [MTAThread]
        static void Main(string[] args)
        {
            var schemas = SchemaManager.Load("SchemaExample.schema");
            TableSchemaXml schemaXml = schemas.First().Tables.First();
            List<ColumnSchema> colSchemas = new List<ColumnSchema>();
            foreach (var colXml in schemaXml.Columns)
            {
                colSchemas.Add(colXml.Schema);
            }
            IEnumerable<ColumnSchema> temp = colSchemas as IEnumerable<ColumnSchema>;
            CodeTemplateXml codeTemplateXml = TKXmlSerializer.DeSerialize<CodeTemplateXml>("CodeTemplate.ct");
            IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> schemaList = new List<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)>
            {
                (schemaXml.Schema, temp)
            };

            String savePath = @"D:\CodeGenerateTest\";
            CodeBuilder codeBuilder = new CodeBuilder(schemaList, codeTemplateXml,
                new TypeMapper("TypeMapperExample.mc"), null, "Test"
                );
            var codeTuples = codeBuilder.Building();
            if(Directory.Exists(savePath)) Directory.Delete(savePath, true);
            Directory.CreateDirectory(savePath);

            foreach (var codeTuple in codeTuples)
            {
                String filePath = savePath + codeTuple.Name;
                using (Stream stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(codeTuple.Code);
                    writer.Flush();
                }
            }

            //String test = "$classname$,$classnamet$";
            //Regex extract = new Regex(@"(?<=\$)\w+(?=\$)");
            // var temp = extract.Matches(test);
            //Console.WriteLine();
            //foreach (Match match in extract.Matches(test))
            //{
            //    Console.WriteLine(match.Value.ToLower());
            //}
            //Timer t = new Timer(TimerCallBack,null,0,2000);
            //Console.ReadLine();
            //  String path = "TypeMapperExample.mapcode";
            //  TypeMapper mapper = new TypeMapper(path);
            //Console.WriteLine(mapper.Mapping("int",4));
            //int a = 0;
            //Stopwatch watch = new Stopwatch();
            //SchemaManager buffer = new SchemaManager(null, path);
            //ColumnSchema schema = buffer.GetColumnSchema("Age");
            //watch.Start();
            //String name = null;
            //for (int i = 0;
            //i < 10000; ++i)
            //{
            //    name = nameof(SchemaManager.Load);

            //}
            //Console.WriteLine(name);
            ////   buffer.GetColumnSchema("Age");
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedMilliseconds);
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
            //using (IMetadataProvider provider = MetadataProvider.ExportMetadataProvider("41668F3A-DE95-4E1D-8213-0BCAAAA912C6"))
            //{
            //    provider.Open("server=192.168.0.108;Port=3306;Uid=root;Pwd=123456;DataBase=handinessOrm;Pooling=true;charset=utf8;");
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
            //    var tableSchemas = provider.GetTableSchemas();
            //    IList<ColumnSchema> schemas = provider.GetColumnSchemas("personal");
            //    watch.Stop();
            //    Console.WriteLine("1:" + watch.ElapsedMilliseconds);
            //    watch.Restart();
            //    IList<ColumnSchema> schemas1 = provider.GetColumnSchemas("happy");
            //    watch.Stop();
            //    Console.WriteLine("2:" + watch.ElapsedMilliseconds);
            //    Int32 i = 0;
            //}
        }
        #endregion
    }
}
