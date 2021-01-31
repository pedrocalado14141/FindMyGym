using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Gym> Gym { get; set; }
        public virtual DbSet<GymSchedule> GymSchedule { get; set; }
        public virtual DbSet<Modalities> Modalities { get; set; }
        public virtual DbSet<MuscleMachines> MuscleMachines { get; set; }
        public virtual DbSet<PersonalTrainers> PersonalTrainers { get; set; }
        public virtual DbSet<RelGymMachines> RelGymMachines { get; set; }
        public virtual DbSet<RelGymModalities> RelGymModalities { get; set; }
        public virtual DbSet<RelGymServices> RelGymServices { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Ptid)
                    .HasConstraintName("FK_Clientes_PersonalTrainers");
            });

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.Property(e => e.Adress).IsUnicode(false);

                entity.Property(e => e.Contact).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Facebook).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<GymSchedule>(entity =>
            {
                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.GymSchedule)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GymSchedule_Gym");

                entity.HasOne(d => d.WeekDay)
                    .WithMany(p => p.GymSchedule)
                    .HasForeignKey(d => d.WeekDayid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GymSchedule_WeekDays");
            });

            modelBuilder.Entity<Modalities>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<MuscleMachines>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<PersonalTrainers>(entity =>
            {
                entity.Property(e => e.Contact).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.PersonalTrainers)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalTrainers_Gym");
            });

            modelBuilder.Entity<RelGymMachines>(entity =>
            {
                entity.HasKey(e => new { e.GymId, e.MachinesId });

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.RelGymMachines)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelGymMachines_Gym");

                entity.HasOne(d => d.Machines)
                    .WithMany(p => p.RelGymMachines)
                    .HasForeignKey(d => d.MachinesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelGymMachines_MuscleMachines");
            });

            modelBuilder.Entity<RelGymModalities>(entity =>
            {
                entity.HasKey(e => new { e.GymId, e.ModalitiesId })
                    .HasName("PK_RelGymFitnessRoom");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.RelGymModalities)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelGymFitnessRoom_Gym");

                entity.HasOne(d => d.Modalities)
                    .WithMany(p => p.RelGymModalities)
                    .HasForeignKey(d => d.ModalitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelGymFitnessRoom_PersonalTrainers");
            });

            modelBuilder.Entity<RelGymServices>(entity =>
            {
                entity.HasKey(e => new { e.GymId, e.ServicesId });

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.RelGymServices)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelGymServices_Services");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
