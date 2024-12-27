using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;

namespace AirplaneMVC.Models
{
    public class AirplaneContext : DbContext
    {
        public AirplaneContext(DbContextOptions<AirplaneContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airline_PhoneNumbers> Airline_PhoneNumbers { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee_Qualifications> Employee_Qualifications { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite primary keys if needed
            // Remove composite keys for simpler EF Core compatibility.

            // Configure Airline_PhoneNumbers
            modelBuilder.Entity<Airline_PhoneNumbers>()
                .HasOne(ap => ap.Airline)
                .WithMany(a => a.PhoneNumbers)
                .HasForeignKey(ap => ap.AirlineID);

            // Configure Employee_Qualifications
            modelBuilder.Entity<Employee_Qualifications>()
                .HasOne(eq => eq.Employee)
                .WithMany(e => e.EmployeeQualifications)
                .HasForeignKey(eq => eq.EmployeeID);

            // Configure Assignment relationships
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Aircraft)
                .WithMany(ac => ac.Assignments)
                .HasForeignKey(a => a.AircraftID);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Route)
                .WithMany(r => r.Assignments)
                .HasForeignKey(a => a.RouteID);

            // Configure other relationships as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}