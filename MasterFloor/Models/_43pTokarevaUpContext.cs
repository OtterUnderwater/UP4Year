using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterFloor.Models;

public partial class _43pTokarevaUpContext : DbContext
{
    public _43pTokarevaUpContext()
    {
    }

    public _43pTokarevaUpContext(DbContextOptions<_43pTokarevaUpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<TypeCompany> TypeCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.local;Port=5432;Database=43P_Tokareva_UP;Username=43P;Password=444444");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_type_pk");

            entity.ToTable("material_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefectiveMaterial).HasColumnName("defective_material");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pk");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DirectorFio)
                .HasColumnType("character varying")
                .HasColumnName("director_fio");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.IdTypeCompany).HasColumnName("id_type_company");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.LegalAddress)
                .HasColumnType("character varying")
                .HasColumnName("legal address");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.IdTypeCompanyNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypeCompany)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("partners_type_company_fk");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => new { e.IdProduct, e.IdPartner }).HasName("partner_products_pk");

            entity.ToTable("partner_products");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.CountProducts).HasColumnName("count_products");
            entity.Property(e => e.SaleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sale_date");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.IdPartner)
                .HasConstraintName("partner_products_partners_fk");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("partner_products_products_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article)
                .HasColumnType("character varying")
                .HasColumnName("article");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.MinCost).HasColumnName("min_cost");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("products_product_type_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_type_pk");

            entity.ToTable("product_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coefficient).HasColumnName("coefficient");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TypeCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_company_pk");

            entity.ToTable("type_company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
