using VetClinicAPI.Models;

namespace VetClinicAPI.Repositories
{
    public interface IProcedureRepository: IRepository<Procedure>
    {
        Task<IEnumerable<Procedure>> GetByMedicalRecordIdAsync(int medicalRecordId);
    }
}
