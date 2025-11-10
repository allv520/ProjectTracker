using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class CinemaContext : DbContext
{
    public CinemaContext()
    {
    }

    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<DiscussionThread> DiscussionThreads { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    public virtual DbSet<WatchlistItem> WatchlistItems { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK_DirectorID");

            entity.ToTable("Director");

            entity.Property(e => e.DirectorId)
                .ValueGeneratedNever()
                .HasColumnName("DirectorID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<DiscussionThread>(entity =>
        {
            entity.HasKey(e => e.ThreadId);

            entity.Property(e => e.ThreadId)
                .ValueGeneratedNever()
                .HasColumnName("ThreadID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Movie).WithMany(p => p.DiscussionThreads)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscussionThreads_Movie1");

            entity.HasOne(d => d.User).WithMany(p => p.DiscussionThreads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscussionThreads_Users");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("MovieID");
            entity.Property(e => e.AverageRating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.PosterUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Director");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MovieGenre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Genre).WithMany()
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Genres");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieGenre_Movie");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("RatingID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Movie).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Movie");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Users");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Movie");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.AvatarUrl).HasMaxLength(1000);
            entity.Property(e => e.Bio).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.ToTable("Watchlist");

            entity.Property(e => e.WatchlistId)
                .ValueGeneratedNever()
                .HasColumnName("WatchlistID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Watchlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Watchlist_Users");
        });

        modelBuilder.Entity<WatchlistItem>(entity =>
        {
            entity.ToTable("WatchlistItem");

            entity.Property(e => e.WatchlistItemId)
                .ValueGeneratedNever()
                .HasColumnName("WatchlistItemID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.WatchlistId).HasColumnName("WatchlistID");

            entity.HasOne(d => d.Movie).WithMany(p => p.WatchlistItems)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchlistItem_Movie");

            entity.HasOne(d => d.Watchlist).WithMany(p => p.WatchlistItems)
                .HasForeignKey(d => d.WatchlistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchlistItem_Watchlist");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
