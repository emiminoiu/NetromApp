using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class AnnouncesWebsiteContext : DbContext
    {
        public AnnouncesWebsiteContext()
        {
        }

        public AnnouncesWebsiteContext(DbContextOptions<AnnouncesWebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announce> Announce { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AnnouncesWebsite;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announce>(entity =>
            {
                entity.Property(e => e.AnnounceId)
                    .HasColumnName("AnnounceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddingDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ExpiringDate).HasColumnType("date");

                entity.Property(e => e.NumeleCategoriei).HasMaxLength(50);

                entity.Property(e => e.Poza).HasColumnType("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.To64)
                    .HasColumnName("to64")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Announce)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Announce_Category");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announce)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Announce_USER");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Announce)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AnnounceId)
                    .HasConstraintName("FK_Comment_Announce");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_USER");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nume).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenume).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
