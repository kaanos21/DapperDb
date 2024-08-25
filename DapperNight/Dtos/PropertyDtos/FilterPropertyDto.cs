namespace DapperNight.Dtos.PropertyDtos
{
    public class FilterPropertyDto
    {
        public string City { get; set; }
        public string Status { get; set; }
        public int? MinPrice { get; set; } // Nullable int
        public int? MaxPrice { get; set; } // Nullable int
        public int? MinRoomCount { get; set; } // Nullable int
        public int? MaxRoomCount { get; set; } // Nullable int
        public int? MinArea { get; set; } // Nullable int
        public int? MaxArea { get; set; } // Nullable int
        public int? CategoryId { get; set; } // Nullable int
    }
}
