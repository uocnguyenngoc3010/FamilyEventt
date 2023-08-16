using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IDecorationProduct
    {
        /// <summary>
        /// Get all DecorationProduct
        /// </summary>
        /// <returns></returns>
        Task<List<DecorationProductDto>> GetAllDecorationProduct();

        /// <summary>
        /// Get decorationProduct by Id
        /// </summary>
        /// <param name="decorationId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
         Task<List<DecorationProduct>> GetDecorationProductById(string? decorationId, string? productId);

        /// <summary>
        /// Get decorationProduct by many filter options
        /// </summary>
        /// <param name="decorationID"></param>
        /// <param name="productId"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="quantity"></param>
        /// <param name="quantityOption"> 
        /// if quantityOption then get equall and higher; else get equal and lower
        /// </param>
        /// <returns></returns>
        Task<List<DecorationProductDto>> FilterDecorationProducts(string? decorationId, string? productId, decimal? minPrice, decimal? maxPrice, int? quantity, bool? quantityOption = true);

        /// <summary>
        /// Add a decorationProduct
        /// </summary>
        /// <param name="decorationProduct"></param>
        /// <returns></returns>
        Task<bool> AddDecorationProduct(DecorationProductDto decorationProduct);

        /// <summary>
        /// Update a decorationProduct
        /// </summary>
        /// <param name="decorationProduct"></param>
        /// <returns></returns>
        Task<bool> UpdateDecorationProduct(DecorationProductDto decorationProduct);

        /// <summary>
        /// Delete a range of decorationProduct
        /// </summary>
        /// <param name="decorationProductId"></param>
        /// <returns></returns>
        Task<bool> DeleteDecorationProductById(List<string> decorationProductId);
        Task<bool> UpdateProduct(DecoProductUpdate decorationProduct);

    }
}
