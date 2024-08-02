namespace DapperNight.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal price { get; set; }
        public string CategoryName { get; set; }
    }
}
