using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class CreditCardDBContext : DbContext
{
    public CreditCardDBContext()
    {
    }

    public CreditCardDBContext(DbContextOptions<CreditCardDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CreditCardDetail> CreditCardDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=CreditCardApplication;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreditCardDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CardCvv).HasColumnName("CardCVV");
            entity.Property(e => e.CardName).HasMaxLength(500);
            entity.Property(e => e.CardNumber).HasMaxLength(500);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.CreditBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("date");
            entity.Property(e => e.VaildFromDateYear).HasColumnType("date");
            entity.Property(e => e.ValidExpiryDateMonth).HasColumnType("date");
            entity.Property(e => e.ValidExpiryDateYear).HasColumnType("date");
            entity.Property(e => e.ValidFromDateMonth).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
