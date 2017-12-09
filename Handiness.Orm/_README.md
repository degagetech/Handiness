# Handiness.Orm

### 2017/11/27 
一个轻型开源ORM框架，用于此项目的ORM是第一版，并经过修改
<b>*Handiness.Orm*</b> 项目地址请移步   https://github.com/WangLangJing/Handiness
<br>以下是一些使用示例
```
    DbProvider provider = new DbProvider("SQLSERVERS", "Data Source = 117.48.197.78; Uid = biobank; Pwd = 932444208; Initial Catalog = biobank;");
    Table<PatientInfo> patientInfoTable = new Table<PatientInfo>(provider);
    //查
    patientInfoTable.Select().ExecuteReader().ToList().FirstOrDefault().Birthday.ToString();
    patientInfoTable.Insert(new PatientInfo
    {
        Id = GuidMaker.Guid,
        Birthday = DateTime.Now
    }).ExecuteNonQuery();
    Table<PermisUser> userTable = new Table<PermisUser>(provider);
    //增
   userTable.Insert(new PermisUser
    {
        Id = GuidMaker.Guid,
        Name = "wlj"
    }).ExecuteNonQuery();
   //改
   userTable.Update(() => new PermisUser
    {
        Disable = true
    }).Where(t => t.Name == "wlj").ExecuteNonQuery();
	 //删
	 userTable.Delete().ExecuteNonQuery();
   
   //也可使用传统SQL执行查询等操作
   userTable.Query<TModel>("SELECT * FROM  tableName ...")
   userTable.Execute("INSERT INTO tableName ...");
   //事务执行器
    var driver=userTable.Delete();
    var driver1=userTable.Update(...)
    var exexcutor=provider.TransactionExecutor();
    exexcutor.Push(driver.SQLComponent);
    exexcutor.Push(driver1.SQLComponent)
    exexcutor.Execute();
```

***
### 框架异常反馈
* 请联系王浪静 QQ：*932444208*