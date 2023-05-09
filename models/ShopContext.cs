using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFcore
{

    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryDetail> categoryDetails { get; set; }
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
            Console.WriteLine("OnConfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            /*
            var entity = modelBuilder.Entity(typeof(Product));
            // entity => Fluent API - Product
            */
            /*
            var entity = modelBuilder.Entity<Product>();
            */

            modelBuilder.Entity<Product>(entity =>
            {
                //entity => Fluent API
                //Table mapping
                entity.ToTable("Sanpham");
                //Pk
                entity.HasKey(p => p.ProductID);
                //Index
                entity.HasIndex(p => p.Price)
                    .HasDatabaseName("index-sanpham-price");
                // Relative
                entity.HasOne(p => p.Category)
                    .WithMany()                         // Category khong co property ~ sanpham
                    .HasForeignKey("CateId")            // Dat ten Fk
                    .OnDelete(DeleteBehavior.Cascade)   // Cascade, NoAction, set Null
                    .HasConstraintName("Fk-sanpham-category");

                entity.HasOne(p => p.Category2)
                    .WithMany(c => c.Products)    // Colect navigator
                    .HasForeignKey("CateId2")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.Property(p => p.Name)
                    .HasColumnName("Title")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(60)
                    .IsRequired(true);

                entity.Property(p => p.Price)
                    .HasColumnType("money")
                    .HasDefaultValue(0);
            });
            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasOne(c => c.Category)
                    .WithOne(cd => cd.CategoryDetail)
                    .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            Console.WriteLine("OnModelCreating");
        }
    }

}