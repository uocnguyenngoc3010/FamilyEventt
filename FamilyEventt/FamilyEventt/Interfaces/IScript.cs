using FamilyEventt.Dto;
using FamilyEventt.Models;

namespace FamilyEventt.Interfaces
{
    public interface IScript
    {
        Task<bool> UpdateScript(ScriptDto script);
        Task<bool> InsertScript(ScriptDto script);
        Task<bool> DeleteScript(string id);
        Task<Script> GetScriptById(string ID);
        Task<List<Script>> GetScriptByName(string name);
        Task<List<Script>> GetAll();
    }
}
