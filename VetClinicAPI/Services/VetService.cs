using Microsoft.AspNetCore.Identity;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Services
{
    public class VetService
    {
        private readonly IRepository<Veterinarian> _genericRepository;

        public VetService(IRepository<Veterinarian> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Veterinarian> regVeterinarian(RegVeterinarian regVeterinarian)
        {
            string secureHash = BCrypt.Net.BCrypt.HashPassword(regVeterinarian.Password);

            var veterinarian = new Veterinarian
            {
                Name = regVeterinarian.Name,
                Email = regVeterinarian.Email,
                PassHash = secureHash
            }; 

            await _genericRepository.AddAsync(veterinarian);

            return (veterinarian);

        }
    }
}
