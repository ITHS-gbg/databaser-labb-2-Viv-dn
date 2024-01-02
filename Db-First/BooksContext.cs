using System;
using System.Collections.Generic;
using Labb2_DbFirst_Template.Entities;
using Labb2_DbFirst_Template.Entities.ViewsTbl;
using Microsoft.EntityFrameworkCore;

namespace Db_First;

public partial class BooksContext : DbContext
{
   
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }


    public virtual DbSet<AurthorView> AurthorViews { get; set; }

    public virtual DbSet<AuthorTbl> AuthorTbls { get; set; }

    public virtual DbSet<BookTbl> BooksTbls { get; set; }

    public virtual DbSet<CityView> CityViews { get; set; }

    public virtual DbSet<CustomersTbl> CustomersTbls { get; set; }

    public virtual DbSet<Inventory> InventoryTbls { get; set; }

    public virtual DbSet<OrderDetailsTbl> OrderDetailsTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<ShopTbl> ShopsTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LC3CJTC;Initial Catalog=Bokhandel;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AurthorView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AurthorView");

            entity.Property(e => e.AuthorName)
                .HasMaxLength(51)
                .HasColumnName("Author Name");
            entity.Property(e => e.ValueKr).HasColumnName("Value (kr)");
        });

        modelBuilder.Entity<AuthorTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthorTb__3214EC07A6E7D744");

            entity.ToTable("AuthorTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(25);
        });

        modelBuilder.Entity<BookTbl>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__BooksTbl__3BF79E035561384D");

            entity.ToTable("BookTbl");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .HasColumnName("ISBN13");
            entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
            entity.Property(e => e.Awards).HasMaxLength(50);
            entity.Property(e => e.Language).HasMaxLength(25);
            entity.Property(e => e.PriceKr).HasColumnName("Price (kr)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.BooksTbls)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__BooksTbl__Author__2C3393D0");
        });

        modelBuilder.Entity<CityView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CityView");

            entity.Property(e => e.ShipCity).HasMaxLength(20);
        });

        modelBuilder.Entity<CustomersTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07F7387EEA");

            entity.ToTable("CustomersTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.ShopsId).HasColumnName("Shops_ID");

            entity.HasOne(d => d.Shops).WithMany(p => p.CustomersTbls)
                .HasForeignKey(d => d.ShopsId)
                .HasConstraintName("FK__Customers__Shops__3C69FB99");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => new { e.ShopId, e.Isbn13Id });

            entity.ToTable("Inventory");

            entity.Property(e => e.ShopId).HasColumnName("Shop_ID");
            entity.Property(e => e.Isbn13Id)
                .HasMaxLength(13)
                .HasColumnName("ISBN13_ID");

            entity.HasOne(d => d.Isbn13).WithMany(p => p.InventoryTbls)
                .HasForeignKey(d => d.Isbn13Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTbl_ISBN13");

            entity.HasOne(d => d.ShopTbl).WithMany(p => p.InventoryTbls)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryTbl_ShopID");
        });

        modelBuilder.Entity<OrderDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OdTbl");

            entity.ToTable("Order_DetailsTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Isbn13Id)
                .HasMaxLength(13)
                .HasColumnName("ISBN13_ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");

            entity.HasOne(d => d.Isbn13).WithMany(p => p.OrderDetailsTbls)
                .HasForeignKey(d => d.Isbn13Id)
                .HasConstraintName("FK_OdTbl_ISBN13");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetailsTbls)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OdTbl_Order_ID");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdersTb__3214EC07D4123E38");

            entity.ToTable("OrdersTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.ShipCity).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__OrdersTbl__Custo__44FF419A");
        });

        modelBuilder.Entity<ShopTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShopsTbl__3214EC07DEAFA9C8");

            entity.ToTable("ShopTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
