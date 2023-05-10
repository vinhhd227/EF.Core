// Entity -> Database, table
// Database - SQL Server: data01 -> DbContext
// -- product
using EFMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

/*

dotnet ef migrations add MigrationName              // Tạo Migration có tên MigrationName
dotnet ef migrations list                           // Xem danh sách Migration
dotnet ef migrations remove                         // Xóa Migration cuối cùng
dotnet ef migrations script                         // Xem các câu truy vấn
dotnet ef migrations script -o name.sql             // Xuất câu truy vấn
dotnet ef migrations script name1 name2             // Xem câu truy vấn từ name1 sang name 2
dotnet ef database update (MigrationName)           // Cập nhật lên database
dotnet ef database drop -f                          // Xóa database
Data Source=VINH_PC;Initial Catalog=webdb;Integrated Security=True;TrustServerCertificate=True;
dotnet ef dbcontext scaffold -o Entities -d "Data Source=VINH_PC;Initial Catalog=webdb;Integrated Security=True;TrustServerCertificate=True;" "Microsoft.EntityFrameworkCore.SqlServer" 
*/
Console.WriteLine("Done");

