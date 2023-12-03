using System.Threading.Tasks;
using ProEventos.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(e => e.Lotes)
           .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
          .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string Nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Nome.ToLower().Contains(Nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

    }
}