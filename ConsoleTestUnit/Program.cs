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

    //public class Student : RowBase
    //{
    //    public String Name
    //    {
    //        get => this._name;
    //        set
    //        {
    //            if (this._name != value)
    //            {
    //                this._name = value;
    //                this.OnNotifyPropertyChanged(nameof(this.Name), value);
    //            }
    //        }
    //    }
    //    private String _name;
    //}
    public class EventSrouce
    {
        public event EventHandler Event;
        public void OnEvent(EventArgs e )
        {
            this.Event(this,e);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EventSrouce srouce = new EventSrouce();
            srouce.Event += (s, e) =>
              {
                  Console.WriteLine(s.ToString());
              };
            //List<Student> query = new List<Student>();
            //Student student = new Student();
            //student.PropertyChanged += (s, p) =>
            //  {
            //      Console.WriteLine(p.PropertyName + "Changed");
            //  };
            // student.Name = "老师";
            // student.NotifyPropertyValue("Name", "学生");
            //Console.WriteLine(student.Name);
            //using (IMetadataProvider provider = MetadataProvider.GetMetadataProvider("#M1"))
            //{
            //    var temp =MetadataProvider.GetMetadataProviders();
            //    Console.WriteLine(temp.GetType().Namespace);
            //    provider.Open("server=192.168.0.108;Port=3306;Uid=root;Pwd=123456;DataBase=handinessOrm;Pooling=true;charset=utf8;");
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
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
    }
}
