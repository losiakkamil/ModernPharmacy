using Microsoft.VisualBasic;
using ModernPharmacy.Shared;
using ModernPharmacy.Shared.Models.SubstanceCategoryDtos;
using System.ComponentModel;

namespace ModernPharmacy.Server.Services.SubstanceCategoryService
{
    public class SubstanceCategoryService : ISubstanceCategoryService
    {
        private readonly DataContext _dataContext;
        public SubstanceCategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<SubstanceCategory>>> GetAllSubstanceCategoriesAsync()
        {
            var response = new ServiceResponse<List<SubstanceCategory>>
            {
                Data = await _dataContext.SubstanceCategories
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<SubstanceCategory>> GetSubstanceCategoryByIdAsync(int substanceCategoryId)
        {
            if (substanceCategoryId < 1)
                throw new BadRequestException($"SubstanceCategory id must be greater than {substanceCategoryId}");

            var response = new ServiceResponse<SubstanceCategory>();
            var substanceCategory = await _dataContext.SubstanceCategories.FirstOrDefaultAsync(sc => sc.Id == substanceCategoryId);
            if(substanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }

            response.Data = substanceCategory;
            return response;
        }

        public async Task<ServiceResponse<SubstanceCategory>> GetSubstanceCategoryByTitleAsync(string title)
        {
            if (title == string.Empty)
                throw new BadRequestException("$Title cannot be empty");

            var response = new ServiceResponse<SubstanceCategory>();

            SubstanceCategory? substanceCategory = await _dataContext.SubstanceCategories.Include(x => x.Substances)
                .FirstOrDefaultAsync(entry => entry.Name == title);

            if (substanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }
            response.Data = substanceCategory;
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetOnlySubstanceCategoriesNamesAsync()
        {
            var response = new ServiceResponse<List<string>>();

            List<string> substanceCategory = await _dataContext.SubstanceCategories.Include(x => x.Substances)
                .Select(sc => sc.Name).ToListAsync();

            if (substanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }
            response.Data = substanceCategory;
            return response;
        }

        public async Task<ServiceResponse<int>> CreateSubstanceCategory(SubstanceCategoryDto dto)
        {
            var response = new ServiceResponse<int>();

            SubstanceCategory substanceCategory = new SubstanceCategory()
            {
                Description = dto.Description,
                Name = dto.Name,
            };

            _dataContext.SubstanceCategories.Add(substanceCategory);
            await _dataContext.SaveChangesAsync();

            var newSubstanceCategory = _dataContext.SubstanceCategories.FirstOrDefault(sc => sc.Name == dto.Name);

            if(newSubstanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }
            int result = newSubstanceCategory.Id;

            response.Data = result;
            return response;
            
        }

        public async Task<ServiceResponse<SubstanceCategory>> UpdateSubstanceCategory(SubstanceCategoryDto dto)
        {
            var response = new ServiceResponse<SubstanceCategory>();
            
            var substanceCategory = _dataContext.SubstanceCategories.FirstOrDefault(x => x.Name == dto.Name);

            if (substanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }
            substanceCategory.Description = dto.Description;
            substanceCategory.Name = dto.Name;

            await _dataContext.SaveChangesAsync();
            response.Data = substanceCategory;

            return response;
        }

        public async Task<ServiceResponse<int>> DeleteSubstanceCategory(int substanceCategoryId)
        {
            var response = new ServiceResponse<int>();

            var substanceCategory = await _dataContext.SubstanceCategories.FirstOrDefaultAsync(sc => sc.Id == substanceCategoryId);
            if(substanceCategory == null)
            {
                throw new NotFoundException($"SubstanceCategory doesn't exist");
            }

            _dataContext.Remove(substanceCategory);
            _dataContext.SaveChanges();

            response.Data = substanceCategoryId; 
            return response;
        }
    }
}
