using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFMigration
{

    public class WebContext : DbContext
    {
        public DbSet<Article> articles { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<ArticleTag> articleTags { get; set; }
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });

        private const string connectionString = @"
                Data Source=VINH_PC;
                Initial Catalog=webdb;
                Integrated Security=True;
                TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseLazyLoadingProxies();
            Console.WriteLine("OnConfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(a => new { a.ArticleId, a.TagId })
                    .IsUnique();
            });
        }
    }

}