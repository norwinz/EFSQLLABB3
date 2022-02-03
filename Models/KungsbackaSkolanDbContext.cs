using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class KungsbackaSkolanDbContext : DbContext
    {
        public KungsbackaSkolanDbContext()
        {
        }

        public KungsbackaSkolanDbContext(DbContextOptions<KungsbackaSkolanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Befattning> Befattning { get; set; }
        public virtual DbSet<Betyg> Betyg { get; set; }
        public virtual DbSet<BetygKod> BetygKod { get; set; }
        public virtual DbSet<Elev> Elev { get; set; }
        public virtual DbSet<Klass> Klass { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Pronomen> Pronomen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMA3C5T\\TESTSERVER;Initial Catalog = KungsbackaSkolan;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Befattning>(entity =>
            {
                entity.Property(e => e.BefattningId).HasColumnName("BefattningID");

                entity.Property(e => e.BefattningTyp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.FBetygKodId).HasColumnName("fBetygKodID");

                entity.Property(e => e.FElevId).HasColumnName("fElevID");

                entity.Property(e => e.FKursId).HasColumnName("fKursID");

                entity.Property(e => e.FPersonalId).HasColumnName("fPersonalID");

                entity.HasOne(d => d.FBetygKod)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FBetygKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_BetygKod");

                entity.HasOne(d => d.FElev)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FElevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Elev");

                entity.HasOne(d => d.FKurs)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FKursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Kurs");

                entity.HasOne(d => d.FPersonal)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Personal");
            });

            modelBuilder.Entity<BetygKod>(entity =>
            {
                entity.Property(e => e.BetygKodId).HasColumnName("BetygKodID");

                entity.Property(e => e.BetygTyp)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.Enamn)
                    .IsRequired()
                    .HasColumnName("ENamn")
                    .HasMaxLength(50);

                entity.Property(e => e.FKlassId).HasColumnName("fKlassID");

                entity.Property(e => e.FPronomenId).HasColumnName("fPronomenID");

                entity.Property(e => e.Fnamn)
                    .IsRequired()
                    .HasColumnName("FNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.Pnummer)
                    .IsRequired()
                    .HasColumnName("PNummer")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FKlass)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.FKlassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elev_Klass");

                entity.HasOne(d => d.FPronomen)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.FPronomenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elev_Pronomen");
            });

            modelBuilder.Entity<Klass>(entity =>
            {
                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.FProgramId).HasColumnName("fProgramID");

                entity.Property(e => e.KlassKod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FProgram)
                    .WithMany(p => p.Klass)
                    .HasForeignKey(d => d.FProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Klass_Program");
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.FElevId).HasColumnName("fElevID");

                entity.Property(e => e.FPersonalId).HasColumnName("fPersonalID");

                entity.Property(e => e.KursNamn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FElev)
                    .WithMany(p => p.Kurs)
                    .HasForeignKey(d => d.FElevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurs_Elev");

                entity.HasOne(d => d.FPersonal)
                    .WithMany(p => p.Kurs)
                    .HasForeignKey(d => d.FPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurs_Personal");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.FBefattningId).HasColumnName("fBefattningID");

                entity.Property(e => e.FPpronomenId).HasColumnName("fPPronomenID");

                entity.Property(e => e.Penamn)
                    .IsRequired()
                    .HasColumnName("PENamn")
                    .HasMaxLength(50);

                entity.Property(e => e.Pfnamn)
                    .IsRequired()
                    .HasColumnName("PFNamn")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FBefattning)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.FBefattningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personal_Befattning");

                entity.HasOne(d => d.FPpronomen)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.FPpronomenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personal_Pronomen");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

                entity.Property(e => e.ProgramTyp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pronomen>(entity =>
            {
                entity.Property(e => e.PronomenId).HasColumnName("PronomenID");

                entity.Property(e => e.PronomenTyp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
