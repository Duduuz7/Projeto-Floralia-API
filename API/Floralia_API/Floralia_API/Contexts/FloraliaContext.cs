using System;
using System.Collections.Generic;
using Floralia_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace Floralia_API.Contexts;

public partial class FloraliaContext : DbContext
{
    public FloraliaContext()
    {
    }

    public FloraliaContext(DbContextOptions<FloraliaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrinho> Carrinho { get; set; }

    public virtual DbSet<Encomenda> Encomenda { get; set; }

    public virtual DbSet<Favorito> Favorito { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SUPORTE\\SQLEXPRESS; initial catalog=FloraliaBD; user Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrinho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrinho__3214EC274BA8F9FE");

            entity.ToTable("Carrinho");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Carrinho)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Carrinho__IdProd__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Carrinho)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Carrinho__IdUsua__5629CD9C");
        });

        modelBuilder.Entity<Encomenda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encomend__3214EC27E9F727D7");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.StatusEncomanda)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Encomenda)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Encomenda__IdPro__5070F446");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Encomenda)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Encomenda__IdUsu__5165187F");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorito__3214EC279C518103");

            entity.ToTable("Favorito");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Favorito)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Favorito__IdProd__59FA5E80");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Favorito)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Favorito__IdUsua__5AEE82B9");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC2725301E93");

            entity.ToTable("Produto");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Foto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC27A0D3F80B");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
