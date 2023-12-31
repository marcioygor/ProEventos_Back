using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventosPersist
    {
        
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante=false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante=false);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrante=false);
    }
}