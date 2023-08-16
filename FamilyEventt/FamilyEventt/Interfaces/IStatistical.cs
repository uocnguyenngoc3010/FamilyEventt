using FamilyEventt.Dto;

namespace FamilyEventt.Interfaces
{
    public interface IStatistical
    {
        Task<List<StatisticalDto>> StatisticalDataByType(int type, DateTime StartDate, DateTime EndDate);
    }
}
