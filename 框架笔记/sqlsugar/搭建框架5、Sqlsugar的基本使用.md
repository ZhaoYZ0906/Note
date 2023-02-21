# Sqlsugar的基本使用

[TOC]



### 1、DbContext与数据库连接

##### 1.1 使用nuget安装SqlSugarCore包

##### 1.2新增DbContext类型，并编写一下代码

```
	public class DbContext2
    {
        // 数据库连接字符串
        public static string _connectionString { get; set; }
        // 数据库类型
        private static DbType _dbType;
        // 数据库操作实例
        private SqlSugarClient _db;

        /// <summary>
        /// 构造函数：只能通过GetDbContext创建新对象
        /// </summary>
        /// <param name="blnIsAutoCloseConnection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private DbContext2(bool blnIsAutoCloseConnection=true)
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException("数据库连接字符串为空");
            _db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = _dbType,
                IsAutoCloseConnection = blnIsAutoCloseConnection
            });
        }

        /// <summary>
        /// 创建指定实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sugarClient"></param>
        /// <returns></returns>
        public SimpleClient<T> GetCustomEntityDB<T>(ConnectionConfig config) where T : class, new()
        {
            SqlSugarClient sugarClient = GetSqlSugarClient(config);
            return GetEntityDB<T>(sugarClient);
        }

        /// <summary>
        /// 创建指定实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sugarClient"></param>
        /// <returns></returns>
        public SimpleClient<T> GetEntityDB<T>(SqlSugarClient sugarClient) where T : class, new()
        {
            return new SimpleClient<T>(sugarClient);
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        public void CreateDataBase()
        {
            _db.DbMaintenance.CreateDatabase();
        }

        /// <summary>
        /// 根据实体类型创建对应的数据库表
        /// </summary>
        /// <param name="blnBackupTable"></param>
        /// <param name="lstEntitys"></param>
        public void CreateTableByEntity(bool blnBackupTable, params Type[] lstEntitys)
        {
            if (blnBackupTable)
            {
                _db.CodeFirst.BackupTable().InitTables(lstEntitys); //change entity backupTable            
            }
            else
            {
                _db.CodeFirst.InitTables(lstEntitys);
            }
        }

        #region 数据库操作对象相关操作

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="strConnectionString"></param>
        /// <param name="enmDbType"></param>
        public static void Init(string strConnectionString, DbType enmDbType = SqlSugar.DbType.SqlServer)
        {
            _connectionString = strConnectionString;
            _dbType = enmDbType;
        }

        /// <summary>
        /// 构建一个上下文
        /// </summary>
        /// <param name="blnIsAutoCloseConnection"></param>
        /// <returns></returns>
        public static DbContext2 GetDbContext(bool blnIsAutoCloseConnection = true)
        {
            return new DbContext2(blnIsAutoCloseConnection);
        }

        /// <summary>
        /// 创建连接配置
        /// </summary>
        /// <param name="blnIsAutoCloseConnection"></param>
        /// <param name="blnIsShardSameThread"></param>
        /// <returns></returns>
        public static ConnectionConfig GetConnectionConfig(bool blnIsAutoCloseConnection = true, bool blnIsShardSameThread = false)
        {
            ConnectionConfig config = new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = _dbType,
                IsAutoCloseConnection = blnIsAutoCloseConnection,                
            };
            return config;
        }

        /// <summary>
        /// 创建数据库客户端
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static SqlSugarClient GetSqlSugarClient(ConnectionConfig config)
        {
            return new SqlSugarClient(config);
        }        

        #endregion
    }
```

使用方法：

```
// 配置连接字符串			
DbContext.Init("连接字符串");
// 获取上下文实例
DbContext context = DbContext.GetDbContext();
// 获取数据库操作对象
SqlSugarClient db = context._db;        
// 获取实体对象
entityDB = context.GetEntityDB<Advertisement>(db);
```

注：此写法参照：[从壹开始前后端分离【 .NETCore3.1 +Vue 2 +AOP+DI】框架之一 || 前言 - 老张的哲学 - 博客园 (cnblogs.com)](https://www.cnblogs.com/laozhang-is-phi/p/9495618.html#autoid-1-0-0)

总结： 个人认为此写法中的DbContext的主要作用是管理SqlSugarClient，所以叫做SqlSugarClientManage更加合适。SqlSugarClient是数据库的对象，主要负责连接、配置、数据库迁移等；SimpleClient<T>()是数据库表的操作对象。

##### 1.3 DbContext在Sugar与EF中的对比

Sugar中DbContext更像一个SqlSugarClient管理器，可根据自己代码情况决定写与不写，如果不写直接操作SqlSugarClient即可；

EF中DbContext简单理解为数据库对象，其作用与SqlSugarClient类似，通过该对象操作数据库。

### 2、CodeFirst建库、建表、主键、外键、字段约束、索引

##### 2.1  建库、建表

```
// 根据实体对象创建数据库
db.DbMaintenance.CreateDatabase();

// 根据type类型或命名空间创建数据库表
db.CodeFirst.InitTables(typeof(CodeFirstTable1));
db.CodeFirst.InitTables(params Type[] entityTypes)
db.CodeFirst.InitTables(string entitiesNamespace);
db.CodeFirst.InitTables(string[] entitiesNamespaces);
```

##### 2.2 主键、外键

```
// 主键与自增长
[SugarColumn(IsIdentity = true, IsPrimaryKey = true)]

//外键参照：https://www.donet5.com/home/doc?masterId=1&typeId=1188
```



##### 2.3 字段约束

```
[SugarColumn(ColumnDataType = "Nvarchar(255)")]//custom
[SugarColumn(IsNullable = true)]
```



##### 2.4 索引

```
	//普通索引
    [SugarIndex("index_codetable1_name",nameof(CodeFirstTable1.Name),OrderByType.Asc)]
      
    //唯一索引 (true表示唯一索引)
    [SugarIndex("unique_codetable1_CreateTime", nameof(CodeFirstTable1.CreateTime), OrderByType.Desc,true)]
      
    //复合普通索引
    [SugarIndex("index_codetable1_nameid", nameof(CodeFirstTable1.Name), OrderByType.Asc,
                        nameof(CodeFirstTable1.Id),    OrderByType.Desc)]
```



### 3、增删查改

请参照官网[SqlSugar ORM 5.X 官网 、文档、教程 - SqlSugar 5x - .NET果糖网 (donet5.com)](https://www.donet5.com/Home/Doc)

### 4、其他

关于SqlSugarClient与SimpleClient<T>的思考：初步认为SimpleClient只能针对一张表进行操作；SqlSugarClient随时可切换为指定表。

当某个服务对表的操作逻辑相对简单时使用SimpleClient代码逻辑更加清晰。

[各种数据库的连接字符串 - 微澜 - 博客园 (cnblogs.com)](https://www.cnblogs.com/liubo68/archive/2012/12/28/2836777.html)



