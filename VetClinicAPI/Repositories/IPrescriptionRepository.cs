using VetClinicAPI.Models;

namespace VetClinicAPI.Repositories
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<IEnumerable<Prescription>> GetByMedicalRecordIdAsync(int medicalRecordId);
    }
}
