using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFcore
{

    public class ShopContext : DbContext
    {  public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
        builder.AddConsole();
    });
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        private const string connectionString = @"
                Data Source=VINH_PC;
                Initial Catalog=shopdata;
                Integrated Security=True;
                TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseLazyLoadingProxies();
        }
    }

}