using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class LinieAutobusoweContext : DbContext
    {
        public LinieAutobusoweContext()
        {
        }

        public LinieAutobusoweContext(DbContextOptions<LinieAutobusoweContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusStops> BusStops { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Lines> Lines { get; set; }
        public virtual DbSet<Rides> Rides { get; set; }
        public virtual DbSet<RouteSections> RouteSections { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<VisitedBusStops> VisitedBusStops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=LinieAutobusowe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStops>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Lines>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Rides>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.LineId).HasColumnName("Line_Id");

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rides_Employees1");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Rides)
                    .HasForeignKey<Rides>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rides_Vehicles1");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rides_Lines1");
            });

            modelBuilder.Entity<RouteSections>(entity =>
            {
                entity.HasKey(e => new { e.LineId, e.BusStopId });

                entity.Property(e => e.LineId).HasColumnName("Line_Id");

                entity.Property(e => e.BusStopId).HasColumnName("BusStop_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.BusStop)
                    .WithMany(p => p.RouteSections)
                    .HasForeignKey(d => d.BusStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RouteSections_BusStops1");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.RouteSections)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RouteSections_Lines1");
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shifts_Employees2");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FinalBusStopId).HasColumnName("FinalBusStop_Id");

                entity.Property(e => e.InitialBusStopId).HasColumnName("InitialBusStop_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RideId).HasColumnName("Ride_Id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.FinalBusStop)
                    .WithMany(p => p.TicketsFinalBusStop)
                    .HasForeignKey(d => d.FinalBusStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_BusStops3");

                entity.HasOne(d => d.InitialBusStop)
                    .WithMany(p => p.TicketsInitialBusStop)
                    .HasForeignKey(d => d.InitialBusStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_BusStops2");

                entity.HasOne(d => d.Ride)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RideId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Rides");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearOfProduction)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<VisitedBusStops>(entity =>
            {
                entity.Property(e => e.BusStopId).HasColumnName("busStop_id");

                entity.Property(e => e.LineId).HasColumnName("line_id");

                entity.Property(e => e.RidesId).HasColumnName("rides_id");

                entity.Property(e => e.TimeOfArrival).HasColumnType("datetime");

                entity.HasOne(d => d.BusStop)
                    .WithMany(p => p.VisitedBusStops)
                    .HasForeignKey(d => d.BusStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedBusStops_BusStops");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.VisitedBusStops)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedBusStops_Lines");

                entity.HasOne(d => d.Rides)
                    .WithMany(p => p.VisitedBusStops)
                    .HasForeignKey(d => d.RidesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedBusStops_Rides");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
