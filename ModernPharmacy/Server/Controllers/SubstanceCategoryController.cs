using Microsoft.AspNetCore.Mvc;
using ModernPharmacy.Server.Services.SubstanceCategoryService;
using ModernPharmacy.Shared;
using ModernPharmacy.Shared.Models;
using ModernPharmacy.Shared.Models.SubstanceCategoryDtos;

namespace ModernPharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubstanceCategoryController : ControllerBase
    {
        private readonly ISubstanceCategoryService _substanceCategoryService;
        public SubstanceCategoryController(ISubstanceCategoryService substanceCategoryService)
        {
            _substanceCategoryService = substanceCategoryService;
        }

        [HttpGet("{substanceId:int}")]
        public async Task<ActionResult<ServiceResponse<SubstanceCategory>>> GetSubstanceCategoryById(int substanceCategoryId)
        {
            var result = await _substanceCategoryService.GetSubstanceCategoryByIdAsync(substanceCategoryId);
            return Ok(result);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<ServiceResponse<SubstanceCategory>>> GetSubstanceCategoryByTitleAsync(string title)
        {
            var result = await _substanceCategoryService.GetSubstanceCategoryByTitleAsync(title);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SubstanceCategory>>>> GetAllSubstanceCategoriesAsync()
        {
            var result = await _substanceCategoryService.GetAllSubstanceCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("TitleAndPath")]
        public async Task<ActionResult<ServiceResponse<List<Tuple<string, string>>>>> GetOnlySubstanceCategoryTitlesAsync()
        { 
            var result = await _substanceCategoryService.GetAllSubstanceCategoriesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubstanceCategory([FromBody] SubstanceCategoryDto substanceCategoryDto)
        {
            var newSubstanceCategoryId = _substanceCategoryService.CreateSubstanceCategory(substanceCategoryDto);
            return Created($"api/substancecategory/{newSubstanceCategoryId}", null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubstanceCategory([FromBody] SubstanceCategoryDto substanceCategoryDto)
        {
            _substanceCategoryService.UpdateSubstanceCategory(substanceCategoryDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSubstanceCategory([FromQuery] int id)
        {
            _substanceCategoryService.DeleteSubstanceCategory(id);
            return NoContent();
        }
    }
}
