namespace WebApi.Models.ModelsToClient
{
    public class ProductModel
    {
        public int id_product { get; set; }
        public string? NameProduct { get; set; }
        public string? ProductDescription { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsTrend { get; set; }
        public bool IsNew { get; set; }
        public double AvgGrade { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double CountReviews { get; set; }
    }
}
