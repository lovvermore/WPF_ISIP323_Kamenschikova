using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_ISIP323_Kamenschikova;

public partial class Pr14GovnoContext : DbContext
{
    public Pr14GovnoContext()
    {
    }

    public Pr14GovnoContext(DbContextOptions<Pr14GovnoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeCategory> AgeCategories { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<HallId> HallIds { get; set; }

    public virtual DbSet<HallRating> HallRatings { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-HDUNO1N; initial catalog=pr14_govno; integrated security=true; encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeCategory>(entity =>
        {
            entity.ToTable("AgeCategory");

            entity.Property(e => e.AgeCategoryId).HasColumnName("AgeCategoryID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.AgeCategoryId).HasColumnName("AgeCategoryID");
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.AgeCategory).WithMany(p => p.Films)
                .HasForeignKey(d => d.AgeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Film_AgeCategory");

            entity.HasMany(d => d.Genres).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmGenre_Genre"),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FilmGenre_Film"),
                    j =>
                    {
                        j.HasKey("FilmId", "GenreId");
                        j.ToTable("FilmGenre");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                    });
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<HallId>(entity =>
        {
            entity.HasKey(e => e.HallId1);

            entity.ToTable("HallID");

            entity.Property(e => e.HallId1).HasColumnName("HallID");
            entity.Property(e => e.HallRatingId).HasColumnName("HallRatingID");

            entity.HasOne(d => d.HallRating).WithMany(p => p.HallIds)
                .HasForeignKey(d => d.HallRatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HallID_HallRating");
        });

        modelBuilder.Entity<HallRating>(entity =>
        {
            entity.ToTable("HallRating");

            entity.Property(e => e.HallRatingId).HasColumnName("HallRatingID");
            entity.Property(e => e.Name).HasMaxLength(70);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.ToTable("Seat");

            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.Property(e => e.SessionId)
                .ValueGeneratedNever()
                .HasColumnName("SessionID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Film).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_Film");

            entity.HasOne(d => d.Hall).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_HallID");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Seat");

            entity.HasOne(d => d.Session).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Session");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Login).HasMaxLength(70);
            entity.Property(e => e.Password).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
