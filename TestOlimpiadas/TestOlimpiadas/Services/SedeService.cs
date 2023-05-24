using Microsoft.AspNetCore.Mvc;
using TestOlimpiadas.Models;
using TestOlimpiadas.Repositories;

namespace TestOlimpiadas.Services
{
    public class SedeService
    {
        private readonly SedeRepository _sedeRepository;

        public SedeService(SedeRepository sedeRepository)
        {
            _sedeRepository = sedeRepository;
        }

        public async Task<Sede> SedeDetail(int id) {
            var sede = await _sedeRepository.GetSedeByIdAsync(id);
            return sede;
        }

        public async Task<List<Sede>> GetAllSedes() {
            return await _sedeRepository.GetAllSedesAsync();
        }

        public async Task AddSede(Sede sede) {
           await _sedeRepository.AddSedeAsync(sede); 
        }

        public async Task UpdateSede(Sede sede)
        {
            await _sedeRepository.UpdateSedeAsync(sede);
        }

        public async Task DeleteSede(int id)
        {
            await _sedeRepository.DeleteSedeAsync(id);
        }

    }
}
