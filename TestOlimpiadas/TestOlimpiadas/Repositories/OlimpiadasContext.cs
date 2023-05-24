using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestOlimpiadas.Models;

namespace TestOlimpiadas.Contexto
{
    public class OlimpiadasContext : DbContext
    {
        public DbSet<Sede> Sede { get; set; }

        public DbSet<ComplejoOlimpiada> ComplejoOlimpiada { get; set; }

        public OlimpiadasContext(DbContextOptions<OlimpiadasContext> options) : base (options)
        {

        }
    }
}
