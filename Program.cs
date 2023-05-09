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
// using var context = new ShopContext();
// using (var context = new ShopContext ()) {
//     var products = context.products;
//     // var products = await context.products.ToListAsync (); nếu muốn dùng async
//     foreach (var pro in products) {
//         Console.WriteLine (pro.Name);
//     }
// }

// var products = context.products
//                 .Where(p => p.Price > 100)              // Lọc các sản phẩm giá trên 100
//                 .OrderByDescending(p => p.Price)        // Sắp xếp giảm dần, tăng dần là OrderBy
//                 .Take(2);                               // Chỉ lấy 2 dòng đầu
// foreach (var pro in products)
// {
//     Console.WriteLine(pro.Name);
// }

// Tìm sản phẩm có ID bằng 6
// var product = await context.products.FindAsync(6);
// if (product !=  null)
//     Console.WriteLine($"{product.Name}");

// using (var context = new ShopContext())
// {
//     // Sản phẩm đầu tiên scó giá trên 100, bắt đầu bằng chữ S
//     var product = await context.products.FirstOrDefaultAsync(p => (p.Price > 100 && p.Name.StartsWith("S")));
//     if (product !=  null)
//         Console.WriteLine($"{product.Name}");
// }

// var products = await (from p in context.products select p).ToListAsync();
// foreach (var pro in products)
// {
//     Console.WriteLine(pro.Name);
// }

// using (var context = new ShopContext())
// {
//     var products =  (from p in context.products
//                           select p)
//                          .ToAsyncEnumerable();

//     await products.ForEachAsync(
//         p =>
//         {
//             Console.WriteLine($"{p.Name} - {p.Price}");
//         }
//     );
// }

// // Truy vấn lấy các sản phẩm (tên, giá) và tên danh mục của sản phẩm
// var products
//     = from p in context.products
//       join c in context.categories on p.CategoryId equals c.CategoryId
//       // where p.ProductId == 2
//       select new {
//           tensanpham = p.Name,
//           gia = p.Price,
//           danhmuc = c.Name
//       };



// foreach (var item in products)
// {
//    Console.WriteLine($"{item.tensanpham} giá {item.gia} danh mục {item.danhmuc}");
// }

// var products
//     = from p in context.products
//       join c in context.categories on p.CategorySecondId equals c.CategoryId
//       // where p.ProductId == 2
//       select new {
//           tensanpham = p.Name,
//           gia = p.Price,
//           danhmuc = c.Name
//       };



// foreach (var item in products)
// {
//    Console.WriteLine($"{item.tensanpham} giá {item.gia} danh mục {item.danhmuc}");
// }
// // Sản phẩm 2 giá 11.0000 danh mục Cate2
// // Sản phẩm 5(1) giá 333.0000 danh mục Cate2

// // Thi hành DefaultIfEmpty() trên tập kết quả right của Join để thực hiện left join
//  var products
//     = from p in context.products
//       join c in context.categories on p.CategorySecondId equals c.CategoryId into t
//       from cate2 in t.DefaultIfEmpty()
//       // where p.ProductId == 2
//       select new {
//           tensanpham = p.Name,
//           gia = p.Price,
//           danhmuc = (cate2 == null) ? "KHÔNG CÓ" : cate2.Name
//       };


// foreach (var item in products)
// {
//    Console.WriteLine($"{item.tensanpham} giá {item.gia} danh mục {item.danhmuc}");
// }
// // Sản phẩm 4(1) giá 323.0000 danh mục KHÔNG CÓ
// // Sản phẩm 3 giá 33.0000 danh mục KHÔNG CÓ
// // Sản phẩm 2 giá 11.0000 danh mục Cate2
// // Sản phẩm 1 giá 12.0000 danh mục KHÔNG CÓ
// // Sản phẩm 5(1) giá 333.0000 danh mục Cate2

// using (var context = new ShopContext ()) {
//     String sql = "select * from products order by Price Desc";
//     var products = context.products.FromSqlRaw(sql);

//     await products.ForEachAsync(p => {
//         Console.WriteLine(p.Name);
//     });
// }

// var products = await (from p in context.products
//                where EF.Functions.Like(p.Name, "%phẩm%")
//                select p)
//                .ToListAsync();