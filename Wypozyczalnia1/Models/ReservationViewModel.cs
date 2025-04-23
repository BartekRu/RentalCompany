using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia1.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


        //public string UserId { get; set; }  // Identyfikator użytkownika (np. z Identity)
        public string GuestName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
