using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IEntertainmentProduct
    {
        Task<List<EntertainmentProduct>> GetAllEntertainmentProducts();
        Task<List<EntertainmentProduct>> GetByIdEntertainmentProducts(string? entertainmentProductId, string? entertainmentId);
        Task<bool> UpdateEntertainmentProduct(EntertainmentProductDto upEntertainmentProduct);
        Task<bool> DeleteEntertainmentProduct(string[] entertainmentProductId);
        Task<bool> InsertEntertainmentProduct(EntertainmentProductDto entertainmentProduct);
    }
}
