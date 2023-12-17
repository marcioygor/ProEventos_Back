using System.Threading.Tasks;
using System;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int EventoId, Evento model);
        Task<bool>   DeleteEventos(int EventoId);       
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante=false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante=false);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrante=false);
    }
}
