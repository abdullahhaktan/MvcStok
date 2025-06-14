using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcStok.Models.Entity;

public partial class MvcDbStokContext : DbContext
{
    public MvcDbStokContext()
    {
    }

    public MvcDbStokContext(DbContextOptions<MvcDbStokContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblkategoriler> Tblkategorilers { get; set; }

    public virtual DbSet<Tblmusteriler> Tblmusterilers { get; set; }

    public virtual DbSet<Tblsatislar> Tblsatislars { get; set; }

    public virtual DbSet<Tblurunler> Tblurunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MvcDbStok;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblkategoriler>(entity =>
        {
            entity.HasKey(e => e.KATEGORIID);

            entity.ToTable("TBLKATEGORILER");

            entity.Property(e => e.KATEGORIID).HasColumnName("KATEGORIID");
            entity.Property(e => e.KATEGORIAD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KATEGORIAD");
        });

        modelBuilder.Entity<Tblmusteriler>(entity =>
        {
            entity.HasKey(e => e.MUSTERIID);

            entity.ToTable("TBLMUSTERILER");

            entity.Property(e => e.MUSTERIID).HasColumnName("MUSTERIID");
            entity.Property(e => e.MUSTERIAD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUSTERIAD");
            entity.Property(e => e.MUSTERISOYAD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUSTERISOYAD");
        });

        modelBuilder.Entity<Tblsatislar>(entity =>
        {
            entity.HasKey(e => e.SATISID);

            entity.ToTable("TBLSATISLAR");

            entity.Property(e => e.SATISID).HasColumnName("SATISID");
            entity.Property(e => e.ADET).HasColumnName("ADET");
            entity.Property(e => e.FIYAT)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FIYAT");
            entity.Property(e => e.MUSTERI).HasColumnName("MUSTERI");
            entity.Property(e => e.URUN).HasColumnName("URUN");

            entity.HasOne(d => d.MusteriNavigation).WithMany(p => p.Tblsatislars)
                .HasForeignKey(d => d.MUSTERI)
                .HasConstraintName("FK_TBLSATISLAR_TBLMUSTERILER");

            entity.HasOne(d => d.UrunNavigation).WithMany(p => p.Tblsatislars)
                .HasForeignKey(d => d.URUN)
                .HasConstraintName("FK_TBLSATISLAR_TBL_URUNLER");
        });

        modelBuilder.Entity<Tblurunler>(entity =>
        {
            entity.HasKey(e => e.URUNID).HasName("PK_TBL_URUNLER");

            entity.ToTable("TBLURUNLER");

            entity.Property(e => e.URUNID).HasColumnName("URUNID");
            entity.Property(e => e.FIYAT)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FİYAT");
            entity.Property(e => e.MARKA)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARKA");
            entity.Property(e => e.STOK).HasColumnName("STOK");
            entity.Property(e => e.URUNAD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("URUNAD");
            entity.Property(e => e.URUNKATEGORI).HasColumnName("URUNKATEGORI");

            entity.HasOne(d => d.UrunkategoriNavigation).WithMany(p => p.Tblurunlers)
                .HasForeignKey(d => d.URUNKATEGORI)
                .HasConstraintName("FK_TBL_URUNLER_TBLKATEGORILER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
