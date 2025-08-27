using SnapShop.Products.API.Models;
using SnapShop.Products.API.Models.Dto;

namespace SnapShop.Products.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page = 1, int pageSize = 10, string? search = null, int? categoryId = null);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductCreateDto productDto);
        Task<bool> UpdateProductAsync(int id, ProductUpdateDto productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> ReduceStockAsync(int id, int quantity);
        Task<bool> IncreaseStockAsync(int id, int quantity);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
