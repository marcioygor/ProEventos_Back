﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;

        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {
            _context = context;

        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _context.Eventos.Where(x => x.Id == id);
        }

        public IEnumerable<Evento> Get()
        {
            return _context.Eventos.ToList();
        }

    }
}

