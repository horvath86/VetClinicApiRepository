using VetClinicAPI.Data;
using VetClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VetClinicAPI.Repositories
{
    public class PrescriptionRepository :GenericRepository<Prescription>, IPrescriptionRepository
    {
        private readonly AppDbContext _context;

        public PrescriptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetByMedicalRecordIdAsync(int medicalRecordId)
        {
            return await _context.Prescriptions
                .Where(p => p.MedicalRecordId == medicalRecordId)
                .ToListAsync();
        }
    }
}
