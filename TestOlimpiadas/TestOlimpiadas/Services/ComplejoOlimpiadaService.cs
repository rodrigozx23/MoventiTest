using TestOlimpiadas.Models;
using TestOlimpiadas.Repositories;

namespace TestOlimpiadas.Services
{
    public class ComplejoOlimpiadaService
    {
        private readonly ComplejoOlimpiadaRepository _complejoOlimpiadaRepository;

        public ComplejoOlimpiadaService(ComplejoOlimpiadaRepository complejoOlimpiadaRepository)
        {
            _complejoOlimpiadaRepository = complejoOlimpiadaRepository;
        }

        public async Task<ComplejoOlimpiada> ComplejoOlimpiadaDetail(int id)
        {
            var complejoOlimpiada = await _complejoOlimpiadaRepository.GetComplejoOlimpiadaByIdAsync(id);
            return complejoOlimpiada;
        }

        public async Task<List<ComplejoOlimpiada>> GetAllComplejoOlimpiadas()
        {
            return await _complejoOlimpiadaRepository.GetAllComplejoOlimpiadaAsync();
        }

        public async Task AddComplejoOlimpiada(ComplejoOlimpiada sede)
        {
            await _complejoOlimpiadaRepository.AddComplejoOlimpiadaAsync(sede);
        }

        public async Task UpdateComplejoOlimpiada(ComplejoOlimpiada sede)
        {
            await _complejoOlimpiadaRepository.UpdateComplejoOlimpiadaAsync(sede);
        }

        public async Task DeleteComplejoOlimpiada(int id)
        {
            await _complejoOlimpiadaRepository.DeleteComplejoOlimpiadaAsync(id);
        }
    }
}
