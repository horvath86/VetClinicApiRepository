using VetClinicAPI.Data;
using VetClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VetClinicAPI.Repositories
{
    public class ProcedureRepository :GenericRepository<Procedure>, IProcedureRepository
    {
        private readonly AppDbContext _context;

        public ProcedureRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Procedure>> GetByMedicalRecordIdAsync(int medicalRecordId)
        {
            return await _context.Procedures
                .Where(p => p.MedicalRecordId == medicalRecordId)
                .ToListAsync();
        }
    }
}
