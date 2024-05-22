using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Model;

public partial class MyBaseContext : DbContext
{
    public MyBaseContext()
    {
    }

    public MyBaseContext(DbContextOptions<MyBaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    public static MyBaseContext model;
    public static Model.MyBaseContext GetContext()
    {
        if (model == null)
        {
            model = new MyBaseContext();
        }
        return model;
    }

    public virtual DbSet<Companii> Companiis { get; set; }

    public virtual DbSet<Dolzhnosti> Dolzhnostis { get; set; }

    public virtual DbSet<Kandidati> Kandidatis { get; set; }

    public virtual DbSet<Kontrakti> Kontraktis { get; set; }

    public virtual DbSet<Navik> Naviks { get; set; }

    public virtual DbSet<NavikiKandidatum> NavikiKandidata { get; set; }

    public virtual DbSet<Otklik> Otkliks { get; set; }

    public virtual DbSet<Sobesedovanie> Sobesedovanies { get; set; }

    public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vakansii> Vakansiis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-TEQ035O;initial catalog=MyBase;persist security info=True;user id=Noitorra;password=Passw0rd;trustservercertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companii>(entity =>
        {
            entity.HasKey(e => e.IdCompanii);

            entity.ToTable("Companii");

            entity.Property(e => e.IdCompanii)
                .ValueGeneratedNever()
                .HasColumnName("ID_Companii");
            entity.Property(e => e.FamiliaDirectora)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Familia_directora");
            entity.Property(e => e.ImeaDirectora)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Imea_directora");
            entity.Property(e => e.Naimenovanie)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.OtchestvoDirectora)
                .HasMaxLength(20)
                .HasColumnName("Otchestvo_directora");
        });

        modelBuilder.Entity<Dolzhnosti>(entity =>
        {
            entity.HasKey(e => e.IdDolzhnosti);

            entity.ToTable("Dolzhnosti");

            entity.Property(e => e.IdDolzhnosti)
                .ValueGeneratedNever()
                .HasColumnName("ID_dolzhnosti");
            entity.Property(e => e.NazvanieDolzhnosti)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Nazvanie_dolzhnosti");
        });

        modelBuilder.Entity<Kandidati>(entity =>
        {
            entity.HasKey(e => e.IdKandidata);

            entity.ToTable("Kandidati");

            entity.Property(e => e.IdKandidata)
                .ValueGeneratedNever()
                .HasColumnName("ID_kandidata");
            entity.Property(e => e.DataRozhdenia).HasColumnName("Data_rozhdenia");
            entity.Property(e => e.Familia)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.IdNavikakondidata).HasColumnName("id_navikakondidata");
            entity.Property(e => e.Imea)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Obrazovanie)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.OpitRaboti).HasColumnName("Opit_raboti");
            entity.Property(e => e.Telefon).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.IdNavikakondidataNavigation).WithMany(p => p.Kandidatis)
                .HasForeignKey(d => d.IdNavikakondidata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kandidati_NavikiKandidata");
        });

        modelBuilder.Entity<Kontrakti>(entity =>
        {
            entity.HasKey(e => e.IdKontrakta);

            entity.ToTable("Kontrakti");

            entity.Property(e => e.IdKontrakta)
                .ValueGeneratedNever()
                .HasColumnName("ID_kontrakta");
            entity.Property(e => e.DataNachalaKontrakta).HasColumnName("Data_nachala_kontrakta");
            entity.Property(e => e.DataOkonchaniaKontrakta).HasColumnName("Data_okonchania_kontrakta");
            entity.Property(e => e.GraphicRaboti)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Graphic_raboti");
            entity.Property(e => e.IdSotrudnika).HasColumnName("ID_sotrudnika");
            entity.Property(e => e.Zarplata).HasColumnType("money");

            entity.HasOne(d => d.IdSotrudnikaNavigation).WithMany(p => p.Kontraktis)
                .HasForeignKey(d => d.IdSotrudnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kontrakti_Sotrudniki");
        });

        modelBuilder.Entity<Navik>(entity =>
        {
            entity.HasKey(e => e.IdNavika);

            entity.ToTable("Navik");

            entity.Property(e => e.IdNavika)
                .ValueGeneratedNever()
                .HasColumnName("ID_navika");
            entity.Property(e => e.NazvanieNavika)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Nazvanie_navika");
        });

        modelBuilder.Entity<NavikiKandidatum>(entity =>
        {
            entity.HasKey(e => e.IdNavikaKondidata);

            entity.Property(e => e.IdNavikaKondidata)
                .ValueGeneratedNever()
                .HasColumnName("ID_navika_kondidata");
            entity.Property(e => e.IdKandidata).HasColumnName("ID_kandidata");
            entity.Property(e => e.IdNavika).HasColumnName("ID_navika");

            entity.HasOne(d => d.IdKandidataNavigation).WithMany(p => p.NavikiKandidata)
                .HasForeignKey(d => d.IdKandidata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NavikiKandidata_Kandidati");

            entity.HasOne(d => d.IdNavikaNavigation).WithMany(p => p.NavikiKandidata)
                .HasForeignKey(d => d.IdNavika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NavikiKandidata_Navik");
        });

        modelBuilder.Entity<Otklik>(entity =>
        {
            entity.HasKey(e => e.IdOtklik);

            entity.ToTable("Otklik");

            entity.Property(e => e.IdOtklik)
                .ValueGeneratedNever()
                .HasColumnName("ID_otklik");
            entity.Property(e => e.IdKandidata).HasColumnName("ID_kandidata");
            entity.Property(e => e.IdVakansii).HasColumnName("ID_vakansii");

            entity.HasOne(d => d.IdKandidataNavigation).WithMany(p => p.Otkliks)
                .HasForeignKey(d => d.IdKandidata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Otklik_Kandidati");

            entity.HasOne(d => d.IdVakansiiNavigation).WithMany(p => p.Otkliks)
                .HasForeignKey(d => d.IdVakansii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Otklik_Vakansii");
        });

        modelBuilder.Entity<Sobesedovanie>(entity =>
        {
            entity.HasKey(e => e.IdSobesedovania);

            entity.ToTable("Sobesedovanie");

            entity.Property(e => e.IdSobesedovania)
                .ValueGeneratedNever()
                .HasColumnName("ID_sobesedovania");
            entity.Property(e => e.DataIVremiaSobesedovania)
                .HasColumnType("datetime")
                .HasColumnName("Data_i_vremia_sobesedovania");
            entity.Property(e => e.IdKandidata).HasColumnName("ID_kandidata");
            entity.Property(e => e.IdSotrudnika).HasColumnName("ID_sotrudnika");
            entity.Property(e => e.IdVakansii).HasColumnName("ID_vakansii");
            entity.Property(e => e.RezultatiSobesedovania)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("Rezultati_sobesedovania");

            entity.HasOne(d => d.IdKandidataNavigation).WithMany(p => p.Sobesedovanies)
                .HasForeignKey(d => d.IdKandidata)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sobesedovanie_Kandidati");

            entity.HasOne(d => d.IdSotrudnikaNavigation).WithMany(p => p.Sobesedovanies)
                .HasForeignKey(d => d.IdSotrudnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sobesedovanie_Sotrudniki");

            entity.HasOne(d => d.IdVakansiiNavigation).WithMany(p => p.Sobesedovanies)
                .HasForeignKey(d => d.IdVakansii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sobesedovanie_Vakansii");
        });

        modelBuilder.Entity<Sotrudniki>(entity =>
        {
            entity.HasKey(e => e.IdSotrudnika);

            entity.ToTable("Sotrudniki");

            entity.Property(e => e.IdSotrudnika).HasColumnName("ID_sotrudnika");
            entity.Property(e => e.Adres).HasMaxLength(20);
            entity.Property(e => e.Familia)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.IdDolzhnosti).HasColumnName("ID_dolzhnosti");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Imea)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Otchestvo).HasMaxLength(20);
            entity.Property(e => e.Telephon).HasMaxLength(20);

            entity.HasOne(d => d.IdDolzhnostiNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdDolzhnosti)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Dolzhnosti");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Parol).IsRequired();
        });

        modelBuilder.Entity<Vakansii>(entity =>
        {
            entity.HasKey(e => e.IdVakansii);

            entity.ToTable("Vakansii");

            entity.Property(e => e.IdVakansii)
                .ValueGeneratedNever()
                .HasColumnName("ID_vakansii");
            entity.Property(e => e.DataPublikacii).HasColumnName("Data_publikacii");
            entity.Property(e => e.IdKompanii).HasColumnName("ID_kompanii");
            entity.Property(e => e.Telephon).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Trebovania)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Zarplata).HasColumnType("money");

            entity.HasOne(d => d.IdKompaniiNavigation).WithMany(p => p.Vakansiis)
                .HasForeignKey(d => d.IdKompanii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vakansii_Companii");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
