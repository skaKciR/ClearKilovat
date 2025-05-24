using ClearKilovat.Models.Parser;
using static ClearKilovat.Components.Pages.Home;

namespace ClearKilovat.Interfaces
{
    public interface ICompanySearchService
    {
        Task<IdPurposeDTO> GetBuildingId(string address);
        Task<List<Company>> GetCompaniesInBuilding(string buildingId);
        bool IsCommercialBuilding(string purposeName);
    }
}
