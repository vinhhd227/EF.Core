using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFcore
{

    public class ProductDbContext : DbContext
    {  public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
        builder.AddConsole();
    });
        public DbSet<Product> products { get; set; }
        private const string connectionString = @"
                Data Source=VINH_PC;
                Initial Catalog=data01;
                Integrated Security=True;
                TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}