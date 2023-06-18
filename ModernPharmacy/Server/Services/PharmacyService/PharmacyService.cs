namespace ModernPharmacy.Server.Services.PharmacyService
{
    public class PharmacyService : IPharmacyService
    {
        private readonly DataContext _dataContext;

        public PharmacyService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<Pharmacy>> GetPharmacyAsync(int pharmacyId)
        {
            if (pharmacyId < 1)
                throw new BadRequestException($"Pharmacy id must be greater than {pharmacyId}");

            var response = new ServiceResponse<Pharmacy>();
            var pharmacy = await _dataContext.Pharmacies.FirstOrDefaultAsync(p => p.Id == pharmacyId);
            if(pharmacy == null)
            {
                throw new NotFoundException($"Pharmacy doesn't exist");
            }

            response.Data = pharmacy;
            return response;
        }
    }
}
