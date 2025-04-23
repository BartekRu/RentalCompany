namespace Wypozyczalnia1.Models
{
    public class VehicleItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public decimal PricePerHour { get; set; }
        

    }
    public class VehicleDetailViewModel : VehicleItemViewModel
    {
        
        
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }

        public int ProductionYear { get; set; }
        public int? VehicleTypeId { get; set; }
        

    }
}



