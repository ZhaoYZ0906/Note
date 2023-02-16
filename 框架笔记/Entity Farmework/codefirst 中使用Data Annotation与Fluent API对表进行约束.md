## codefirst 中使用Data Annotation与Fluent API对表进行约束

> Data Annotation使用Attribute形式表现；Fluent API为一组方法，在DbContext中重写OnModelCreating方法时使用对表关系、列关系进行约束



### 两者所在的命名空间

1. Data Annotation:  *using` `System.ComponentModel.DataAnnotations.Schema; using` `System.ComponentModel.DataAnnotations;*

2. Fluent API:  *using` `System.Data.Entity;* 

   

Data Annotation 可参照：[Code First 数据注释 - EF6 | Microsoft Docs](https://docs.microsoft.com/zh-cn/ef/ef6/modeling/code-first/data-annotations)

Fluent API 可参照：[Fluent API - 关系 - EF6 | Microsoft Docs](https://docs.microsoft.com/zh-cn/ef/ef6/modeling/code-first/fluent/relationships)



### 两者常见的使用形式

#### 类指定表名 

```c#
[Table("Product")]
public class Product

[Table("Product", Schema = "dbo")]
public class Product
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().ToTable("Product");
}
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().ToTable("Product", "dbo");
}
```

#### 类指定字段名、长度、必填

```
[MaxLength(100)]
[Column("ProductName")]
[Required]
public string ProductName { get; set; }
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().Property(t => t.ProductName)
        .IsRequired()
        .HasColumnName("ProductName")　　 
        .HasMaxLength(100);
}
```



#### 类指定数据库列类型

```
[Column("UnitPrice", TypeName = "MONEY")]
public decimal UnitPrice { get; set; }
```

```
modelBuilder.Entity<Product>().Property(t => t.UnitPrice)
    .HasColumnName("UnitPrice")
    .HasColumnType("MONEY");
```



#### 类指定主键

> 属性名为[ID]或[类名 + ID]。如在Product类中，Entity Framework Code First会根据默认约定将类中名称为ID或ProductID的属性设置为主键。Entity Framework Code First主键的默认约定也一样可以进行重写，重新根据需要进行设置。

```
// 为组合键的各个列批注指定顺序，顺序值是相对的（而不是基于索引的），因此可以使用任何值。 例如，100和200可接受而不是1和2。
// 如果不指定顺序则：尝试在 EF 模型中使用以上类将导致 InvalidOperationException：无法确定类型 "Passport" 的组合键。使用 ColumnAttribute 或 HasKey 方法为组合主键指定顺序。
[Key]
[Column(Order=1)]
public int PassportNumber { get; set; }
[Key]
[Column(Order = 2)]
public string IssuingCountry { get; set; }
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().HasKey(t => new { t.KeyID, t.CandidateID });
}
```



#### 类指定主键自增长与取消自增长

> 　Entity Framework Code First对于int类型的主键，会自动的设置其为自动增长列。

```
[Key]
[Column("ProductID")]
[DatabaseGenerated(DatabaseGeneratedOption.None)]
public int ProductID { get; set; }

[Key]
[Column("CategoryID")]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public int CategoryID { get; set; }
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().HasKey(t => t.ProductID);
    modelBuilder.Entity<Product>().Property(t => t.ProductID)
        .HasColumnName("ProductID")
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
}

protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Category>().ToTable("Category", "dbo");
    modelBuilder.Entity<Category>().HasKey(t => t.CategoryID);
    modelBuilder.Entity<Category>().Property(t => t.CategoryID)
        .HasColumnName("CategoryID")
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
}
```



#### 类指定数字类型长度及精度

Data Annotation暂时未找到此方式

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().Property(t => t.UnitPrice)
        .HasColumnName("UnitPrice")
        .HasPrecision(18, 2);//保留两位小数
}
```

 

#### 类指定非数据库字段属性

>在类中，如果有一些属性不需要映射到对应生成的数据表中，可以通过以下方式设置。一般用于计算列等不需要存储的情况。

```
[NotMapped]
public string Remark { get; set; }
```

```
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>().Ignore(t => t.Remark);
}
```

#### 类指定索引

```
// 多列索引
[Index("IX_BlogIdAndRating", 2)]
public int Rating { get; set; }
[Index("IX_BlogIdAndRating", 1)]
public int BlogId { get; set; }
```

```
未找对应方法，感觉以上足够方便
```

#### 外键

```
外键关系参照：https://docs.microsoft.com/zh-cn/ef/ef6/modeling/code-first/fluent/relationships
可参照 Note/框架笔记/Entity Farmework/ef设定表关系.txt 后续两个文件整合
```



