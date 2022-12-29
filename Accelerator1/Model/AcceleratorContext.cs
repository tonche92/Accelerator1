using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Accelerator1.Model;

public partial class AcceleratorContext : DbContext
{
    public AcceleratorContext()
    {
    }

    public AcceleratorContext(DbContextOptions<AcceleratorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UrlRedirection> UrlRedirections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AO4R2AGN; Database=Accelerator;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrlRedirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__urlRedir__3213E83F3A562633");

            entity.ToTable("urlRedirections");

            entity.HasIndex(e => e.ShortUrl, "UQ__urlRedir__476CF7A32A0A0C96").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ShortUrl)
                .HasMaxLength(10)
                .HasColumnName("shortUrl");
            entity.Property(e => e.Website)
                .HasMaxLength(2000)
                .HasColumnName("website");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
