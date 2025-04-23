using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia1.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        


        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
       public string? Type { get; set; }
        public string? Make { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string? Description { get; set; }
        public string ImageURL { get; set; }

        // Klucz obcy do `VehicleType`
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        // Klucz obcy do `RentalPoint`
        public int RentalPointId { get; set; }
        public RentalPoint RentalPoint { get; set; }
        
        //
        public int ResId { get; set; }
        //public Reservation Reservation { get; set; }    
        
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}

