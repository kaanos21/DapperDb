namespace DapperNight.Dtos.PropertyDtos
{
    public class ResultPropertyWithImagesDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public int RoomCount { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
