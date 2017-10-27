# Handiness
轻型ORM框架，支持Lambda、Linq 、手写SQL以及实体类的自动生成，目前规划了五个适配层以支持Mysql、Oracle、SQL Server、SQLite、Redis（不完全支持）五种数据库、

Handiness ORM 1.0 版本使用示例
/*************定义Model*****************/
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
    /*********************基础的增、删、改、查*************************/

              DbProvider dbProvider = new SQLiteDbProvider("SQLiteDbProvider", @"Data Source=.\test.db;UTF8Encoding=True;");
            Table<Student> table = new Table<Student>(dbProvider);
            CodeTimer.Initialize();

            //Insert
            CodeTimer.Time("Insert Test:", 10, () =>
                  {
                      table.Insert(new Student
                      {
                          Id = Guid.NewGuid().ToString("N"),
                          Age = 21,
                          Name = "WLJ",
                          StudentNo = "0202140216",
                      }).ExecuteNonQuery();
                  });
            CodeTimer.Time("Insert Test:", 10, () =>
            {
                table.Insert(new Student
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Age = 20,
                    Name = "WLJ",
                    StudentNo = "0202140216",
                }).ExecuteNonQuery();
            });

            //Update
            CodeTimer.Time("Update Test:", 1, () =>
            {
                table.
            Update
            (
                () =>
               new Student { Name = "WLJ1" }
            ).
            Where(t => t.Age == 21).
            ExecuteNonQuery();
            });

            //Delete
            CodeTimer.Time("Delete Test:", 1, () =>
              {
                  table.Delete().Where(t => t.Name == "WLJ").ExecuteNonQuery();

              });
            //Select
            CodeTimer.Time("Select Test:", 1, () =>
            {
                List<Student> studentList = table.Select().ExecuteReader().ToList();
                //studentList.ForEach(
                //    (t) =>
                //    {
                //        Console.WriteLine();
                //        Console.WriteLine($"name:{t.Name}");
                //        Console.WriteLine($"id:{t.Id}");
                //        Console.WriteLine();
                //    }
                //    );
            });
