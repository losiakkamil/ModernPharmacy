using Microsoft.AspNetCore.Mvc;
using ModernPharmacy.Server.Services.SubstanceCategoryService;
using ModernPharmacy.Shared;

namespace ModernPharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubstanceController : ControllerBase
    {
        private readonly ISubstanceCategoryService _substanceCategoryService;
        public SubstanceController(ISubstanceCategoryService substanceCategoryService)
        {
            _substanceCategoryService = substanceCategoryService;
        }

        [HttpGet("{substanceId:int}")]
        public async Task<ActionResult<ServiceResponse<SubstanceCategory>>> GetSubstanceCategoryById(int substanceCategoryId)
        {
            var result = await _substanceCategorySerivce.GetSubstanceCategoryByIdAsync(substanceCategoryId);
            return Ok(result);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<ServiceResponse<SubstanceCategory>>> GetSubstanceCategoryByTitleAsync(string title)
        {
            var result = await _substanceCategorySerivce.GetSubstanceCategoryByIdAsync(title);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SubstanceCategory>>>> GetAllSubstanceCategoriesAsync()
        {
            var result = await _substanceCategorySerivce.GetAllSubstanceCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("TitleAndPath")]
        public async Task<ActionResult<ServiceResponse<List<Tuple<string, string>>>>> GetOnlySubstanceCategoryTitlesAsync()
        {
            var result = await _substanceCategorySerivce.GetAllSubstanceCategoriesAsync();
            return Ok(result);
        }


    }
}
