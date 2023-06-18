using ModernPharmacy.Shared.Entities;

namespace ModernPharmacy.Server.Services.PharmacyService
{
    public interface IPharmacyService
    {
        Task<ServiceResponse<Pharmacy>> GetPharmacyAsync(int productId);
    }
}
