using Microsoft.EntityFrameworkCore;
using TestOlimpiadas.Contexto;
using TestOlimpiadas.Models;

namespace TestOlimpiadas.Repositories
{
    public class SedeRepository
    {
        private readonly OlimpiadasContext _context;

        public SedeRepository(OlimpiadasContext context)
        {
            _context = context;
        }

        public async Task<List<Sede>> GetAllSedesAsync()
        {
            return await _context.Sede.ToListAsync();
        }

        public async Task<Sede> GetSedeByIdAsync(int id)
        {
            var sede = await _context.Sede.FindAsync(id);
            if (sede == null)
            {
                Sede Emptysede = new Sede();
                Emptysede.Id = 0;
                Emptysede.Presupuesto = 0;
                Emptysede.NumeroComplejos = 0;
                return Emptysede;
            }
            return sede;
        }

        public async Task AddSedeAsync(Sede sede)
        {
            _context.Sede.Add(sede);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSedeAsync(Sede sede)
        {
            _context.Entry(sede).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSedeAsync(int id)
        {
            var sede = await _context.Sede.FindAsync(id);
            _context.Sede.Remove(sede);
            await _context.SaveChangesAsync();
        }
    }
}
