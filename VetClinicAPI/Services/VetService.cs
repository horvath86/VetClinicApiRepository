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

        public async Task<Veterinarian> UpdateVeterinarian(RegVeterinarian regVeterinarian, Veterinarian veterinarian)
        {
            string secureHash = BCrypt.Net.BCrypt.HashPassword(regVeterinarian.Password);

            veterinarian.Name = regVeterinarian.Name;
            veterinarian.Email = regVeterinarian.Email;
            veterinarian.PassHash = secureHash;
            

            await _genericRepository.UpdateAsync(veterinarian);

            return (veterinarian);

        }
    }
}
