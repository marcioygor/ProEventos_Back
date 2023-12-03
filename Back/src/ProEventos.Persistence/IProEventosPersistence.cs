using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrante);

        //Palestrante

        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string Nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}