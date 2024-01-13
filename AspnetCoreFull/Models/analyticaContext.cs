using System;
using System.Collections.Generic;
using AspnetCoreFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspnetCoreFull.Models
{
    public partial class analyticaContext : DbContext
    {
        public analyticaContext()
        {
        }

        public analyticaContext(DbContextOptions<analyticaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgriSectorType> AgriSectorTypes { get; set; } = null!;
        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalMedicalCondtionType> AnimalMedicalCondtionTypes { get; set; } = null!;
        public virtual DbSet<AnimalMedicalHistory> AnimalMedicalHistories { get; set; } = null!;
        public virtual DbSet<AnimalProgress> AnimalProgresses { get; set; } = null!;
        public virtual DbSet<AnimalProgressType> AnimalProgressTypes { get; set; } = null!;
        public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:agri-analytica.database.windows.net,1433;Initial Catalog=analytica;Persist Security Info=False;User ID=tim;Password=FRIky25879;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgriSectorType>(entity =>
            {
                entity.ToTable("agri_sector_type", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Ids)
                    .UsingEntity<Dictionary<string, object>>(
                        "AgriSector",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("agri_sector$fk_Agri_sector_type_has_User_User1"),
                        r => r.HasOne<AgriSectorType>().WithMany().HasForeignKey("Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("agri_sector$fk_Agri_sector_type_has_User_Agri_sector_type"),
                        j =>
                        {
                            j.HasKey("Id", "UserId").HasName("PK_agri_sector_id");

                            j.ToTable("agri_sector", "analytica");

                            j.HasIndex(new[] { "Id" }, "fk_Agri_sector_type_has_User_Agri_sector_type_idx");

                            j.HasIndex(new[] { "UserId" }, "fk_Agri_sector_type_has_User_User1_idx");

                            j.IndexerProperty<int>("Id").ValueGeneratedOnAdd().HasColumnName("id");

                            j.IndexerProperty<int>("UserId").HasColumnName("User_id");
                        });
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AgriSectorId, e.AnimalTypeId, e.GenderId })
                    .HasName("PK_animal_id");

                entity.ToTable("animal", "analytica");

                entity.HasIndex(e => e.AgriSectorId, "fk_Animal_Agri_sector1_idx");

                entity.HasIndex(e => e.AnimalTypeId, "fk_Animal_Animal_type1_idx");

                entity.HasIndex(e => e.GenderId, "fk_Animal_Gender1_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AgriSectorId).HasColumnName("Agri_sector_id");

                entity.Property(e => e.AnimalTypeId).HasColumnName("Animal_type_id");

                entity.Property(e => e.GenderId).HasColumnName("Gender_id");

                entity.Property(e => e.Birth)
                    .HasColumnType("date")
                    .HasColumnName("birth")
                    .HasDefaultValueSql("('1000-01-01')");

                entity.Property(e => e.BoughtPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("bought_price");

                entity.Property(e => e.Death)
                    .HasColumnType("date")
                    .HasColumnName("death")
                    .HasDefaultValueSql("('1000-01-01')");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.EarTag)
                    .HasMaxLength(45)
                    .HasColumnName("ear_tag");

                entity.Property(e => e.ParentFemaleId)
                    .HasColumnName("parent_female_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentMaleId)
                    .HasColumnName("parent_male_ID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SoldPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("sold_price");

                entity.HasOne(d => d.AnimalType)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animal$fk_Animal_Animal_type1");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animal$fk_Animal_Gender1");
            });

            modelBuilder.Entity<AnimalMedicalCondtionType>(entity =>
            {
                entity.ToTable("animal_medical_condtion_type", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AnimalMedicalHistory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AnimalMedicalCondtionTypeId, e.AnimalId, e.AnimalAgriSectorId, e.AnimalAnimalTypeId })
                    .HasName("PK_animal_medical_history_id");

                entity.ToTable("animal_medical_history", "analytica");

                entity.HasIndex(e => new { e.AnimalId, e.AnimalAgriSectorId, e.AnimalAnimalTypeId }, "fk_Animal_medical_history_Animal1_idx");

                entity.HasIndex(e => e.AnimalMedicalCondtionTypeId, "fk_Animal_medical_history_Animal_medical_condtion_type1_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AnimalMedicalCondtionTypeId).HasColumnName("Animal_medical_condtion_type_id");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_id");

                entity.Property(e => e.AnimalAgriSectorId).HasColumnName("Animal_Agri_sector_id");

                entity.Property(e => e.AnimalAnimalTypeId).HasColumnName("Animal_Animal_type_id");

                entity.Property(e => e.Date)
                    .HasMaxLength(45)
                    .HasColumnName("date");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.AnimalMedicalCondtionType)
                    .WithMany(p => p.AnimalMedicalHistories)
                    .HasForeignKey(d => d.AnimalMedicalCondtionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animal_medical_history$fk_Animal_medical_history_Animal_medical_condtion_type1");
            });

            modelBuilder.Entity<AnimalProgress>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AnimalProgressTypeId, e.AnimalId, e.AnimalAgriSectorId, e.AnimalAnimalTypeId })
                    .HasName("PK_animal_progress_id");

                entity.ToTable("animal_progress", "analytica");

                entity.HasIndex(e => new { e.AnimalId, e.AnimalAgriSectorId, e.AnimalAnimalTypeId }, "fk_Animal_progress_Animal1_idx");

                entity.HasIndex(e => e.AnimalProgressTypeId, "fk_Animal_progress_Animal_progress_type1_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AnimalProgressTypeId).HasColumnName("Animal_progress_type_id");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_id");

                entity.Property(e => e.AnimalAgriSectorId).HasColumnName("Animal_Agri_sector_id");

                entity.Property(e => e.AnimalAnimalTypeId).HasColumnName("Animal_Animal_type_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.AnimalProgressType)
                    .WithMany(p => p.AnimalProgresses)
                    .HasForeignKey(d => d.AnimalProgressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animal_progress$fk_Animal_progress_Animal_progress_type1");
            });

            modelBuilder.Entity<AnimalProgressType>(entity =>
            {
                entity.ToTable("animal_progress_type", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AnimalType>(entity =>
            {
                entity.ToTable("animal_type", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "analytica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("('1000-01-01')");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .HasMaxLength(45)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
