


#### 实体类的定义
<code>
    //正常情况下附加特性以说明数据库结构信息
    [Table("permis_group_user")]
    public class PermisGroupUser
    {
        [Column("user_id")]
        public String UserId { set; get; }

        [Column("group_id")]
        public String GroupId { set; get; }


        [Column("disable")]
        public Boolean Disable { set; get; }
    }
    //若无特性信息说明 ORM框架则会根据类名、属性推导出表名、列名
    //根据类名推导表名 permis_group
    public class PermisGroup
    {
        //根据属性名推导列名 id
        public String Id { set; get; }
        public String Name { set; get; }
        public String Description { set; get; }
        public Boolean Disable { set; get; }
        public String Backup { set; get; }
    }
  </code>
          
  
   #### 调用代码
   <br>
         <code>
         
            DbProvider provider = new DbProvider("SQL Server", config.MainDbConnectionString);
            Table<PermisGroup> groupTable = new Table<PermisGroup>(provider);
            List<PermisGroup> groupInfos = null;
            
            //select 
            groupInfos = groupTable.Select().ExecuteReader().ToList();
            IDriver<PermisGroup> driver = groupTable.Select().Where(t => t.Id == "XXX");
            Console.WriteLine(driver.SQLComponent.SQL);
            //SELECT permis_group.[id] , permis_group.[name] , permis_group.[description] , permis_group.[disable] , permis_group.                   //[backup] FROM permis_group WHERE(permis_group.[id] = @id1)
            
            <br/>
            groupInfos = driver.ExecuteReader().ToList();
            groupInfos = groupTable.Query<PermisGroup>("SELECT * FROM permis_group_user");

            groupInfos = groupTable.
                Select().
                JoinOn<PermisGroupUser>((tg, tgu) => tg.Id == tgu.GroupId).
                Where(t => t.Id == "XXX").
                OrWhere(t => t.Name == "XXX").
                OrIn(t => t.Id, new String[] { "x", "x", "x" }).
                ExecuteReader().
                ToList();
            //...

            //Insert
            Int32 effect = groupTable.Insert(new PermisGroup
            {
                Id = "xx",
                Name = "xx",
            }).ExecuteNonQuery();
            effect = groupTable.Execute("INSERT INTO xxx(id) VALUES(@xxx)", provider.DbParameter("@xxx", "xxxValue"));

            //update

            effect = groupTable.Update(() => new PermisGroup
            {
                Name = "NewName"
            }).Where(t => t.Id == "id").ExecuteNonQuery();

            //delete
            effect = groupTable.Delete().Where(t => t.Id == "xxx").ExecuteNonQuery();

            //where like
            effect = groupTable.Delete().Where(t => t.Id.Like("*xxx*")).ExecuteNonQuery();
            </code>
