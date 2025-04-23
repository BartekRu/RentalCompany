using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia1.Models
{
    
    public class Reservation
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string GuestName { get; set; }
        //public string Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
