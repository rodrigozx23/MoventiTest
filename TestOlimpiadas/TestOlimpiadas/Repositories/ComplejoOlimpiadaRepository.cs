using Microsoft.EntityFrameworkCore;
using TestOlimpiadas.Contexto;
using TestOlimpiadas.Models;

namespace TestOlimpiadas.Repositories
{
    public class ComplejoOlimpiadaRepository
    {
        private readonly OlimpiadasContext _context;

        public ComplejoOlimpiadaRepository(OlimpiadasContext context)
        {
            _context = context;
        }

        public async Task<List<ComplejoOlimpiada>> GetAllComplejoOlimpiadaAsync()
        {
            return await _context.ComplejoOlimpiada.ToListAsync();
        }

        public async Task<ComplejoOlimpiada> GetComplejoOlimpiadaByIdAsync(int id)
        {
            var complejoOlimpiada = await _context.ComplejoOlimpiada.FindAsync(id);
            if (complejoOlimpiada == null) {
                ComplejoOlimpiada EmptycomplejoOlimpiada =new ComplejoOlimpiada();
                EmptycomplejoOlimpiada.Id = 0;
                EmptycomplejoOlimpiada.Localizacion = "";
                EmptycomplejoOlimpiada.AreaTotalOcupada = 0;
                EmptycomplejoOlimpiada.SedeId = 0;
                EmptycomplejoOlimpiada.TipoComplejo = 0;
                EmptycomplejoOlimpiada.JefeOrganizacion = "";
                return EmptycomplejoOlimpiada;
            }
            return complejoOlimpiada;
        }

        public async Task AddComplejoOlimpiadaAsync(ComplejoOlimpiada complejoOlimpiadas)
        {
            _context.ComplejoOlimpiada.Add(complejoOlimpiadas);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComplejoOlimpiadaAsync(ComplejoOlimpiada complejoOlimpiadas)
        {
            _context.Entry(complejoOlimpiadas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComplejoOlimpiadaAsync(int id)
        {
            var complejoOlimpiadas = await _context.ComplejoOlimpiada.FindAsync(id);
            _context.ComplejoOlimpiada.Remove(complejoOlimpiadas);
            await _context.SaveChangesAsync();
        }
    }
}
