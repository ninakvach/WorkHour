using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkHour.Data.Models
{
    public partial class WorkHourContext : DbContext
    {
        public WorkHourContext()
        {
        }

        public WorkHourContext(DbContextOptions<WorkHourContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<BusinessList> BusinessList { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<ProjectDescription> ProjectDescription { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3CPIDA7;Database=WorkHour;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Explanation)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_BusinessList");
            });

            modelBuilder.Entity<BusinessList>(entity =>
            {
                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.CreatorPersonel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Explanation)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.LastDateStudied).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TaskExplanation)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mission)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectDescription>(entity =>
            {
                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProjectDescription)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectDescription_Customer");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Explanation)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.Work)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Work_Personel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
