namespace ECommerceAPI.Models
{
    public class ProductsDto
    {
        public long? Id { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }

    }
}
