using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Caffeina.Models
{
    public partial class caffeinaContext : DbContext
    {
        public caffeinaContext()
        {
        }

        public caffeinaContext(DbContextOptions<caffeinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArticlesCommande> ArticlesCommandes { get; set; } = null!;
        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Commande> Commandes { get; set; } = null!;
        public virtual DbSet<Produit> Produits { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=caffeina; User=sa;Password=super_duper_password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticlesCommande>(entity =>
            {
                entity.HasKey(e => e.IdArticle)
                    .HasName("PK__articles__64CB31B86498EE6B");

                entity.ToTable("articles_commande");

                entity.Property(e => e.IdArticle)
                    .ValueGeneratedNever()
                    .HasColumnName("id_article");

                entity.Property(e => e.IdCommande).HasColumnName("id_commande");

                entity.Property(e => e.IdProduit).HasColumnName("id_produit");

                entity.Property(e => e.Quantite).HasColumnName("quantite");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.ArticlesCommandes)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK__articles___id_co__3B75D760");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.ArticlesCommandes)
                    .HasForeignKey(d => d.IdProduit)
                    .HasConstraintName("FK__articles___id_pr__3C69FB99");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PK__categori__CD54BC5EA272DBB8");

                entity.ToTable("categorie");

                entity.Property(e => e.IdCategorie)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categorie");

                entity.Property(e => e.DateAjout)
                    .HasColumnType("date")
                    .HasColumnName("date_ajout");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.SourceImage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("source_image");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("PK__commande__385131BF9B49EC21");

                entity.ToTable("commandes");

                entity.Property(e => e.IdCommande)
                    .ValueGeneratedNever()
                    .HasColumnName("id_commande");

                entity.Property(e => e.DateCommande)
                    .HasColumnType("date")
                    .HasColumnName("date_commande");

                entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .HasConstraintName("FK__commandes__id_ut__38996AB5");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.IdProduit)
                    .HasName("PK__produits__BA39391BE090A66D");

                entity.ToTable("produits");

                entity.Property(e => e.IdProduit)
                    .ValueGeneratedNever()
                    .HasColumnName("id_produit");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IdCategorie).HasColumnName("id_categorie");

                entity.Property(e => e.NomProduit)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_produit");

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("prix");

                entity.Property(e => e.SourceImage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("source_image");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.IdCategorie)
                    .HasConstraintName("FK__produits__id_cat__35BCFE0A");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur)
                    .HasName("PK__utilisat__1A4FA5B8B087F990");

                entity.ToTable("utilisateurs");

                entity.Property(e => e.IdUtilisateur)
                    .ValueGeneratedNever()
                    .HasColumnName("id_utilisateur");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mot_de_passe");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
