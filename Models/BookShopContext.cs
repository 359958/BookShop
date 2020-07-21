using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookShop.Models
{
    public partial class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=B2ML28043\\SQLEXPRESS;Database=BookShop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("pk_authors");

                entity.ToTable("authors");

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasColumnName("au_fname")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasColumnName("au_lname")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("pk_publishers");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PubName)
                    .IsRequired()
                    .HasColumnName("pub_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("pk_titles");

                entity.ToTable("titles");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasColumnName("pub_id")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pubdate)
                    .HasColumnName("pubdate")
                    .HasColumnType("date");

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasColumnName("title_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.AuId)
                    .HasConstraintName("FK__titles__au_id__2A4B4B5E");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titles__pub_id__29572725");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C52F28C50");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
