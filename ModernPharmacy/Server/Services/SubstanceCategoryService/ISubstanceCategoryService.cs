using ModernPharmacy.Shared.Models.SubstanceCategoryDtos;

namespace ModernPharmacy.Server.Services.SubstanceCategoryService
{
    public interface ISubstanceCategoryService
    {
        Task<ServiceResponse<SubstanceCategory>> GetSubstanceCategoryByIdAsync(int  substanceCategoryId);
        Task<ServiceResponse<SubstanceCategory>> GetSubstanceCategoryByTitleAsync(string title);
        Task<ServiceResponse<List<SubstanceCategory>>> GetAllSubstanceCategoriesAsync();
        Task<ServiceResponse<List<string>>> GetOnlySubstanceCategoriesNamesAsync();
        Task<ServiceResponse<int>> CreateSubstanceCategory(SubstanceCategoryDto dto);
        Task<ServiceResponse<SubstanceCategory>> UpdateSubstanceCategory(SubstanceCategoryDto dto);
        Task<ServiceResponse<int>> DeleteSubstanceCategory(int substanceCategoryId);
    }
}
