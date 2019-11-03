using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tunnit.Models
{
    public partial class tuntikrjausContext : DbContext
    {
        public tuntikrjausContext()
        {
        }

        public tuntikrjausContext(DbContextOptions<tuntikrjausContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Henkilö> Henkilö { get; set; }
        public virtual DbSet<TunnitCS> Tunnit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=tuntikrjaus;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Henkilö>(entity =>
            {
                entity.ToTable("henkilö");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Etunimi)
                    .IsRequired()
                    .HasColumnName("etunimi")
                    .HasMaxLength(40);

                entity.Property(e => e.Osasto)
                    .HasColumnName("osasto")
                    .HasMaxLength(40);

                entity.Property(e => e.Sukunimi)
                    .IsRequired()
                    .HasColumnName("sukunimi")
                    .HasMaxLength(40);

                entity.Property(e => e.Tehtävänimike)
                    .HasColumnName("tehtävänimike")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<TunnitCS>(entity =>
            {
                entity.ToTable("tunnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Laskutettava).HasColumnName("laskutettava");

                entity.Property(e => e.Päivämäärä)
                    .HasColumnName("päivämäärä")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tehtäväkuvaus)
                    .HasColumnName("tehtäväkuvaus")
                    .HasMaxLength(100);

                entity.Property(e => e.Tunnit1)
                    .HasColumnName("tunnit")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TunnitId).HasColumnName("tunnit_id");

                entity.HasOne(d => d.TunnitNavigation)
                    .WithMany(p => p.Tunnit)
                    .HasForeignKey(d => d.TunnitId)
                    .HasConstraintName("fk_Tunnit_henkilö");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
