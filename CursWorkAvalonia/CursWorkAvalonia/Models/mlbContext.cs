using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursWorkAvalonia
{
    public partial class mlbContext : DbContext
    {
        public mlbContext()
        {
        }

        public mlbContext(DbContextOptions<mlbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<PlayersResult> PlayersResults { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamsLineUp> TeamsLineUps { get; set; } = null!;
        public virtual DbSet<TeamsResult> TeamsResults { get; set; } = null!;
        public virtual DbSet<TopManager> TopManagers { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;
        public virtual DbSet<TournamentsTeam> TournamentsTeams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Vova\\Desktop\\CursWorkAvalonia\\CursWorkAvalonia\\Models\\mlb.db"); // Указать путь
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<PlayersResult>(entity =>
            {
                entity.ToTable("players_results");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayersResults)
                    .HasForeignKey(d => d.PlayerId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TopManagerId).HasColumnName("top_manager_id");

                entity.HasOne(d => d.TopManager)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TopManagerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TeamsLineUp>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("teams_line_up");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("player_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.TeamsLineUp)
                    .HasForeignKey<TeamsLineUp>(d => d.PlayerId);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamsLineUps)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<TeamsResult>(entity =>
            {
                entity.ToTable("teams_results");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamsResults)
                    .HasForeignKey(d => d.TeamId);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TeamsResults)
                    .HasForeignKey(d => d.TournamentId);
            });

            modelBuilder.Entity<TopManager>(entity =>
            {
                entity.ToTable("top_managers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournaments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<TournamentsTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tournaments_teams");

                entity.HasIndex(e => new { e.TournamentId, e.TeamId }, "IX_tournaments_teams_tournament_id_team_id")
                    .IsUnique();

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId);

                entity.HasOne(d => d.Tournament)
                    .WithMany()
                    .HasForeignKey(d => d.TournamentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
