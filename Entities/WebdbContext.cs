using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFcore.Entities;

public partial class WebdbContext : DbContext
{
    public WebdbContext()
    {
    }

    public WebdbContext(DbContextOptions<WebdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleTag> ArticleTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VINH_PC;Initial Catalog=webdb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("article");

            entity.Property(e => e.Content)
                .HasDefaultValueSql("(N'')")
                .HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ArticleTag>(entity =>
        {
            entity.ToTable("articleTags");

            entity.HasIndex(e => new { e.ArticleId, e.TagId }, "IX_articleTags_ArticleId_TagId").IsUnique();

            entity.HasIndex(e => e.TagId, "IX_articleTags_TagId");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleTags).HasForeignKey(d => d.ArticleId);

            entity.HasOne(d => d.Tag).WithMany(p => p.ArticleTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tags");

            entity.Property(e => e.Content).HasColumnType("ntext");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
