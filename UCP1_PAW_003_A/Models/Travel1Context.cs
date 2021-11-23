using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Travel1Context : DbContext
    {
        public Travel1Context()
        {
        }

        public Travel1Context(DbContextOptions<Travel1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Jadwal> Jadwals { get; set; }
        public virtual DbSet<Konfirmasi> Konfirmasis { get; set; }
        public virtual DbSet<Kotum> Kota { get; set; }
        public virtual DbSet<Pemesanan> Pemesanans { get; set; }
        public virtual DbSet<Pesan> Pesans { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5RML75UV;Database=Travel1;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Jadwal>(entity =>
            {
                entity.HasKey(e => e.IdKotaAsal);

                entity.ToTable("Jadwal");

                entity.Property(e => e.IdKotaAsal)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_KotaAsal");

                entity.Property(e => e.IdKotaTujuan).HasColumnName("ID_kotaTujuan");

                entity.Property(e => e.JamBerangkat)
                    .HasColumnType("datetime")
                    .HasColumnName("Jam_Berangkat");
            });

            modelBuilder.Entity<Konfirmasi>(entity =>
            {
                entity.HasKey(e => e.IdPesan);

                entity.ToTable("Konfirmasi");

                entity.Property(e => e.IdPesan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pesan");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kotum>(entity =>
            {
                entity.HasKey(e => e.IdKotaAsal);

                entity.Property(e => e.IdKotaAsal)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_KotaAsal");

                entity.Property(e => e.IdKotaTujuan).HasColumnName("ID_KotaTujuan");

                entity.Property(e => e.Kota)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pemesanan>(entity =>
            {
                entity.HasKey(e => e.IdPesan);

                entity.ToTable("Pemesanan");

                entity.Property(e => e.IdPesan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pesan");

                entity.Property(e => e.IdJadwal).HasColumnName("ID_Jadwal");

                entity.Property(e => e.JumlahPesan).HasColumnName("Jumlah_Pesan");

                entity.Property(e => e.TanggalPesan)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pesan");
            });

            modelBuilder.Entity<Pesan>(entity =>
            {
                entity.HasKey(e => e.IdJadwal);

                entity.ToTable("Pesan");

                entity.Property(e => e.IdJadwal)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Jadwal");

                entity.Property(e => e.JumlahPesan).HasColumnName("Jumlah_Pesan");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalPesan)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pesan");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.HasKey(e => e.IdKotaAsal);

                entity.ToTable("Travel");

                entity.Property(e => e.IdKotaAsal)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_KotaAsal");

                entity.Property(e => e.IdKotaTujuan).HasColumnName("ID_kotaTujuan");

                entity.Property(e => e.NoKerangka).HasColumnName("No_Kerangka");

                entity.Property(e => e.NoPolisi).HasColumnName("No_polisi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
