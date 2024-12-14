using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CreditCard.Models;

public partial class CreditCardDbContext : DbContext
{
    public CreditCardDbContext()
    {
    }

    public CreditCardDbContext(DbContextOptions<CreditCardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=JNPREDATOR;Initial Catalog=CreditCardDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CreditCa__3214EC072143E3B2");

            entity.HasIndex(e => e.CardNumber, "IX_CreditCards_CardNumber");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CardNumber).HasMaxLength(16);
            entity.Property(e => e.CardholderName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Cvv).HasColumnName("CVV");
            entity.Property(e => e.ExpiryDate).HasMaxLength(5);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
