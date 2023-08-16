using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IFamily
    {
        Task<FamilyDto> GetFamilyMemberById(string id);
        Task<List<Family>> GetAllFamily();
        Task<List<Family>> FilterFamilyByManyOption(string? name, string phone, string relation, bool? familyOption = true);
        Task<List<Family>> SearchByNameFamilyMember(string name);
        Task<Family> UpdateFamily(FamilyDto upFamily);
        Task<bool> DeleteFamily(List<string> id);
        Task<Family> InsertFamilyMember(FamilyDto family);
        Task<List<Family>> GetFamilyByEventBooker(string id);
    }
}
