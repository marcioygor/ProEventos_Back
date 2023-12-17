using System.Reflection;
using System;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService: IEventoService
    {

      private readonly IGeralPersist _geralPersist;
      private readonly IEventosPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventosPersist eventoPersist)
        {
            _eventoPersist=eventoPersist;
            _geralPersist=geralPersist;
        }

         public async Task<Evento> AddEventos(Evento model)
         {
            try
            {
              _geralPersist.Add<Evento>(model);
 
              if (await _geralPersist.SaveChangesAsync())
              {
                return await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
              }

              return null;

              }
              catch (System.Exception ex){

                throw new Exception(ex.Message);
             }
           
         }

          public async Task<Evento> UpdateEventos(int EventoId, Evento model){
             try
             {
                var evento=await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                if(evento==null) return null;

                model.Id=evento.Id;
                _geralPersist.Update<Evento>(model);
 
                if (await _geralPersist.SaveChangesAsync())
                {
                  return await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                }

              return null;

             }
             catch (System.Exception ex)
             {
                throw new Exception(ex.Message);           
             }
          }

          public async Task<bool> DeleteEventos(int EventoId){
             try
             {
                var evento=await _eventoPersist.GetAllEventoByIdAsync(EventoId, false);
                if(evento==null) throw new Exception("Evento para delete não encontrado");   

                _geralPersist.Delete<Evento>(evento);
 
                return await _geralPersist.SaveChangesAsync();
            
             }
             catch (System.Exception ex)
             {
                throw new Exception(ex.Message);           
             }
          }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante=false){

            try
            {
                var eventos=await _eventoPersist.GetAllEventosAsync(includePalestrante);
                if(eventos==null) return null;
                
                return null;
            }
            catch (System.Exception ex)
            {             
             throw new Exception(ex.Message);  
            }
        }

         public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante=false)
         {
            try
            {
                var eventos=await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrante);
                if(eventos==null) return null;
                
                return null;
            }
            catch (System.Exception ex)
            {             
             throw new Exception(ex.Message);  
            }
         }

         public async Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrante=false)
         {
            try
            {
                var eventos=await _eventoPersist.GetAllEventoByIdAsync(EventoId, includePalestrante);
                if(eventos==null) return null;
                
                return null;
            }
            catch (System.Exception ex)
            {             
             throw new Exception(ex.Message);  
            }
         }


    }
}
