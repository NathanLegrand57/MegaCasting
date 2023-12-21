using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MegaCasting.DBLib.Class;

public partial class MegacastingContext : DbContext
{
    public MegacastingContext()
    {
    }

    public MegacastingContext(DbContextOptions<MegacastingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Artiste> Artistes { get; set; }

    public virtual DbSet<Casting> Castings { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contrat> Contrats { get; set; }

    public virtual DbSet<DomaineMetier> DomaineMetiers { get; set; }

    public virtual DbSet<Metier> Metiers { get; set; }

    public virtual DbSet<Partenaire> Partenaires { get; set; }

    public virtual DbSet<TypeContrat> TypeContrats { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Ville> Villes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=megacasting;user=root;password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adresse");

            entity.HasIndex(e => e.VilleId, "Index_ville");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rue)
                .HasMaxLength(150)
                .HasColumnName("rue");
            entity.Property(e => e.VilleId).HasColumnName("ville_id");

            entity.HasOne(d => d.Ville).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.VilleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Index_ville");
        });

        modelBuilder.Entity<Artiste>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("artiste");

            entity.HasIndex(e => e.MetierId, "Index_metier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateNaissance)
                .HasColumnType("date")
                .HasColumnName("date_naissance");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.MetierId).HasColumnName("metier_id");
            entity.Property(e => e.Nom)
                .HasMaxLength(75)
                .HasColumnName("nom");
            entity.Property(e => e.NumTel).HasColumnName("num_tel");
            entity.Property(e => e.Prenom)
                .HasMaxLength(75)
                .HasColumnName("prenom");

            entity.HasOne(d => d.Metier).WithMany(p => p.Artistes)
                .HasForeignKey(d => d.MetierId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Index_metier");
        });

        modelBuilder.Entity<Casting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("casting");

            entity.HasIndex(e => e.ClientId, "Index_client");

            entity.HasIndex(e => e.PartenaireId, "Index_partenaire");

            entity.HasIndex(e => e.AdresseId, "adresse_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdresseId).HasColumnName("adresse_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
            entity.Property(e => e.PartenaireId).HasColumnName("partenaire_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Adresse).WithMany(p => p.Castings)
                .HasForeignKey(d => d.AdresseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Index_adresse");

            entity.HasOne(d => d.Client).WithMany(p => p.Castings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Index_client");

            entity.HasOne(d => d.Partenaire).WithMany(p => p.Castings)
                .HasForeignKey(d => d.PartenaireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Index_partenaire");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.AdresseId, "ForeignKey_adresse_id");

            entity.HasIndex(e => e.CastingId, "ForeignKey_casting_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdresseId).HasColumnName("adresse_id");
            entity.Property(e => e.CastingId).HasColumnName("casting_id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(150)
                .HasColumnName("libelle");

            entity.HasOne(d => d.Adresse).WithMany(p => p.Clients)
                .HasForeignKey(d => d.AdresseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ForeignKey_adresse_id");
        });

        modelBuilder.Entity<Contrat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contrat");

            entity.HasIndex(e => e.TypeContratId, "Index_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateDebut)
                .HasColumnType("date")
                .HasColumnName("date_debut");
            entity.Property(e => e.DateFin)
                .HasColumnType("date")
                .HasColumnName("date_fin");
            entity.Property(e => e.Libelle)
                .HasMaxLength(150)
                .HasColumnName("libelle");
            entity.Property(e => e.TypeContratId).HasColumnName("type_contrat_id");

            entity.HasOne(d => d.TypeContrat).WithMany(p => p.Contrats)
                .HasForeignKey(d => d.TypeContratId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Index_type");
        });

        modelBuilder.Entity<DomaineMetier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("domaine_metier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Metier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("metier");

            entity.HasIndex(e => e.DomaineMetierId, "Index_domaine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DomaineMetierId).HasColumnName("domaine_metier_id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(75)
                .HasColumnName("libelle");

            entity.HasOne(d => d.DomaineMetier).WithMany(p => p.Metiers)
                .HasForeignKey(d => d.DomaineMetierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Index_domaine");
        });

        modelBuilder.Entity<Partenaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partenaire");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<TypeContrat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_contrat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("utilisateur");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(50)
                .HasColumnName("mot_de_passe");
            entity.Property(e => e.NomUtilisateur)
                .HasMaxLength(75)
                .HasColumnName("nom_utilisateur");
        });

        modelBuilder.Entity<Ville>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ville");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodePostal).HasColumnName("code_postal");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
