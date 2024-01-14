using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreFull.Data
{
    public partial class AnalyticaContext : IdentityDbContext<IdentityUser>
    {
        public AnalyticaContext()
        {
        }

        public AnalyticaContext(DbContextOptions<AnalyticaContext> options)
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgriSectorType>(entity =>
            {
                entity.ToTable("AgriSectorType");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Ids)
                    .UsingEntity<Dictionary<string, object>>(
                        "AgriSectorTypeUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                        r => r.HasOne<AgriSectorType>().WithMany().HasForeignKey("IdsId"),
                        j =>
                        {
                            j.HasKey("IdsId", "UsersId");

                            j.ToTable("AgriSectorTypeUser");

                            j.HasIndex(new[] { "UsersId" }, "IX_AgriSectorTypeUser_UsersId");
                        });
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal");

                entity.HasIndex(e => e.AnimalTypeId, "IX_Animal_AnimalTypeId");

                entity.HasIndex(e => e.GenderId, "IX_Animal_GenderId");

                entity.Property(e => e.BoughtPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SoldPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AnimalType)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalTypeId);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.GenderId);
            });

            modelBuilder.Entity<AnimalMedicalCondtionType>(entity =>
            {
                entity.ToTable("AnimalMedicalCondtionType");
            });

            modelBuilder.Entity<AnimalMedicalHistory>(entity =>
            {
                entity.ToTable("AnimalMedicalHistory");

                entity.HasIndex(e => e.AnimalMedicalCondtionTypeId, "IX_AnimalMedicalHistory_AnimalMedicalCondtionTypeId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AnimalMedicalCondtionType)
                    .WithMany(p => p.AnimalMedicalHistories)
                    .HasForeignKey(d => d.AnimalMedicalCondtionTypeId);
            });

            modelBuilder.Entity<AnimalProgress>(entity =>
            {
                entity.ToTable("AnimalProgress");

                entity.HasIndex(e => e.AnimalProgressTypeId, "IX_AnimalProgress_AnimalProgressTypeId");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AnimalProgressType)
                    .WithMany(p => p.AnimalProgresses)
                    .HasForeignKey(d => d.AnimalProgressTypeId);
            });

            modelBuilder.Entity<AnimalProgressType>(entity =>
            {
                entity.ToTable("AnimalProgressType");
            });

            modelBuilder.Entity<AnimalType>(entity =>
            {
                entity.ToTable("AnimalType");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");
            });

            modelBuilder.Entity<User>(entity =>
            {
              entity.ToTable("User");

              entity.Property(e => e.AspUserId).HasMaxLength(450);

              entity.Property(e => e.DateCreated).HasColumnType("datetime");

              entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);

              entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);

              entity.Property(e => e.Password).HasMaxLength(450);

              entity.Property(e => e.Surname)
                .HasMaxLength(1)
                .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
