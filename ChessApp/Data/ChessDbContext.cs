using System;
using System.Collections.Generic;
using ChessApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessApp.Data;

public partial class ChessDbContext : DbContext
{
    public ChessDbContext()
    {
    }

    public ChessDbContext(DbContextOptions<ChessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerTour> PlayerTours { get; set; }

    public virtual DbSet<SportRank> SportRanks { get; set; }

    public virtual DbSet<TourLvl> TourLvls { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_city_country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("player");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.IsWorldChampionContender).HasColumnName("is_world_champion_contender");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Note)
                .HasMaxLength(300)
                .HasColumnName("note");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.SportRankId).HasColumnName("sport_rank_id");

            entity.HasOne(d => d.SportRank).WithMany(p => p.Players)
                .HasForeignKey(d => d.SportRankId)
                .HasConstraintName("FK_player_sport_rank");
        });

        modelBuilder.Entity<PlayerTour>(entity =>
        {
            entity.ToTable("player_tour");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.ResultNumber).HasColumnName("result_number");
            entity.Property(e => e.StartNumber).HasColumnName("start_number");
            entity.Property(e => e.TourId).HasColumnName("tour_id");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerTours)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_player_tour_player");

            entity.HasOne(d => d.Tour).WithMany(p => p.PlayerTours)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK_player_tour_tournament");
        });

        modelBuilder.Entity<SportRank>(entity =>
        {
            entity.ToTable("sport_rank");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TourLvl>(entity =>
        {
            entity.ToTable("tour_lvl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.ToTable("tournament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.TourLvlId).HasColumnName("tour_lvl_id");

            entity.HasOne(d => d.City).WithMany(p => p.Tournaments)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_tournament_city");

            entity.HasOne(d => d.TourLvl).WithMany(p => p.Tournaments)
                .HasForeignKey(d => d.TourLvlId)
                .HasConstraintName("FK_tournament_tour_lvl");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
