using FamilyEventt.Dto;

namespace FamilyEventt.Interfaces
{
    public interface IAdminConfig
    {
        AdminConfig GetConfig();
        AdminConfig ChangeRule(AdminConfig config);
    }
}
