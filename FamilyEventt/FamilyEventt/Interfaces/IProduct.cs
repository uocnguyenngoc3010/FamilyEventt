using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<List<ProductDto>> SearchByNameProducts(string name);
        Task<List<ProductDto>> FilterProductByManyOption(string? name, decimal? MinPrice, decimal? maxPrice, string? supplier, int? quantity, bool? qtyOption = true);
        Task<bool> UpdateProduct(ProductDto upProduct);
        Task<bool> DeleteProduct(List<string> id);
        Task<bool> InsertProduct(ProductDto iProduct);
        Task<List<ProductDto>> SearchByIDProducts(string id);
    }
}
