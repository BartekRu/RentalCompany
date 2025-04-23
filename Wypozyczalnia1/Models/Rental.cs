namespace Wypozyczalnia1.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public string UserId { get; set; }  // Identyfikator użytkownika (np. z Identity)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }

        public bool IsReturned { get; set; }
    }
}
