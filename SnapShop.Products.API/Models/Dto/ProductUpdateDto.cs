using System.ComponentModel.DataAnnotations;

namespace SnapShop.Products.API.Models.Dto
{
    public class ProductUpdateDto
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        public int? CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public bool? IsActive { get; set; }
    }
}
