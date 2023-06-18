using Microsoft.AspNetCore.Mvc;
using ModernPharmacy.Shared.Entities;

namespace ModernPharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet("{pharmacyId}")]
        public async Task<ActionResult<ServiceResponse<Pharmacy>>> GetPharmacy(int pharmacyId)
        {
            var result = await _pharmacyService.GetPharmacyAsync(pharmacyId);
            return Ok(result);
        }

    }
}
