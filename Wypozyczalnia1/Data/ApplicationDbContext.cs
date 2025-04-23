using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wypozyczalnia1.Models;


namespace Wypozyczalnia1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet dla każdej tabeli w bazie danych
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RentalPoint> RentalPoints { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
           
           modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id=1, Name = "Skłdak", Desc = "Fajny" },
                new VehicleType {  Id=2,Name = "Krosik", Desc = "Fajny" },
                new VehicleType {  Id=3,Name = "Bolid", Desc = "Fajny" }
                );
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id=1,
                    Brand = "Cos,",
                    Name = "Rumcajs",
                    Model = "PRL'owski",
                    Type = "Drwal",
                    PricePerDay = 110,
                    Year = 1965,
                    ImageURL = "/images/cross.jpg"

                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Cos,",
                    Name = "TonyK",
                    Model = "Royal",
                    Type = "15LM",
                    Year = 2004,
                    PricePerDay= 85,
                    ImageURL = "/images/heckler.jpg"

                },
                new Vehicle
                {
                    Id = 3,
                    Brand = "Cos,",
                    Name = "Pavel",
                    Model = "Jumper",
                    Type = "4x2",
                    Description = "Bardzo szczegółowy opis",
                    Year = 2007,
                    ImageURL = "/images/trek.jpg",
                    PricePerDay = 90,
                    
                }
                );
            // Relacja Vehicle -> VehicleType (wiele do jednego)
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId);

            // Relacja Vehicle -> RentalPoint (wiele do jednego)
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.RentalPoint)
                .WithMany(rp => rp.Vehicles)
                .HasForeignKey(v => v.RentalPointId);

            // Relacja Reservation -> Vehicle (wiele do jednego)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Reservations)
                .HasForeignKey(r => r.VehicleId);

            // Relacja Rental -> Vehicle (wiele do jednego)
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Rentals)
                .HasForeignKey(r => r.VehicleId);

            modelBuilder.Entity<ApplicationUser>()
               .HasOne(u => u.Profile)
               .WithOne(p => p.User)
               .HasForeignKey<UserProfile>(p => p.UserId);
        }
    }
}

