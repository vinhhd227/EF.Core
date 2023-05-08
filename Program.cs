// Entity -> Database, table
// Database - SQL Server: data01 -> DbContext
// -- product
using EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

static void CreateDatabase()
{
    using var dbcontext = new ProductDbContext();
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
    using var dbcontext = new ProductDbContext();
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
static void InsertProduct()
{
    using var dbcontext = new ProductDbContext();
    /*
    - Model (Product)
    - Add, AddAsync
    - SaveChange
    */
    // var p1 = new Product();
    // p1.ProductName = "Product 1";
    // p1.Provider = "Provider 1";
    // dbcontext.Add(p1);
    // var p2 = new Product()
    // {
    //     ProductName = "Product 2",
    //     Provider = "Provider 2"
    // };
    // dbcontext.Add(p2);
    var products = new object[]{
        new Product(){ProductName="Product 3", Provider="Provider 3"},
        new Product(){ProductName="Product 4", Provider="Provider 4"}
    };
    dbcontext.AddRange(products);
    int number_rows = dbcontext.SaveChanges();
    Console.WriteLine($"{number_rows} row add successfully!");
}
static void ReadProduct()
{
    using var dbcontext = new ProductDbContext();
    // Select all
    // var products = dbcontext.products.ToList();
    // products.ForEach(product => product.PrintInfo());
    // Linq
    var qr = from product in dbcontext.products
             where product.ProductID >= 2
             select product;
    qr.ToList().ForEach(product => product.PrintInfo());
    //
    Product p = (from product in dbcontext.products
                 where product.ProductID == 1
                 select product).FirstOrDefault();
    if (p != null)
    {
        p.PrintInfo();
    }
}
static void RenameProduct(int id, string newName)
{
    using var dbcontext = new ProductDbContext();
    Product p = (from product in dbcontext.products
                 where product.ProductID == id
                 select product).FirstOrDefault();
    if (p != null)
    {
        //
        EntityEntry<Product> entry = dbcontext.Entry(p);
        entry.State = EntityState.Detached;

        p.ProductName = newName;
        int number_rows = dbcontext.SaveChanges();
        Console.WriteLine($"{number_rows} row update successfully!");
    }
}
static void DeleteProduct(int id)
{
    using var dbcontext = new ProductDbContext();
    Product p = (from product in dbcontext.products
                 where product.ProductID == id
                 select product).FirstOrDefault();
    if (p != null)
    {
        dbcontext.Remove(p);
        int number_rows = dbcontext.SaveChanges();
        Console.WriteLine($"{number_rows} row delete successfully!");
    }
}
// DropDatabase();
// CreateDatabase();

// Insert, Select, Update, Delete -> CRUD
// InsertProduct();
 ReadProduct();
// RenameProduct(1, "San pham 5");
// DeleteProduct(4);

// Logging
