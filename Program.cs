// Entity -> Database, table
// Database - SQL Server: data01 -> DbContext
// -- product
using EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

static void CreateDatabase()
{
    using var dbcontext = new ShopContext();
    string dbname = dbcontext.Database.GetDbConnection().Database;
    var result = dbcontext.Database.EnsureCreated();
    if (result)
    {
        Console.WriteLine($"Database {dbname} create successfully!");
    }
    else
    {
        Console.WriteLine($"Database {dbname} create failed!");
    }
    //Console.WriteLine(dbname);
}
static void DropDatabase()
{
    using var dbcontext = new ShopContext();
    string dbname = dbcontext.Database.GetDbConnection().Database;
    var result = dbcontext.Database.EnsureDeleted();
    if (result)
    {
        Console.WriteLine($"Database {dbname} delete successfully!");
    }
    else
    {
        Console.WriteLine($"Database {dbname} delete failed!");
    }
    //Console.WriteLine(dbname);
}
static void InsertData()
{
    using var dbContext = new ShopContext();
    // Add Categories
    // Category[] c = new Category[]{
    //     new Category() {Name = "Dien thoai", Description="Cac loai dien thoai"},
    //     new Category() {Name = "Do uong", Description="Cac loai do uong"}
    // };
    // dbContext.categories.AddRange(c);
    Category c1 = new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" };
    Category c2 = new Category() { Name = "Do uong", Description = "Cac loai do uong" };
    dbContext.Add(c1);
    dbContext.Add(c2);
    // var c1 = (from c in dbContext.categories where c.CategoryID == 1 select c).FirstOrDefault();
    // Category? c2 = (from c in dbContext.categories where c.CategoryID == 2 select c).FirstOrDefault();
    // Add Products
    Product[] p = new Product[]{
        new Product(){Name="Iphone 8", Price=1000, CateId=1},
        new Product(){Name="Samsung", Price=900, CateId=1},
        new Product(){Name="Ruou vang Abc", Price=500, Category=c2},
        new Product(){Name="Nokia", Price=600, Category=c1},
        new Product(){Name="Cafe ABC", Price=100, CateId = 2},
        new Product(){Name="Nuoc ngot", Price=100, Category = c2},
        new Product(){Name="Bia", Price=100, CateId = 2}
    };
    dbContext.products.AddRange(p);
    int result = dbContext.SaveChanges();
    if (result != 0)
    {
        Console.WriteLine("Ok");
    }
    else
    {
        Console.WriteLine("Fail");
    }
}

// DropDatabase();
// CreateDatabase();

// InsertData();
using var dbContext = new ShopContext();
//
// var product = (from p in dbContext.products where p.ProductID == 3 select p).FirstOrDefault();
// var e = dbContext.Entry(product);
// e.Reference(p => p.Category).Load();
// if (product != null)
// {
//     product.PrintInfo();
// }
// if (product.Category != null)
// {
//     Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
//  }
// else Console.WriteLine("Category == null");
//
// var category = (from c in dbContext.categories where c.CategoryID == 2 select c).FirstOrDefault();
// if (category != null)
// {
//     Console.WriteLine($"{category.CategoryID} - {category.Name}");
// }
// if (category.Products != null)
// {
//     Console.WriteLine($"So san pham: {category.Products.Count()}");
//     category.Products.ForEach(p => p.PrintInfo());
// }
// else Console.WriteLine("Products == null");

// // Linq
// // Find(pk)
// var p = dbContext.products.Find(6);
// p.PrintInfo();
// price > 500
// var products = from p in dbContext.products
//                where p.Price >= 500
//                select p;
// products.ToList().ForEach(p => p.PrintInfo());
// //
// var products = from p in dbContext.products
//                where p.Name.Contains("i")
//                orderby p.Price descending
//                select p;
// products.Take(2).ToList().ForEach(p => p.PrintInfo());
//
var qr = from p in dbContext.products
         join c in dbContext.categories on p.CateId equals c.CategoryID
         select new
         {
             Ten = p.Name,
             Danhmuc = c.Name,
             Gia = p.Price
         };
qr.ToList().ForEach(p => Console.WriteLine(p));